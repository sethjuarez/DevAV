using System;
using System.Collections.Generic;
using DevExpress.Data.Filtering;
using DevExpress.DevAV;
using DevExpress.OutlookInspiredApp.Win.ViewModel;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.WinExplorer;

namespace DevExpress.OutlookInspiredApp.Win.Modules {
    public partial class ProductsGroupFilter : BaseModuleControl {
        public ProductsGroupFilter(GroupFilterViewModel customFilterViewModel)
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
                foreach(Product product in CollectionViewModel.GetEntities(expression))
                    selection.Add(product.Id);
            }
            gridControl.DataSource = CollectionViewModel.GetList();
        }
        void ViewModel_QueryFilterCriteria(object sender, QueryFilterCriteriaEventArgs e) {
            e.FilterCriteria = new InOperator("Id", selection);
        }
        public GroupFilterViewModel ViewModel {
            get { return GetViewModel<GroupFilterViewModel>(); }
        }
        public ProductCollectionViewModel CollectionViewModel {
            get { return GetParentViewModel<ProductCollectionViewModel>(); }
        }
        void BindEditors() {
            var errorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            errorProvider.ContainerControl = this;
            errorProvider.DataSource = bindingSource;
            //
            colCategory.ColumnEdit = EditorHelpers.CreateEnumImageComboBox<ProductCategory>(gridControl);
        }
        void BindCommands() {
            this.okBtn.BindCommand(() => ViewModel.OK(), ViewModel);
            this.cancelBtn.BindCommand(() => ViewModel.Cancel(), ViewModel);
        }
        HashSet<Guid> selection = new HashSet<Guid>();
        bool GetIsSelected(Product employee) {
            return selection.Contains(employee.Id);
        }
        void SetIsSelected(Product product, bool selected) {
            if(selected)
                selection.Add(product.Id);
            else
                selection.Remove(product.Id);
        }
        void winExplorerView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) {
            if(e.IsSetData) SetIsSelected((Product)e.Row, (bool)e.Value);
            if(e.IsGetData) e.Value = GetIsSelected((Product)e.Row);
        }
        void winExplorerView_ItemClick(object sender, WinExplorerViewItemClickEventArgs e) {
            Product product = e.ItemInfo.Row.RowKey as Product;
            if(product != null) {
                SetIsSelected(product, !e.ItemInfo.IsChecked);
                winExplorerView.RefreshData();
            }
        }
    }
}
