using System;
using System.Collections.Generic;
using DevExpress.Data.Filtering;
using DevExpress.DevAV;
using DevExpress.OutlookInspiredApp.Win.ViewModel;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.WinExplorer;

namespace DevExpress.OutlookInspiredApp.Win.Modules {
    public partial class EmployeesGroupFilter : BaseModuleControl {
        public EmployeesGroupFilter(GroupFilterViewModel customFilterViewModel)
            : base(() => customFilterViewModel) {
            InitializeComponent();
            gridControl.Load += (s, e) => GridHelper.SetFindControlImages(gridControl, false);
            ViewModel.QueryFilterCriteria += ViewModel_QueryFilterCriteria;
            bindingSource.DataSource = customFilterViewModel;
            BindEditors();
            BindCommands();
            winExplorerView.Appearance.ItemDescriptionNormal.ForeColor = ColorHelper.DisabledTextColor;
            winExplorerView.Appearance.ItemDescriptionNormal.Options.UseForeColor = true;
            winExplorerView.Appearance.ItemDescriptionHovered.ForeColor = ColorHelper.DisabledTextColor;
            winExplorerView.Appearance.ItemDescriptionHovered.Options.UseForeColor = true;
            winExplorerView.Appearance.ItemDescriptionPressed.ForeColor = ColorHelper.DisabledTextColor;
            winExplorerView.Appearance.ItemDescriptionPressed.Options.UseForeColor = true;
        }
        protected override void OnDisposing() {
            ViewModel.QueryFilterCriteria -= ViewModel_QueryFilterCriteria;
            base.OnDisposing();
        }
        protected override void OnLoad(System.EventArgs e) {
            base.OnLoad(e);
            var expression = CollectionViewModel.GetExpression(ViewModel.FilterCriteria);
            if(expression != null) {
                foreach(Employee employee in CollectionViewModel.GetEntities(expression))
                    selection.Add(employee.Id);
            }
            gridControl.DataSource = CollectionViewModel.GetList();
        }
        void ViewModel_QueryFilterCriteria(object sender, QueryFilterCriteriaEventArgs e) {
            e.FilterCriteria = new InOperator("Id", selection);
        }
        public GroupFilterViewModel ViewModel {
            get { return GetViewModel<GroupFilterViewModel>(); }
        }
        public EmployeeCollectionViewModel CollectionViewModel {
            get { return GetParentViewModel<EmployeeCollectionViewModel>(); }
        }
        void BindEditors() {
            var errorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            errorProvider.ContainerControl = this;
            errorProvider.DataSource = bindingSource;
        }
        void BindCommands() {
            this.okBtn.BindCommand(() => ViewModel.OK(), ViewModel);
            this.cancelBtn.BindCommand(() => ViewModel.Cancel(), ViewModel);
        }
        HashSet<Guid> selection = new HashSet<Guid>();
        bool GetIsSelected(Employee employee) {
            return selection.Contains(employee.Id);
        }
        void SetIsSelected(Employee employee, bool selected) {
            if(selected)
                selection.Add(employee.Id);
            else
                selection.Remove(employee.Id);
        }
        void winExplorerView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) {
            if(e.IsSetData) SetIsSelected((Employee)e.Row, (bool)e.Value);
            if(e.IsGetData) e.Value = GetIsSelected((Employee)e.Row);
        }
        void winExplorerView_ItemClick(object sender, WinExplorerViewItemClickEventArgs e) {
            Employee employee = e.ItemInfo.Row.RowKey as Employee;
            if(employee != null) {
                SetIsSelected(employee, !e.ItemInfo.IsChecked);
                winExplorerView.RefreshData();
            }
        }
    }
}
