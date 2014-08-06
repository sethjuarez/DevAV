namespace DevExpress.OutlookInspiredApp.Win.Modules {
    using DevExpress.DevAV;
    using DevExpress.OutlookInspiredApp.Win.ViewModel;
    using DevExpress.XtraBars.Docking2010;
    using DevExpress.XtraLayout.Utils;

    public partial class EmployeeView : BaseModuleControl {
        public EmployeeView()
            : base(CreateViewModel<synchronizedEmployeeViewModel>) {
            InitializeComponent();
            gvTasks.SetViewFontSize(2, 1);
            gvEvaluations.SetViewFontSize(2, 1);
            BindCommands();
            ViewModel.EntityChanged += ViewModel_EntityChanged;
            lbEvaluations.Tag = true; lbTasks.Tag = false;
            new LabelTabController(lbTasks.Tag, lbEvaluations, lbTasks).EditValueChanged += (s, e) =>
            {
                lciEvaluations.Visibility = (bool)s ? LayoutVisibility.Always : LayoutVisibility.Never;
                lciTasks.Visibility = !(bool)s ? LayoutVisibility.Always : LayoutVisibility.Never;
            };
        }
        protected override void OnDisposing() {
            ViewModel.EntityChanged -= ViewModel_EntityChanged;
            base.OnDisposing();
        }
        public EmployeeViewModel ViewModel {
            get { return GetViewModel<EmployeeViewModel>(); }
        }
        public EmployeeCollectionViewModel CollectionViewModel {
            get { return GetParentViewModel<EmployeeCollectionViewModel>(); }
        }
        void ViewModel_EntityChanged(object sender, System.EventArgs e) {
            QueueUIUpdate();
        }
        protected override void OnDelayedUIUpdate() {
            UpdateUI(ViewModel.Entity);
        }
        protected override void OnLoad(System.EventArgs e) {
            base.OnLoad(e);
            UpdateUI(ViewModel.Entity);
        }
        void BindCommands() {
            ((WindowsUIButton)buttonPanel.Buttons[0]).BindCommand(() => ViewModel.Contacts.Message(), ViewModel.Contacts);
            ((WindowsUIButton)buttonPanel.Buttons[1]).BindCommand(() => ViewModel.Contacts.Phone(), ViewModel.Contacts);
            ((WindowsUIButton)buttonPanel.Buttons[2]).BindCommand(() => ViewModel.Contacts.VideoCall(), ViewModel.Contacts);
            ((WindowsUIButton)buttonPanel.Buttons[3]).BindCommand(() => ViewModel.Contacts.MailTo(), ViewModel.Contacts);
        }
        void UpdateUI(Employee employee) {
            if(employee != null) {
                if(!object.Equals(bindingSource.DataSource, employee))
                    bindingSource.DataSource = employee;
                else {
                    employee.ResetBindable();
                    bindingSource.ResetBindings(false);
                }
                gcTasks.DataSource = employee.AssignedTasks;
                gcEvaluations.DataSource = employee.Evaluations;
            }
            else {
                gcTasks.DataSource = null;
                gcEvaluations.DataSource = null;
            }
            modueLayout.Visible = (employee != null);
        }
        public bool IsHorizontalLayout {
            get { return !colDescription.Visible; }
            set {
                gvEvaluations.OptionsView.ShowPreview = value;
                gvTasks.OptionsView.ShowPreview = value;
                colDescription.Visible = !value;
            }
        }
    }
}
