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
        void checkedComboBoxEdit1_EditValueChanged(object sender, EventArgs e) {
            if(callback != null) callback((string)checkedComboBoxEdit1.EditValue);
        }
    }
}
