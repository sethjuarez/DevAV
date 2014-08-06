namespace DevExpress.OutlookInspiredApp.Win {
    using System;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using DevExpress.DevAV;
    using DevExpress.Internal;

    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            AppDomain.CurrentDomain.AssemblyResolve += OnCurrentDomainAssemblyResolve;
            DataDirectoryHelper.LocalPrefix = "WinOutlookInspiredApp";
            bool exit;
            using(IDisposable singleInstanceApplicationGuard = DataDirectoryHelper.SingleInstanceApplicationGuard("DevExpressWinOutlookInspiredApp", out exit)) {
                if(exit) return;
                //DevExpress.UserSkins.BonusSkins.Register();
                DevExpress.XtraEditors.WindowsFormsSettings.SetDPIAware();
                DevExpress.XtraEditors.WindowsFormsSettings.EnableFormSkins();
                DevExpress.XtraEditors.WindowsFormsSettings.DefaultLookAndFeel.SetSkinStyle("Office 2013 Light Gray");
                DevExpress.XtraEditors.WindowsFormsSettings.AllowPixelScrolling = Utils.DefaultBoolean.True;
                DevExpress.XtraEditors.WindowsFormsSettings.ScrollUIMode = XtraEditors.ScrollUIMode.Touch;
                DevExpress.Utils.AppearanceObject.DefaultFont = new Font("Segoe UI", AppHelper.GetDefaultSize());
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                using(new StartUpProcess()) {
                    using(StartUpProcess.Status.Subscribe(new DemoStartUp())) {
                        Application.Run(new MainForm());
                    }
                }
            }
        }
        static Assembly OnCurrentDomainAssemblyResolve(object sender, ResolveEventArgs args) {
            if(DevExpress.Utils.AssemblyHelper.GetPartialName(args.Name) == "EntityFramework") {
                string path = Path.Combine(Path.GetDirectoryName(typeof(Program).Assembly.Location), "EntityFramework.dll");
                return Assembly.LoadFrom(path);
            }
            return null;
        }
    }
}
