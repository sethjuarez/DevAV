using System;
using System.Windows.Forms;

namespace DevExpress.OutlookInspiredApp.Win {
    public partial class EvaluationsControl : UserControl {
        Action<bool> callback;
        bool defaultValue;
        public EvaluationsControl() {
            InitializeComponent();
        }
        public EvaluationsControl(Action<bool> callback, bool defaultValue)
            : this() {
            this.callback = callback;
            this.defaultValue = defaultValue;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            if(defaultValue) btnIncludeEvaluations.Checked = true;
            else btnExcludeEvaluations.Checked = true;
        }
        private void btnAscendingOrder_CheckedChanged(object sender, EventArgs e) {
            callback(true);
        }
        private void btnDescendingOrder_CheckedChanged(object sender, EventArgs e) {
            callback(false);
        }
    }
}
