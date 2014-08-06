namespace DevExpress.OutlookInspiredApp.Win.Modules {
    using System.Windows.Forms;
    using DevExpress.DevAV;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.OutlookInspiredApp.Win.ViewModel;
    using DevExpress.XtraEditors;

    public partial class EmployeeEditView : BaseModuleControl, IRibbonModule {
        public EmployeeEditView()
            : base(CreateViewModel<EmployeeViewModel>) {
            InitializeComponent();
            GalleryItemAppearances.Apply(galleryQuickLetters);
            //
            ViewModel.EntityChanged += viewModel_EntityChanged;
            BindCommands();
            BindEditors();
            gvEvaluations.OptionsView.ShowPreview = false;
            gvTasks.OptionsView.ShowPreview = false;
        }
        public EmployeeViewModel ViewModel {
            get { return GetViewModel<EmployeeViewModel>(); }
        }
        public EmployeeCollectionViewModel CollectionViewModel {
            get { return GetParentViewModel<EmployeeCollectionViewModel>(); }
        }
        protected override void OnParentViewModelAttached() {
            BindCollectionViewCommands();
        }
        protected override void OnDisposing() {
            updateQueued = -1;
            ViewModel.EntityChanged -= viewModel_EntityChanged;
            base.OnDisposing();
        }
        void viewModel_EntityChanged(object sender, System.EventArgs e) {
            UpdateUI(ViewModel.Entity);
        }
        void UpdateUI(Employee employee) {
            if(employee == null) return;
            if(object.Equals(bindingSource.DataSource, employee)) {
                employee.ResetBindable();
                bindingSource.ResetBindings(false);
            }
            else bindingSource.DataSource = employee;
            //
            ribbonControl.ApplicationDocumentCaption = ViewModel.IsNew() ? "New Employee" : employee.FullNameBindable;
        }
        void BindCommands() {
            //Save & Close
            biSave.BindCommand(() => ViewModel.Save(), ViewModel);
            biClose.BindCommand(() => ViewModel.Close(), ViewModel);
            biSaveAndClose.BindCommand(() => ViewModel.SaveAndClose(), ViewModel);
            //Delete
            biDelete.BindCommand(() => ViewModel.Delete(), ViewModel);
            //Reload
            biRefresh.BindCommand(() => ViewModel.Reload(), ViewModel);
        }
        void BindCollectionViewCommands() {
            //Map
            biShowMap.BindCommand(() => ViewModel.ShowMap(), ViewModel);
            //Print
            BindPrintItem(bmiPrintProfile, EmployeeReportType.Profile);
            BindPrintItem(bmiPrintSummary, EmployeeReportType.Summary);
            BindPrintItem(bmiPrintDirectory, EmployeeReportType.Directory);
            BindPrintItem(bmiPrintTaskList, EmployeeReportType.TaskList);
            //Mail Merge
            biMailMerge.BindCommand(() => ViewModel.MailMerge(), ViewModel);
            //Quick Letters
            BindGalleryQuickLettersItem(0, EmployeeMailTemplate.ThankYouNote);
            BindGalleryQuickLettersItem(1, EmployeeMailTemplate.EmployeeOfTheMonth);
            BindGalleryQuickLettersItem(2, EmployeeMailTemplate.ServiceExcellence);
            BindGalleryQuickLettersItem(3, EmployeeMailTemplate.ProbationNotice);
            BindGalleryQuickLettersItem(4, EmployeeMailTemplate.WelcomeToDevAV);
            //
            biMeeting.BindCommand(() => ViewModel.ShowMeeting(), ViewModel);
            biTask.BindCommand(() => ViewModel.ShowTask(), ViewModel);
        }
        void BindPrintItem(DevExpress.XtraBars.BarButtonItem printItem, EmployeeReportType parameter) {
            printItem.BindCommand(() => ViewModel.Print(parameter), ViewModel, () => parameter);
        }
        void BindGalleryQuickLettersItem(int index, EmployeeMailTemplate parameter) {
            galleryQuickLetters.Gallery.Groups[0].Items[index].BindCommand(() => ViewModel.QuickLetter(parameter), ViewModel, () => parameter);
        }
        void BindEditors() {
            StatusImageComboBoxEdit.Properties.Items.AddEnum<EmployeeStatus>();
            EditorHelpers.CreatePersonPrefixImageComboBox(PrefixImageComboBoxEdit.Properties, null);
            colPriority.ColumnEdit = EditorHelpers.CreateTaskPriorityImageComboBox(null, gridControlTasks.RepositoryItems);
            DepartmentImageComboBoxEdit.Properties.Items.AddEnum<EmployeeDepartment>();
            StateImageComboBoxEdit.Properties.Items.AddEnum<StateEnum>();
            //
            ZipCodeTextEdit.DataBindings.Add(new Binding("EditValue", bindingSource, "Address.ZipCode", true, DataSourceUpdateMode.OnPropertyChanged));
            StateImageComboBoxEdit.DataBindings.Add(new Binding("EditValue", bindingSource, "Address.State", true, DataSourceUpdateMode.OnPropertyChanged));
            CityTextEdit.DataBindings.Add(new Binding("EditValue", bindingSource, "Address.City", true, DataSourceUpdateMode.OnPropertyChanged));
            AddressTextEdit.DataBindings.Add(new Binding("EditValue", bindingSource, "Address.Line", true, DataSourceUpdateMode.OnPropertyChanged));
            //
            MobilePhoneTextEdit.Properties.Buttons[0].BindCommand(() => ViewModel.Contacts.MobileCall(), ViewModel.Contacts);
            HomePhoneTextEdit.Properties.Buttons[0].BindCommand(() => ViewModel.Contacts.HomeCall(), ViewModel.Contacts);
            EmailTextEdit.Properties.Buttons[0].BindCommand(() => ViewModel.Contacts.MailTo(), ViewModel.Contacts);
            SkypeTextEdit.Properties.Buttons[0].BindCommand(() => ViewModel.Contacts.VideoCall(), ViewModel.Contacts);
            //
            foreach(var item in moduleDataLayout.Controls) {
                BaseEdit edit = item as BaseEdit;
                if(edit == null || edit.DataBindings.Count == 0) continue;
                EditorHelpers.ApplyBindingSettings<Employee>(edit, moduleDataLayout);
                edit.Properties.EditValueChanged += (s, e) => QueueViewModelUpdate();
            }
            //
            FirstNameTextEdit.EditValueChanged += (s, e) => QueueFullNameUpdate();
            LastNameTextEdit.EditValueChanged += (s, e) => QueueFullNameUpdate();
            FullNameTextEdit.EditValueChanged += (s, e) => QueueFullNameUpdate();
        }
        int fullNameUpdateQueued = 0;
        void QueueFullNameUpdate() {
            if(updateQueued < 0) return;
            if(0 == fullNameUpdateQueued) {
                fullNameUpdateQueued++;
                BeginInvoke(new MethodInvoker(UpdateFullNameEditValue));
            }
            else fullNameUpdateQueued++;
        }
        void UpdateFullNameEditValue() {
            FullNameTextEdit.DataBindings["EditValue"].ReadValue();
            fullNameUpdateQueued = 0;
        }
        int updateQueued = 0;
        void QueueViewModelUpdate() {
            if(updateQueued < 0) return;
            if(0 == updateQueued) {
                updateQueued++;
                BeginInvoke(new MethodInvoker(UpdateViewModel));
            }
            else updateQueued++;
        }
        void UpdateViewModel() {
            ViewModel.ValidationErrors = errorProvider.HasErrors;
            ViewModel.Update();
            updateQueued = 0;
        }
        #region
        XtraBars.Ribbon.RibbonControl IRibbonModule.Ribbon {
            get { return ribbonControl; }
        }
        #endregion
        void gvEvaluations_RowCellStyle(object sender, XtraGrid.Views.Grid.RowCellStyleEventArgs e) {
            Evaluation evaluation = gvEvaluations.GetRow(e.RowHandle) as Evaluation;
            if(evaluation == null) return;
            if(evaluation.Rating == EvaluationRating.Good) e.Appearance.ForeColor = ColorHelper.InformationColor;
            if(evaluation.Rating == EvaluationRating.Poor) e.Appearance.ForeColor = ColorHelper.CriticalColor;
        }
    }
}
