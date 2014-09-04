using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;
using DevExpress.OutlookInspiredApp.Win.ViewModel;

namespace DevExpress.OutlookInspiredApp.Win.Modules
{
    public partial class Dashboards : BaseModuleControl, IRibbonModule
    {
        public Dashboards()
            : base(CreateViewModel<DashboardsViewModel>)
        {
            InitializeComponent();
        }

        public RibbonControl Ribbon
        {
            get { return ribbonControl1; }
        }
    }
}
