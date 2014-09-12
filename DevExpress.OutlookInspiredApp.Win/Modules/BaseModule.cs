namespace DevExpress.OutlookInspiredApp.Win.Modules {
    using System;
    using System.Linq.Expressions;
    using System.Windows.Forms;
    using DevExpress.XtraEditors;

    public class BaseModuleControl : XtraUserControl, ISupportViewModel {
        #region ctor for DesignTime
        BaseModuleControl() { }
        #endregion
        #region ViewModel injection
        object viewModelCore;
        protected BaseModuleControl(Func<object> viewModelInjector) {
            this.BindingContext = new System.Windows.Forms.BindingContext();
            this.viewModelCore = viewModelInjector();
            InitServices();
        }
        void InitServices() {
            var serviceContainer = GetServiceContainer();
            if(serviceContainer != null)
                OnInitServices(serviceContainer);
        }
        protected static TViewModel CreateViewModel<TViewModel>()
            where TViewModel : class, new() {
            return DevExpress.Mvvm.POCO.ViewModelSource.Create<TViewModel>();
        }
        protected static TViewModel CreateViewModel<TViewModel>(Expression<Func<TViewModel>> constructorExpression)
            where TViewModel : class, new() {
            return DevExpress.Mvvm.POCO.ViewModelSource.Create<TViewModel>(constructorExpression);
        }
        #endregion ViewModel injection
        protected override void Dispose(bool disposing) {
            if(disposing) {
                DestroyUIUpdateTimer();
                if(viewModelCore != null) {
                    ReleaseModule();
                    OnDisposing();
                }
                viewModelCore = null;
            }
            base.Dispose(disposing);
        }
        void ReleaseModule() {
            var locator = GetService<Services.IModuleLocator>();
            if(locator != null)
                locator.ReleaseModule(this);
        }
        protected void ReleaseModuleReports<TEnum>() where TEnum : struct {
            var locator = GetService<Services.IReportLocator>();
            if(locator == null) return;
            foreach(TEnum key in Enum.GetValues(typeof(TEnum)))
                locator.ReleaseReport(key);
        }
        protected virtual void OnInitServices(DevExpress.Mvvm.IServiceContainer serviceContainer) { }
        protected virtual void OnDisposing() { }
        protected TViewModel GetViewModel<TViewModel>() {
            return (TViewModel)viewModelCore;
        }
        protected TViewModel GetParentViewModel<TViewModel>() {
            return (TViewModel)((DevExpress.Mvvm.ISupportParentViewModel)viewModelCore).ParentViewModel;
        }
        protected TService GetService<TService>() where TService : class {
            var serviceContainer = GetServiceContainer();
            return (serviceContainer != null) ? serviceContainer.GetService<TService>() : null;
        }
        Mvvm.IServiceContainer GetServiceContainer() {
            if(!(viewModelCore is DevExpress.Mvvm.ISupportServices)) return null;
            return ((DevExpress.Mvvm.ISupportServices)viewModelCore).ServiceContainer;
        }
        object ISupportViewModel.ViewModel { get { return viewModelCore; } }
        void ISupportViewModel.ParentViewModelAttached() {
            OnParentViewModelAttached();
        }
        protected virtual void OnParentViewModelAttached() { }
        protected virtual void OnDelayedUIUpdate() { }
        protected virtual int GetUIUpdateDelay() { 
            return 250; 
        }
        Timer updateTimer;
        protected void QueueUIUpdate() {
            EnsureUIUpdateTimer();
            updateTimer.Stop();
            updateTimer.Start();
        }
        void EnsureUIUpdateTimer() {
            if(updateTimer == null) {
                updateTimer = new Timer();
                updateTimer.Interval = GetUIUpdateDelay();
                updateTimer.Tick += OnUIUpdate;
            }
        }
        void DestroyUIUpdateTimer() {
            if(updateTimer != null) {
                updateTimer.Tick -= OnUIUpdate;
                updateTimer.Stop();
                updateTimer.Dispose();
            }
            updateTimer = null;
        }
        void OnUIUpdate(object sender, EventArgs e) {
            updateTimer.Stop();
            OnDelayedUIUpdate();
        }
    }
}
