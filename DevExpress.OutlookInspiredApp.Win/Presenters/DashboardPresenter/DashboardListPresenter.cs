using System;
using System.IO;
using System.Linq;
using DevExpress.Mvvm;
using DevExpress.XtraTreeList;
using System.Collections.Generic;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.OutlookInspiredApp.Win.ViewModel;

namespace DevExpress.OutlookInspiredApp.Win.Presenters
{
    public class DashboardListPresenter
    {
        private readonly TreeList _tree;
        private readonly DashboardsFilterPaneViewModel _viewModel;

        public DashboardListPresenter(TreeList tree, DashboardsFilterPaneViewModel viewModel)
        {
            _viewModel = viewModel;
            _tree = tree;
            InitTree();
            PopulateTree();
            Messenger.Default.Register<DashboardMessage>(this, OnDashboardMessage);
        }

        private void OnDashboardMessage(DashboardMessage message)
        {
            // refresh tree
            if (message.MessageType == DashboardMessageType.Refresh)
                PopulateTree();
        }

        public DashboardsFilterPaneViewModel ViewModel
        {
            get
            {
                return _viewModel;
            }
        }

        private void InitTree()
        {
            _tree.OptionsView.ShowColumns = false;
            _tree.OptionsView.ShowHorzLines = false;
            _tree.OptionsView.ShowVertLines = false;
            _tree.OptionsView.ShowIndicator = false;
            _tree.OptionsSelection.UseIndicatorForSelection = false;


            _tree.OptionsBehavior.DragNodes = true;
            _tree.OptionsBehavior.Editable = false;

            _tree.BeginUpdate();
            var column = _tree.Columns.Add();
            column.Caption = "Main";
            column.VisibleIndex = 0;
            _tree.EndUpdate();

            _tree.DoubleClick += tree_DoubleClick;

        }

        private void tree_DoubleClick(object sender, EventArgs e)
        {
            if (_tree.Selection.Count > 0 && _tree.Selection[0].Tag.ToString().EndsWith(".xml"))
                _viewModel.SelectedDashboard = _tree.Selection[0].Tag.ToString();
        }

        private void PopulateTree()
        {
            _tree.Nodes.Clear();
            foreach (var dashboard in ViewModel.ParentViewModel.Dashboards)
                AddNode(Path.GetFileNameWithoutExtension(dashboard), dashboard, null);

            if (ViewModel.ParentViewModel.Dashboards.Length > 0 && 
                string.IsNullOrEmpty(ViewModel.SelectedDashboard))
                ViewModel.SelectedDashboard = _tree.Nodes.FirstNode.Tag.ToString();
        }

        public TreeListNode AddNode(string name, object tag = null, TreeListNode parent = null)
        {
            var node = _tree.AppendNode(new object[] { name }, parent);
            node.Tag = tag;
            return node;
        }
    }
}
