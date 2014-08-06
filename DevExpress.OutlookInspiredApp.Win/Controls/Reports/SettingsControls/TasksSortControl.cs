using System;
using System.Windows.Forms;

namespace DevExpress.OutlookInspiredApp.Win {
    public partial class TasksSortControl : UserControl {
        Action<bool> callback;
        bool defaultValue;
        public TasksSortControl() {
            InitializeComponent();
        }
        public TasksSortControl(Action<bool> callback, bool defaultValue)
            : this() {
            this.callback = callback;
            this.defaultValue = defaultValue;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            if(defaultValue) btnDueDate.Checked = true;
            else btnStartDate.Checked = true;
        }
        private void btnDueDate_CheckedChanged(object sender, EventArgs e) {
            callback(true);
        }
        private void btnStartDate_CheckedChanged(object sender, EventArgs e) {
            callback(false);
        }
    }
}
