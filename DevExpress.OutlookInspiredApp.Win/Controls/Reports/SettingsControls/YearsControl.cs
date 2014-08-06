using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace DevExpress.OutlookInspiredApp.Win {
    public partial class YearsControl : UserControl {
        Action<string> callback;
        string defaultValue;
        public YearsControl() {
            InitializeComponent();
        }
        public YearsControl(Action<string> callback, string defaultValue)
            : this() {
            this.defaultValue = defaultValue;
            this.callback = callback;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            checkedComboBoxEdit1.EditValue = defaultValue;
        }
        private void checkedComboBoxEdit1_EditValueChanged(object sender, EventArgs e) {
            callback((string)checkedComboBoxEdit1.EditValue);
        }
    }
}
