using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace DevExpress.OutlookInspiredApp.Win {
    public partial class SortFilterControl : UserControl {
        Action<bool> callback;
        Action<DateTime> toDate, fromDate;
        DateTime defaultFromDate, defaultToDate;
        bool defaultValue;
        public SortFilterControl() {
            InitializeComponent();
        }
        public SortFilterControl(Action<bool> callback, bool defaultValue, Action<DateTime> fromDate, DateTime defaultFromDate, Action<DateTime> toDate, DateTime defaultToDate)
            : this() {
            this.callback = callback;
            this.toDate = toDate;
            this.fromDate = fromDate;
            this.defaultValue = defaultValue;
            this.defaultFromDate = defaultFromDate;
            this.defaultToDate = defaultToDate;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            if(defaultValue) btnOrderDate.Checked = true;
            else btnInvoice.Checked = true;

            dateEdit1.DateTime = defaultFromDate;
            dateEdit2.DateTime = defaultToDate;
        }
        private void btnOrderDate_CheckedChanged(object sender, EventArgs e) {
            callback(true);
        }
        private void btnInvoice_CheckedChanged(object sender, EventArgs e) {
            callback(false);
        }
        private void dateEdit1_DateTimeChanged(object sender, EventArgs e) {
            fromDate((sender as DateEdit).DateTime);
        }

        private void dateEdit2_DateTimeChanged(object sender, EventArgs e) {
            toDate((sender as DateEdit).DateTime);
        }
    }
}
