namespace DevExpress.OutlookInspiredApp.Win.Modules {
    using DevExpress.OutlookInspiredApp.Win.ViewModel;

    public partial class ViewSettingsControl : BaseModuleControl {
        public ViewSettingsControl(CollectionUIViewModel collectionViewModel)
            : base(() => CreateViewModel<ViewSettingsViewModel>(() => new ViewSettingsViewModel(collectionViewModel))) {
            InitializeComponent();
            BindCommands();
        }
        public ViewSettingsViewModel ViewModel {
            get { return GetViewModel<ViewSettingsViewModel>(); }
        }
        void BindCommands() {
            this.resetFiltersBtn.BindCommand(() => ViewModel.ResetCustomFilters(), ViewModel);
            this.resetViewBtn.BindCommand(() => ViewModel.ResetView(), ViewModel);
            //
            this.okBtn.BindCommand(() => ViewModel.OK(), ViewModel);
            this.cancelBtn.BindCommand(() => ViewModel.Cancel(), ViewModel);
        }
    }
}
namespace DevExpress.OutlookInspiredApp.Win.ViewModel {
    using DevExpress.Mvvm;
    using DevExpress.Mvvm.DataAnnotations;

    public class ViewSettingsViewModel {
        CollectionUIViewModel collectionUIViewModelCore;
        public ViewSettingsViewModel() { }
        public ViewSettingsViewModel(CollectionUIViewModel collectionUIViewModel) {
            this.collectionUIViewModelCore = collectionUIViewModel;
        }
        [Command]
        public void ResetCustomFilters() {
            var vm = ViewModelHelper.GetParentViewModel<ISupportCustomFilters>(this);
            if(vm != null)
                vm.ResetCustomFilters();
        }
        public CollectionUIViewModel CollectionUIViewModel {
            get { return collectionUIViewModelCore; }
        }
        [Command]
        public void ResetView() {
            CollectionUIViewModel.ResetView();
        }
        public IDocument Document { get; set; }
        [Command]
        public void OK() {
            Document.Close();
        }
        [Command]
        public void Cancel() {
            Document.Close();
        }
    }
}
