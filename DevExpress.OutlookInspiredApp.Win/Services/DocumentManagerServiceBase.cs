namespace DevExpress.OutlookInspiredApp.Win {
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using DevExpress.Mvvm;
    using DevExpress.OutlookInspiredApp.Win.Modules;

    public abstract class DocumentManagerServiceBase : IDocumentManagerService {
        IList<IDocument> documentsCore;
        public DocumentManagerServiceBase() {
            this.documentsCore = new List<IDocument>();
        }
        protected IDocument RegisterDocument(object view, Func<Form, IDocument> createDocument, Func<Form> createContainer, object id = null) {
            Form container = null;
            if(createContainer != null) {
                container = createContainer();
                if(container != null)
                    container.Owner = AppHelper.MainForm;
            }
            IDocument document = createDocument(container);
            document.Id = id;
            documentsCore.Add(document);
            if(view != null) {
                container.ClientSize = ((Control)view).Size;
                ((Control)view).Dock = DockStyle.Fill;
                ((Control)view).Parent = container;
                ((Control)view).BringToFront();
            }
            return document;
        }
        protected object EnsureViewModel(object viewModel, object parameter, object parentViewModel, object view) {
            if(viewModel == null) {
                if(view is ISupportViewModel)
                    viewModel = ((ISupportViewModel)view).ViewModel;
                ViewModelHelper.EnsureModuleViewModel(view, parentViewModel, parameter);
            }
            return viewModel;
        }
        protected internal void RemoveDocument(IDocument document) {
            documentsCore.Remove(document);
        }
        protected TService GetService<TService>(object viewModel) where TService : class {
            return ((ISupportServices)viewModel).ServiceContainer.GetService<TService>();
        }
        #region IDocumentManagerService
        IDocument IDocumentManagerService.CreateDocument(string documentType, object viewModel, object parameter, object parentViewModel) {
            return CreateDocumentCore(documentType, viewModel, parentViewModel, parameter);
        }
        IEnumerable<IDocument> IDocumentManagerService.Documents {
            get { return documentsCore; }
        }
        IDocument IDocumentManagerService.ActiveDocument {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        event ActiveDocumentChangedEventHandler IDocumentManagerService.ActiveDocumentChanged {
            add { }
            remove { }
        }
        #endregion IDocumentManagerService
        protected abstract IDocument CreateDocumentCore(string documentType, object viewModel, object parentViewModel, object parameter);
    }
    public abstract class DialogDocumentManagerService : DocumentManagerServiceBase {
        #region Document
        protected class DialogDocument : IDocument {
            readonly object contentCore;
            readonly Form formCore;
            readonly DialogDocumentManagerService owner;
            public DialogDocument(DialogDocumentManagerService owner, Form form, object content) {
                this.owner = owner;
                this.formCore = form;
                this.contentCore = content;
                form.Closed += form_Closed;
            }
            void form_Closed(object sender, EventArgs e) {
                owner.RemoveDocument(this);
                formCore.Closed -= form_Closed;
            }
            void IDocument.Show() {
                using(formCore) {
                    formCore.ShowDialog();
                }
            }
            void IDocument.Hide() {
                formCore.Close();
            }
            void IDocument.Close(bool force) {
                formCore.Close();
            }
            bool IDocument.DestroyOnClose {
                get { return true; }
                set { }
            }
            object IDocument.Id { get; set; }
            object IDocument.Title {
                get { return formCore.Text; }
                set { formCore.Text = Convert.ToString(value); }
            }
            object IDocument.Content {
                get { return contentCore; }
            }
        }
        #endregion Document
    }
}
