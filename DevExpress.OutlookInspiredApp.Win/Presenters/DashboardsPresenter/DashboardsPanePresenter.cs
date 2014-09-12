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
    public class DashboardsPanePresenter : BasePresenter<DashboardsPaneViewModel>
    {
        private readonly TreeList _tree;
        public DashboardsPanePresenter(TreeList tree, DashboardsPaneViewModel viewModel)
            : base(viewModel)
        {
            _tree = tree;
            InitTree();
            PopulateTree();
        }

        private void InitTree()
        {
            _tree.BeginUpdate();
            var column = _tree.Columns.Add();
            column.Caption = "Main";
            column.VisibleIndex = 0;
            _tree.EndUpdate();
            _tree.DoubleClick += _tree_DoubleClick;
        }

        void _tree_DoubleClick(object sender, EventArgs e)
        {
            if (_tree.Selection.Count > 0 && _tree.Selection[0].Tag.ToString().EndsWith(".xml"))
            {
                var viewModel = ViewModel.ParentViewModel;
                viewModel.CurrentDashboard = _tree.Selection[0].Tag.ToString();

                Messenger.Default.Send<DashboardMessage>(DashboardMessage.View());
            }
        }

        private void PopulateTree()
        {
            _tree.Nodes.Clear();
            var viewModel = ViewModel.ParentViewModel;
            foreach (var d in viewModel.Dashboards)
                AddNode(Path.GetFileNameWithoutExtension(d), d, null);
        }
        

        public TreeListNode AddNode(string name, object tag = null, TreeListNode parent = null)
        {
            var node = _tree.AppendNode(new object[] { name }, parent);
            node.Tag = tag;
            return node;
        }
    }
}
