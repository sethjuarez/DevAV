using System;
using System.Linq;
using System.Collections.Generic;
using DevExpress.XtraLayout.Utils;
using DevExpress.OutlookInspiredApp.Win.ViewModel;
using DevExpress.OutlookInspiredApp.Win.Presenters;

namespace DevExpress.OutlookInspiredApp.Win.Modules
{
    public partial class DashboardsPane : BaseModuleControl, ISupportCompactLayout
    {
        private readonly DashboardsPanePresenter presenterCore;

        public DashboardsPane(DashboardsViewModel viewModel)
            : base(() => CreateViewModel(() => new DashboardsPaneViewModel(viewModel)))
        {
            InitializeComponent();
            FiltersTreeListAppearances.Apply(treeList);
            presenterCore = CreatePresenter();
        }

        protected override void OnParentViewModelAttached()
        {
            BindCommands();
        }


        public DashboardsPaneViewModel ViewModel
        {
            get { return GetViewModel<DashboardsPaneViewModel>(); }
        }

        public DashboardsPanePresenter Presenter
        {
            get { return presenterCore; }
        }

        protected virtual DashboardsPanePresenter CreatePresenter()
        {
            return new DashboardsPanePresenter(treeList, ViewModel);
        }

        private void BindCommands()
        {

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

        private void UpdateCompactLayout()
        {
            btnNewDashboardsLayoutControlItem.Visibility = compactLayout ? LayoutVisibility.Never : LayoutVisibility.Always;
        }
    }
}
