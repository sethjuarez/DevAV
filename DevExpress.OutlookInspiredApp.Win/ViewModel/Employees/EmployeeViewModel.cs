namespace DevExpress.OutlookInspiredApp.Win.ViewModel {
    using System;
    using DevExpress.DevAV.DevAVDbDataModel;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.Mvvm.DataAnnotations;
    using DevExpress.Mvvm.POCO;

    public partial class EmployeeViewModel : EmployeeViewModelBase {
        public EmployeeViewModel()
            : base(DbUnitOfWorkFactory.Instance) {
        }
        public event EventHandler EntityChanged;
        protected override void OnEntityChanged() {
            base.OnEntityChanged();
            this.RaiseCanExecuteChanged(x => x.ShowMap());
            this.RaiseCanExecuteChanged(x => x.MailMerge());
            this.RaiseCanExecuteChanged(x => x.Print(EmployeeReportType.Profile));
            this.RaiseCanExecuteChanged(x => x.QuickLetter(EmployeeMailTemplate.ThankYouNote));
            EventHandler handler = EntityChanged;
            if(handler != null)
                handler(this, EventArgs.Empty);
        }
        [Command(UseCommandManager = false)]
        public void QuickLetter(EmployeeMailTemplate mailTemplate) {
            EmployeeCollectionViewModel collectionViewModel = ViewModelHelper.GetParentViewModel<EmployeeCollectionViewModel>(this);
            if(collectionViewModel != null)
                collectionViewModel.QuickLetterCore(Entity, mailTemplate);
        }
        public bool CanQuickLetter(EmployeeMailTemplate mailTemplate) {
            if(Entity == null || IsNew()) return false;
            EmployeeCollectionViewModel collectionViewModel = ViewModelHelper.GetParentViewModel<EmployeeCollectionViewModel>(this);
            return (collectionViewModel != null) && collectionViewModel.CanQuickLetterCore(Entity, mailTemplate);
        }
        [Command(UseCommandManager = false)]
        public void Print(EmployeeReportType reportType) {
            EmployeeCollectionViewModel collectionViewModel = ViewModelHelper.GetParentViewModel<EmployeeCollectionViewModel>(this);
            if(collectionViewModel != null)
                collectionViewModel.PrintCore(Entity, reportType);
        }
        public bool CanPrint(EmployeeReportType reportType) {
            if(Entity == null || IsNew()) return false;
            EmployeeCollectionViewModel collectionViewModel = ViewModelHelper.GetParentViewModel<EmployeeCollectionViewModel>(this);
            return (collectionViewModel != null) && collectionViewModel.CanPrintProfileCore(Entity);
        }
        [Command(UseCommandManager = false)]
        public void MailMerge() {
            EmployeeCollectionViewModel collectionViewModel = ViewModelHelper.GetParentViewModel<EmployeeCollectionViewModel>(this);
            if(collectionViewModel != null)
                collectionViewModel.MailMerge();
        }
        public bool CanMailMerge() {
            return (Entity != null) && !IsNew();
        }
        [Command(UseCommandManager = false)]
        public void ShowMap() {
            EmployeeCollectionViewModel collectionViewModel = ViewModelHelper.GetParentViewModel<EmployeeCollectionViewModel>(this);
            if(collectionViewModel != null)
                collectionViewModel.ShowMapCore(Entity);
        }
        public bool CanShowMap() {
            if(Entity == null || IsNew()) return false;
            EmployeeCollectionViewModel collectionViewModel = ViewModelHelper.GetParentViewModel<EmployeeCollectionViewModel>(this);
            return (collectionViewModel != null) && collectionViewModel.CanShowMapCore(Entity);
        }
        [Command(UseCommandManager = false)]
        public void ShowMeeting() {
            EmployeeCollectionViewModel collectionViewModel = ViewModelHelper.GetParentViewModel<EmployeeCollectionViewModel>(this);
            if(collectionViewModel != null)
                collectionViewModel.ShowMeeting();
        }
        public bool CanShowMeeting() {
            return (Entity != null) && !IsNew();
        }
        [Command(UseCommandManager = false)]
        public void ShowTask() {
            EmployeeCollectionViewModel collectionViewModel = ViewModelHelper.GetParentViewModel<EmployeeCollectionViewModel>(this);
            if(collectionViewModel != null)
                collectionViewModel.ShowTask();
        }
        public bool CanShowTask() {
            return (Entity != null) && !IsNew();
        }
    }
    public partial class synchronizedEmployeeViewModel : EmployeeViewModel {
        protected override bool EnableSelectedItemSynchronization { 
            get { return true; } 
        }
        protected override bool EnableEntityChangedSynchronization {
            get { return true; }
        }
    }
}
