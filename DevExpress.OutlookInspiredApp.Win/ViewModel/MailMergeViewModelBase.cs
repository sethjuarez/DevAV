namespace DevExpress.OutlookInspiredApp.Win.ViewModel {
    using System;
    using DevExpress.Mvvm;

    public abstract class MailMergeViewModelBase<TMailTemplate> : ISupportParameter, IDocumentViewModel
        where TMailTemplate : struct {
        public virtual TMailTemplate? MailTemplate { get; set; }
        protected virtual void OnMailTemplateChanged() {
            RaiseMailTemplateChanged();
        }
        public virtual bool IsMailTemplateSelected { get; set; }
        protected virtual void OnIsMailTemplateSelectedChanged() {
            RaiseMailTemplateSelectedChanged();
        }
        object ISupportParameter.Parameter {
            get { return MailTemplate; }
            set {
                IsMailTemplateSelected = value is TMailTemplate;
                if(IsMailTemplateSelected)
                    MailTemplate = (TMailTemplate)value;
                else MailTemplate = null;
            }
        }
        public event EventHandler MailTemplateChanged;
        public event EventHandler MailTemplateSelectedChanged;
        void RaiseMailTemplateChanged() {
            EventHandler handler = MailTemplateChanged;
            if(handler != null)
                handler(this, EventArgs.Empty);
        }
        void RaiseMailTemplateSelectedChanged() {
            EventHandler handler = MailTemplateSelectedChanged;
            if(handler != null)
                handler(this, EventArgs.Empty);
        }
        [DevExpress.Mvvm.DataAnnotations.ServiceProperty]
        protected virtual IDocumentManagerService DocumentManagerService {
            get { throw new NotImplementedException(); }
        }
        [DevExpress.Mvvm.DataAnnotations.ServiceProperty]
        protected virtual IMessageBoxService MessageBoxService {
            get { throw new NotImplementedException(); }
        }
        public bool Modified { get; set; }
        [DevExpress.Mvvm.DataAnnotations.Command]
        public bool Close() {
            System.Windows.MessageBoxResult result = System.Windows.MessageBoxResult.Yes;
            if(Modified) {
                if(MessageBoxService != null) {
                    result = MessageBoxService.Show("Do you want to save changes?", "Mail Merge",
                        System.Windows.MessageBoxButton.YesNoCancel,
                        System.Windows.MessageBoxImage.Question,
                        System.Windows.MessageBoxResult.Yes);
                    if(result == System.Windows.MessageBoxResult.Yes) 
                        RaiseSave();
                }
            }
            if(result != System.Windows.MessageBoxResult.Cancel && DocumentManagerService != null) {
                IDocument document = DocumentManagerService.FindDocument(this);
                if(document != null)
                    document.Close();
            }
            return result != System.Windows.MessageBoxResult.Cancel;
        }
        public event EventHandler Save;
        void RaiseSave() {
            EventHandler handler = Save;
            if(handler != null)
                handler(this, EventArgs.Empty);
        }
        #region IDocumentViewModel
        object IDocumentViewModel.Title {
            get { return "Mail Merge"; }
        }
        bool IDocumentViewModel.Close() {
            return Close();
        }
        #endregion
    }
}
