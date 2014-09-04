using DevExpress.OutlookInspiredApp.Win.ViewModel;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevExpress.OutlookInspiredApp.Win.Presenters
{
    public class FileListPresenter
    {
        private readonly TreeList _tree;
        private readonly DashboardsFilterPaneViewModel _viewModel;
        
        public FileListPresenter(TreeList tree, DashboardsFilterPaneViewModel viewModel)
        {
            _viewModel = viewModel;
            _tree = tree;
            InitTree();
            PopulateTree();
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
        }
        private void PopulateTree()
        {
            _tree.Nodes.Clear();
            AddNode("Test 1");
            AddNode("Test 2");
            AddNode("Test 3");
            
        }

        public TreeListNode AddNode(string name, TreeListNode parent = null)
        {
            var node = _tree.AppendNode(new object[] { name }, parent);
            node.Selected = true;
            return node;

        }
    }
}
