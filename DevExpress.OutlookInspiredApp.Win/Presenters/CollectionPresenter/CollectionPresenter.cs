namespace DevExpress.OutlookInspiredApp.Win.Presenters {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using DevExpress.DevAV.Common.ViewModel;
    using DevExpress.Utils;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.Base;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraGrid.Views.Layout;

    public abstract class CollectionPresenter<TEntity, TID, TUnitOfWork> :
        BasePresenter<CollectionViewModel<TEntity, TID, TUnitOfWork>>
        where TEntity : class
        where TUnitOfWork : DevExpress.DevAV.Common.DataModel.IUnitOfWork {
        Action<int> updateUIAction;
        public CollectionPresenter(GridControl gridControl, CollectionViewModel<TEntity, TID, TUnitOfWork> viewModel, Action<int> updateUIAction)
            : base(viewModel) {
            this.gridControlCore = gridControl;
            this.updateUIAction = updateUIAction;
            this.gridViewCore = gridControl.ViewCollection.FirstOrDefault(view => (view is GridView) && string.IsNullOrEmpty(view.LevelName)) as GridView;
            this.layoutViewCore = gridControl.ViewCollection.FirstOrDefault(view => (view is LayoutView) && string.IsNullOrEmpty(view.LevelName)) as LayoutView;
            //
            SubscribeViewModelEvents();
            InitMouseClickBehavior();
            InitFocusedRowSynchronization();
            //
            GridControl.Load += GridControl_Load;
        }
        protected override void OnDisposing() {
            GridControl.Load -= GridControl_Load;
            //
            UnsubscribeViewModelEvents();
            ReleaseMouseClickBehavior();
            ReleaseFocusedRowSynchronization();
            //
            this.gridControlCore = null;
            this.layoutViewCore = null;
            this.gridViewCore = null;
            base.OnDisposing();
        }
        GridControl gridControlCore;
        protected GridControl GridControl {
            get { return gridControlCore; }
        }
        GridView gridViewCore;
        protected GridView GridView {
            get { return gridViewCore; }
        }
        LayoutView layoutViewCore;
        protected LayoutView LayoutView {
            get { return layoutViewCore; }
        }
        protected virtual void SubscribeViewModelEvents() {
            ViewModel.EntityAdded += ViewModel_EntityAddedOrDeleted;
            ViewModel.EntityDeleted += ViewModel_EntityAddedOrDeleted;
        }
        protected virtual void UnsubscribeViewModelEvents() {
            ViewModel.EntityAdded -= ViewModel_EntityAddedOrDeleted;
            ViewModel.EntityDeleted -= ViewModel_EntityAddedOrDeleted;
        }
        void GridControl_Load(object sender, System.EventArgs e) {
            GridHelper.SetFindControlImages(GridControl);
            SetTopRow();
        }
        protected virtual void SetTopRow() {
            if(GridView != null) {
                GridView.ClearSelection();
                GridView.SelectRow(0);
                GridView.FocusedRowHandle = 0;
            }
        }
        protected void ViewModel_Reload(object sender, System.EventArgs e) {
            OnReloadEntities();
            SetTopRow();
        }
        protected void ViewModel_EntityChanged(object sender, EntityEventArgs<TEntity> e) {
            if(LayoutView != null)
                LayoutView.InvalidateCardCaption(LayoutView.LocateByValue(GetKeyColumn(), GetKey(e.Entity)));
        }
        void ViewModel_EntityAddedOrDeleted(object sender, System.EventArgs e) {
            UpdateEntitiesCountRelatedUI(ViewModel.Entities.Count);
        }
        void OnReloadEntities() {
            GridControl.DataSource = ViewModel.Entities;
            ((ColumnView)GridControl.MainView).FindFilterText = null;
            ((ColumnView)GridControl.MainView).ActiveFilterString = null;
            UpdateEntitiesCountRelatedUI(ViewModel.Entities.Count);
        }
        void UpdateEntitiesCountRelatedUI(int count) {
            if(updateUIAction != null) updateUIAction(count);
        }
        #region Focused Row Synchronization
        void InitFocusedRowSynchronization() {
            ViewModel.SelectedEntityChanged += ViewModel_SelectedEntityChanged;
            if(GridView != null) {
                GridView.DataController.AllowCurrentRowObjectForGroupRow = false;
                GridView.FocusedRowObjectChanged += ColumnView_FocusedRowObjectChanged;
                GridView.SelectionChanged += View_SelectionChanged;
            }
            if(LayoutView != null) {
                LayoutView.FocusedRowObjectChanged += ColumnView_FocusedRowObjectChanged;
                LayoutView.SelectionChanged += View_SelectionChanged;
            }
        }
        void ReleaseFocusedRowSynchronization() {
            ViewModel.SelectedEntityChanged -= ViewModel_SelectedEntityChanged;
            if(GridView != null) {
                GridView.FocusedRowObjectChanged -= ColumnView_FocusedRowObjectChanged;
                GridView.SelectionChanged -= View_SelectionChanged;
            }
            if(LayoutView != null) {
                LayoutView.FocusedRowObjectChanged -= ColumnView_FocusedRowObjectChanged;
                LayoutView.SelectionChanged -= View_SelectionChanged;
            }
        }
        void View_SelectionChanged(object sender, Data.SelectionChangedEventArgs e) {
            var helper = new ColumnViewHelper<TEntity, TID, TUnitOfWork>((ColumnView)sender, ViewModel);
            SetSelection(helper.GetSelection());
        }
        int lockFocusedRowChanged = 0;
        void ColumnView_FocusedRowObjectChanged(object sender, XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e) {
            lockFocusedRowChanged++;
            try {
                ColumnView view = (ColumnView)sender;
                if(view.IsValidRowHandle(e.FocusedRowHandle)) {
                    if(view.IsDataRow(e.FocusedRowHandle))
                        ViewModel.SelectedEntity = e.Row as TEntity;
                    else
                        ViewModel.SelectedEntity = null;
                }
            }
            finally { lockFocusedRowChanged--; }
        }
        void ViewModel_SelectedEntityChanged(object sender, System.EventArgs e) {
            if(lockFocusedRowChanged > 0) return;
            if(ViewModel.SelectedEntity == null) {
                if(GridView != null)
                    GridView.FocusedRowHandle = GridControl.InvalidRowHandle;
                if(LayoutView != null)
                    LayoutView.FocusedRowHandle = GridControl.InvalidRowHandle;
            }
            else {
                if(GridView != null)
                    GridView.FocusedRowHandle = GridView.LocateByValue(GetKeyColumn(), GetKey(ViewModel.SelectedEntity));
                if(LayoutView != null)
                    LayoutView.FocusedRowHandle = LayoutView.LocateByValue(GetKeyColumn(), GetKey(ViewModel.SelectedEntity));
            }
        }
        protected abstract void SetSelection(IEnumerable<TEntity> selection);
        protected abstract TID GetKey(TEntity entity);
        protected virtual string GetKeyColumn() {
            return "Id";
        }
        #endregion
        #region Mouse Click Behavior
        protected virtual void InitMouseClickBehavior() {
            if(GridView != null) {
                GridView.RowClick += GridView_RowClick;
                GridView.PopupMenuShowing += GridView_PopupMenuShowing;
            }
            if(LayoutView != null) {
                LayoutView.MouseDown += LayoutView_MouseDown;
                LayoutView.DoubleClick += LayoutView_DoubleClick;
            }
        }
        protected virtual void ReleaseMouseClickBehavior() {
            if(GridView != null) {
                GridView.RowClick -= GridView_RowClick;
                GridView.PopupMenuShowing -= GridView_PopupMenuShowing;
            }
            if(LayoutView != null) {
                LayoutView.MouseDown -= LayoutView_MouseDown;
                LayoutView.DoubleClick -= LayoutView_DoubleClick;
            }
        }
        void LayoutView_DoubleClick(object sender, System.EventArgs e) {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            if(ea.Button != MouseButtons.Left) return;
            var hitInfo = ((LayoutView)sender).CalcHitInfo(ea.Location);
            if(hitInfo.InCard) {
                var helper = new ColumnViewHelper<TEntity, TID, TUnitOfWork>((ColumnView)sender, ViewModel);
                ea.Handled = helper.EditEntity(hitInfo.RowHandle);
            }
        }
        void LayoutView_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button != MouseButtons.Right || e.Clicks != 1) return;
            DXMouseEventArgs ea = DXMouseEventArgs.GetMouseArgs(e);
            var hitInfo = ((LayoutView)sender).CalcHitInfo(ea.Location);
            if(hitInfo.InCard) {
                var helper = new ColumnViewHelper<TEntity, TID, TUnitOfWork>((ColumnView)sender, ViewModel);
                ea.Handled = helper.ShowEntityMenu(ea.Location, hitInfo.RowHandle);
            }
        }
        void GridView_RowClick(object sender, XtraGrid.Views.Grid.RowClickEventArgs e) {
            if(e.Clicks == 2 && e.Button == MouseButtons.Left) {
                var helper = new ColumnViewHelper<TEntity, TID, TUnitOfWork>((ColumnView)sender, ViewModel);
                e.Handled = helper.EditEntity(e.RowHandle);
            }
        }
        void GridView_PopupMenuShowing(object sender, XtraGrid.Views.Grid.PopupMenuShowingEventArgs e) {
            if(e.MenuType == XtraGrid.Views.Grid.GridMenuType.Row && e.HitInfo.InRowCell) {
                var helper = new ColumnViewHelper<TEntity, TID, TUnitOfWork>((ColumnView)sender, ViewModel);
                helper.PopulateEntityMenu(e.Menu, e.HitInfo.RowHandle);
            }
        }
        #endregion
        public void ReloadEntities() {
            OnReloadEntities();
        }
        public void ReverseSort(GridColumn gridColumn, LayoutViewColumn layoutViewColumn) {
            if(GridControl.MainView == GridView)
                ReverseSort(GridView, gridColumn);
            else
                ReverseSort(LayoutView, layoutViewColumn);
        }
        public void ReverseSort(ColumnView view, GridColumn column) {
            if(view.SortInfo[column] == null) return;
            if(view.SortInfo[column].SortOrder == Data.ColumnSortOrder.Ascending)
                view.SortInfo[column].SortOrder = Data.ColumnSortOrder.Descending;
            else
                view.SortInfo[column].SortOrder = Data.ColumnSortOrder.Ascending;
        }
        public void ExpandCollapseGroups() {
            if(GridControl.MainView == GridView) {
                if(GridView.GetRowExpanded(-1))
                    GridView.CollapseAllGroups();
                else
                    GridView.ExpandAllGroups();
            }
        }
        public void ExpandCollapseMasterRows() {
            if(GridControl.MainView == GridView) {
                if(GridView.GetMasterRowExpanded(0))
                    GridView.CollapseMasterRow(0);
                else
                    GridView.ExpandMasterRow(0);
            }
        }
        DevExpress.XtraBars.BarCheckItem biAddColumns;
        public void AddColumns(DevExpress.XtraBars.BarCheckItem biAddColumns) {
            this.biAddColumns = biAddColumns;
            if(GridControl.MainView == GridView) {
                if(!biAddColumns.Checked)
                    GridView.HideCustomization();
                else {
                    GridView.HideCustomizationForm += GridView_HideCustomizationForm;
                    GridView.ShowCustomization();
                }
            }
        }
        void GridView_HideCustomizationForm(object sender, System.EventArgs e) {
            GridView.HideCustomizationForm -= GridView_HideCustomizationForm;
            if(biAddColumns != null)
                biAddColumns.Checked = false;
            biAddColumns = null;
        }
    }
}
