using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.OutlookInspiredApp.Win.ViewModel;
using DevExpress.XtraLayout.Utils;
using DevExpress.OutlookInspiredApp.Win.Presenters;

namespace DevExpress.OutlookInspiredApp.Win.Modules
{
    public partial class DashboardsFilterPane : BaseModuleControl, ISupportCompactLayout
    {
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
        public FileListPresenter Presenter
        {
            get { return presenterCore; }
        }

        protected virtual FileListPresenter CreatePresenter()
        {
            return new FileListPresenter(treeList, ViewModel);
        }

        private void BindCommands()
        {
            btnNewDashboard.BindCommand(() => ViewModel.ParentViewModel.ShowNewDashboard(), ViewModel.ParentViewModel);
        }

        bool compactLayout = true;
        private readonly FileListPresenter presenterCore;

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
