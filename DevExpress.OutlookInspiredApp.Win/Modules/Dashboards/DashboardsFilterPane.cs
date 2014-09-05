using System;
using System.Linq;
using System.Collections.Generic;
using DevExpress.XtraLayout.Utils;
using DevExpress.OutlookInspiredApp.Win.ViewModel;
using DevExpress.OutlookInspiredApp.Win.Presenters;

namespace DevExpress.OutlookInspiredApp.Win.Modules
{
    public partial class DashboardsFilterPane : BaseModuleControl, ISupportCompactLayout
    {
        private readonly DashboardListPresenter presenterCore;

        public DashboardsFilterPane(DashboardsViewModel viewModel)
            : base(() => CreateViewModel(() => new DashboardsFilterPaneViewModel(viewModel)))
        {
            InitializeComponent();
            FiltersTreeListAppearances.Apply(treeList);
            presenterCore = CreatePresenter();
        }

        protected override void OnParentViewModelAttached()
        {
            BindCommands();
        }


        public DashboardsFilterPaneViewModel ViewModel
        {
            get { return GetViewModel<DashboardsFilterPaneViewModel>(); }
        }

        public DashboardListPresenter Presenter
        {
            get { return presenterCore; }
        }

        protected virtual DashboardListPresenter CreatePresenter()
        {
            return new DashboardListPresenter(treeList, ViewModel);
        }

        private void BindCommands()
        {
            btnNewDashboard.BindCommand(() => ViewModel.ParentViewModel.ShowNewDashboard(), ViewModel.ParentViewModel);
        }

        bool compactLayout = true;

        bool ISupportCompactLayout.Compact
        {
            get { return compactLayout; }
            set
            {
                if (compactLayout == value) return;
                compactLayout = value;
                UpdateCompactLayout();
            }
        }

        void UpdateCompactLayout()
        {
            btnNewDashboardLayoutControlItem.Visibility = compactLayout ? LayoutVisibility.Never : LayoutVisibility.Always;
        }
    }
}
