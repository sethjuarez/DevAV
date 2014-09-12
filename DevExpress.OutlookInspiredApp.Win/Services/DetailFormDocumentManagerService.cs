namespace DevExpress.OutlookInspiredApp.Win {
    using System;
    using System.Windows.Forms;
    using DevExpress.Mvvm;
    using DevExpress.OutlookInspiredApp.Services;
    using DevExpress.OutlookInspiredApp.Win.Modules;

    abstract class DetailFormDocumentManagerServiceBase : DocumentManagerServiceBase {
        readonly ModuleType viewModuleType;
        public DetailFormDocumentManagerServiceBase(ModuleType viewModuleType) {
            this.viewModuleType = viewModuleType;
        }
        #region Document
        protected class DetailFormDocument : IDocument {
            readonly object contentCore;
            readonly Form formCore;
            readonly DetailFormDocumentManagerServiceBase owner;
            public DetailFormDocument(DetailFormDocumentManagerServiceBase owner, Form form, object content) {
                this.owner = owner;
                this.formCore = form;
                this.contentCore = content;
                form.Closing += form_Closing;
                form.Closed += form_Closed;
            }
            void form_Closed(object sender, EventArgs e) {
                owner.RemoveDocument(this);
                formCore.Closing -= form_Closing;
                formCore.Closed -= form_Closed;
                IDocumentContent documentContent = GetContent() as IDocumentContent;
                if(documentContent != null)
                    documentContent.OnDestroy();
            }
            void form_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
                IDocumentContent documentContent = GetContent() as IDocumentContent;
                if(documentContent != null)
                    documentContent.OnClose(e);
                if(!destroyOnCloseCore) {
                    bool cancel = e.Cancel;
                    e.Cancel = true;
                    if(!cancel)
                        formCore.Hide();
                }
            }
            void IDocument.Show() {
                if(!formCore.Visible)
                    formCore.Show(AppHelper.MainForm);
                else
                    formCore.Activate();
            }
            void IDocument.Hide() {
                formCore.Hide();
            }
            void IDocument.Close(bool force) {
                if(force)
                    formCore.Closing -= form_Closing;
                formCore.Close();
            }
            bool destroyOnCloseCore = true;
            bool IDocument.DestroyOnClose {
                get { return destroyOnCloseCore; }
                set { destroyOnCloseCore = value; }
            }
            object IDocument.Id { get; set; }
            object IDocument.Title {
                get { return formCore.Text; }
                set { formCore.Text = Convert.ToString(value); }
            }
            object IDocument.Content {
                get { return GetContent(); }
            }
            object GetContent() {
                return contentCore;
            }
        }
        #endregion Document
        protected virtual ModuleType GetActualViewModuleType(string documentType, object parentViewModel) {
            if(documentType == "MapView") {
                var resolver = GetService<Services.IModuleTypesResolver>(parentViewModel);
                return resolver.GetMapModuleType(viewModuleType);
            }
            if(documentType == "MailMerge") {
                var resolver = GetService<Services.IModuleTypesResolver>(parentViewModel);
                return resolver.GetMailMergeModuleType(viewModuleType);
            }
            if(documentType == "Analysis") {
                var resolver = GetService<Services.IModuleTypesResolver>(parentViewModel);
                return resolver.GetAnalysisModuleType(viewModuleType);
            }
            return viewModuleType;
        }
    }
    class DetailFormDocumentManagerService : DetailFormDocumentManagerServiceBase, IDocumentManagerService {
        public DetailFormDocumentManagerService(ModuleType viewModuleType)
            : base(viewModuleType) {
        }
        protected override IDocument CreateDocumentCore(string documentType, object viewModel, object parentViewModel, object parameter) {
            var actualModuleType = GetActualViewModuleType(documentType, parentViewModel);
            var moduleLocator = GetService<Services.IModuleLocator>(parentViewModel);
            var waitingService = GetService<Services.IWaitingService>(parentViewModel);
            using(waitingService.Enter(actualModuleType)) {
                object view = null;
                if(parameter is Guid)
                    view = moduleLocator.GetModule(actualModuleType, (Guid)parameter);
                else
                    view = moduleLocator.GetModule(actualModuleType);
                viewModel = EnsureViewModel(viewModel, parameter, parentViewModel, view);
                return RegisterDocument(view, (container) => new DetailFormDocument(this, container, viewModel), () => new DetailForm(), parameter);
            }
        }
    }
    class NotImplementedDetailFormDocumentManagerService : DetailFormDocumentManagerServiceBase, IDocumentManagerService {
        public NotImplementedDetailFormDocumentManagerService(ModuleType viewModuleType)
            : base(viewModuleType) {
        }
        protected override IDocument CreateDocumentCore(string documentType, object viewModel, object parentViewModel, object parameter) {
            var actualModuleType = GetActualViewModuleType(documentType, parentViewModel);
            if(actualModuleType != ModuleType.Unknown) {
                var moduleLocator = ((ISupportServices)parentViewModel).ServiceContainer.GetService<Services.IModuleLocator>();
                var waitingService = ((ISupportServices)parentViewModel).ServiceContainer.GetService<Services.IWaitingService>();
                using(waitingService.Enter(actualModuleType)) {
                    object view = null;
                    if(parameter is Guid)
                        view = moduleLocator.GetModule(actualModuleType, (Guid)parameter);
                    else
                        view = moduleLocator.GetModule(actualModuleType);
                    viewModel = EnsureViewModel(viewModel, parameter, parentViewModel, view);
                    return RegisterDocument(view, (container) => new DetailFormDocument(this, container, viewModel), () => new DetailForm(), parameter);
                }
            }
            return new DXOverviewDocument();
        }
        protected override ModuleType GetActualViewModuleType(string documentType, object parentViewModel) {
            if(documentType == "MapView" || documentType == "MailMerge" || documentType == "Analysis")
                return base.GetActualViewModuleType(documentType, parentViewModel);
            return ModuleType.Unknown;
        }
        #region DXAbout
        protected class DXOverviewDocument : IDocument {
            Form form = new DevExpress.XtraEditors.XtraForm();
            const string captionText =
                "DevExpress";
            const string descriptionText =
                "You can easily create custom edit forms using the 40+ controls that ship as part of the DevExpress Data Editors Library.<br>" +
                "To see what you can build, <href=Employees>activate the Employees module.</href>";
            #region IDocument Members
            void IDocument.Show() {
                OverviewControl overview = new OverviewControl();
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.Text = captionText;
                form.ClientSize = overview.Size;
                form.MinimumSize = form.Size;
                overview.SetDescription(descriptionText);
                overview.Dock = DockStyle.Fill;
                overview.Parent = form;
                form.StartPosition = FormStartPosition.CenterParent;
                form.Icon = AppHelper.AppIcon;
                using(form) {
                    form.ShowDialog(AppHelper.MainForm);
                }
            }
            object IDocument.Content { get { return null; } }
            bool IDocument.DestroyOnClose { get; set; }
            void IDocument.Hide() {
                form.Close();
            }
            void IDocument.Close(bool force) {
                form.Close();
            }
            object IDocument.Title { get; set; }
            object IDocument.Id { get; set; }
            #endregion
        }
        #endregion
    }
}
