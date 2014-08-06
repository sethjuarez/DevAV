namespace DevExpress.OutlookInspiredApp.Win {
    using System.Windows.Forms;
    using DevExpress.Mvvm;
    using DevExpress.XtraEditors;

    public class MessageBoxService : IMessageBoxService {
        System.Windows.MessageBoxResult IMessageBoxService.Show(
            string messageBoxText, string caption,
            System.Windows.MessageBoxButton button,
            System.Windows.MessageBoxImage icon,
            System.Windows.MessageBoxResult defaultResult) {
            return Convert(XtraMessageBox.Show(messageBoxText, caption, Convert(button), Convert(icon), Convert(defaultResult, button)));
        }
        static MessageBoxButtons Convert(System.Windows.MessageBoxButton button) {
            return (MessageBoxButtons)(int)button;
        }
        static MessageBoxIcon Convert(System.Windows.MessageBoxImage icon) {
            return (MessageBoxIcon)(int)icon;
        }
        static System.Windows.MessageBoxResult Convert(DialogResult result) {
            return (System.Windows.MessageBoxResult)(int)result;
        }
        static MessageBoxDefaultButton Convert(System.Windows.MessageBoxResult result, System.Windows.MessageBoxButton buttons) {
            switch(result) {
                case System.Windows.MessageBoxResult.No: 
                    return MessageBoxDefaultButton.Button2;
                case System.Windows.MessageBoxResult.Cancel: 
                    return buttons == System.Windows.MessageBoxButton.OKCancel ? 
                        MessageBoxDefaultButton.Button2 : MessageBoxDefaultButton.Button3;
                default: 
                    return MessageBoxDefaultButton.Button1;
            }
        }
    }
}
