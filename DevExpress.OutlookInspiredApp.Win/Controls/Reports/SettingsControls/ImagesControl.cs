using System;
using System.Windows.Forms;

namespace DevExpress.OutlookInspiredApp.Win {
    public partial class ImagesControl : UserControl {
        Action<bool> callback;
        bool defaultValue;
        public ImagesControl() {
            InitializeComponent();
        }
        public ImagesControl(Action<bool> callback, bool defaultValue)
            : this() {
            this.callback = callback;
            this.defaultValue = defaultValue;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            if(defaultValue) btnDisplayImages.Checked = true;
            else btnHideImages.Checked = true;
        }
        private void btnDisplayImages_CheckedChanged(object sender, EventArgs e) {
            callback(true);
        }
        private void btnHideImages_CheckedChanged(object sender, EventArgs e) {
            callback(false);
        }
    }
}
