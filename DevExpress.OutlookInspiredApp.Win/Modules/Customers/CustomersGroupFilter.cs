using System;
using System.Collections.Generic;
using DevExpress.Data.Filtering;
using DevExpress.DevAV;
using DevExpress.OutlookInspiredApp.Win.ViewModel;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.WinExplorer;

namespace DevExpress.OutlookInspiredApp.Win.Modules {
    public partial class CustomersGroupFilter : BaseModuleControl {
        public CustomersGroupFilter(GroupFilterViewModel customFilterViewModel)
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
                foreach(Customer customer in CollectionViewModel.GetEntities(expression))
                    selection.Add(customer.Id);
            }
            gridControl.DataSource = CollectionViewModel.GetList();
        }
        void ViewModel_QueryFilterCriteria(object sender, QueryFilterCriteriaEventArgs e) {
            e.FilterCriteria = new InOperator("Id", selection);
        }
        public GroupFilterViewModel ViewModel {
            get { return GetViewModel<GroupFilterViewModel>(); }
        }
        public CustomerCollectionViewModel CollectionViewModel {
            get { return GetParentViewModel<CustomerCollectionViewModel>(); }
        }
        void BindEditors() {
            var errorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            errorProvider.ContainerControl = this;
            errorProvider.DataSource = bindingSource;
            //
            colStatus.ColumnEdit = EditorHelpers.CreateEnumImageComboBox<CustomerStatus>(gridControl);
        }
        void BindCommands() {
            this.okBtn.BindCommand(() => ViewModel.OK(), ViewModel);
            this.cancelBtn.BindCommand(() => ViewModel.Cancel(), ViewModel);
        }
        HashSet<Guid> selection = new HashSet<Guid>();
        bool GetIsSelected(Customer employee) {
            return selection.Contains(employee.Id);
        }
        void SetIsSelected(Customer customer, bool selected) {
            if(selected)
                selection.Add(customer.Id);
            else
                selection.Remove(customer.Id);
        }
        void winExplorerView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) {
            if(e.IsSetData) SetIsSelected((Customer)e.Row, (bool)e.Value);
            if(e.IsGetData) e.Value = GetIsSelected((Customer)e.Row);
        }
        void winExplorerView_ItemClick(object sender, WinExplorerViewItemClickEventArgs e) {
            Customer customer = e.ItemInfo.Row.RowKey as Customer;
            if(customer != null) {
                SetIsSelected(customer, !e.ItemInfo.IsChecked);
                winExplorerView.RefreshData();
            }
        }
    }
}
