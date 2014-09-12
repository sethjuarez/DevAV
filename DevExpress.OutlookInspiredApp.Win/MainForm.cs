using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.DevAV.ViewModels;
using DevExpress.Mvvm.POCO;
using DevExpress.OutlookInspiredApp.Win.Modules;
using DevExpress.OutlookInspiredApp.Win.ViewModel;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraNavBar;

namespace DevExpress.OutlookInspiredApp.Win {
    public partial class MainForm : RibbonForm, IMainModule, ISupportViewModel {
        readonly MainViewModel viewModelCore;
        public MainForm() {
            AppHelper.MainForm = this;
            DevExpress.DevAV.StartUpProcess.Start("When Only the Best Will Do");
            InitializeComponent();
            DevExpress.DevAV.StartUpProcess.Running("Initializing...");
            Icon = AppHelper.AppIcon;
            this.viewModelCore = ViewModelSource.Create(() => new MainViewModel(this));
            ViewModel.ModuleAdded += viewModel_ModuleAdded;
            ViewModel.ModuleRemoved += viewModel_ModuleRemoved;
            ViewModel.SelectedModuleTypeChanged += viewModel_SelectedModuleTypeChanged;
            ViewModel.Print += viewModel_Print;
            ViewModel.ShowAllFolders += viewModel_ShowAllFolders;
            ViewModel.IsReadingModeChanged += viewModel_IsReadingModeChanged;
            ribbonControl.MinimizedChanged += Ribbon_MinimizedChanged;
            ribbonControl.ForceInitialize();
            new ZoomLevelManager(beZoomLevel, bbiZoomDialog, ViewModel);
            officeNavigationBar.QueryPeekFormContent += officeNavigationBar_QueryPeekFormContent;
            officeNavigationBar.PopupMenuShowing += officeNavigationBar_PopupMenuShowing;
            navBar.ActiveGroupChanged += navBar_ActiveGroupChanged;
            backstageViewControl.SelectedTabChanged += backstageViewControl_SelectedTabChanged;
            backstageViewControl.Hidden += backstageViewControl_Hidden;
            backstageViewControl.Office2013StyleOptions.HeaderBackColor = ColorHelper.GetControlColor(LookAndFeel);
            backstageViewControl.BackstageViewShowRibbonItems = BackstageViewShowRibbonItems.None;
            BindCommands();
            BindFiltersVisibility();
            InitNotifications();
            InitTaskBarCommands();
            LookAndFeel.StyleChanged += LookAndFeel_StyleChanged;
        }
        public MainViewModel ViewModel {
            get { return viewModelCore; }
        }
        void LookAndFeel_StyleChanged(object sender, EventArgs e) {
            backstageViewControl.Office2013StyleOptions.HeaderBackColor = ColorHelper.GetControlColor(LookAndFeel);
        }
        protected override XtraEditors.FormShowMode ShowMode {
            get { return XtraEditors.FormShowMode.AfterInitialization; }
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            InitializePeekPanels();
            ViewModel.SelectedModuleType = ModuleType.Employees;
            var types = new ModuleType[] { ModuleType.Employees, ModuleType.Customers, ModuleType.Products, ModuleType.Orders, ModuleType.Quotes };
            RegisterNavigationMenuItems(barNavigationItem, types);
            RegisterNavPanes(navBar, types);
            DevExpress.DevAV.StartUpProcess.Running("Successfully loaded.");
        }
        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            DevExpress.DevAV.StartUpProcess.Complete();
        }
        protected override void OnClosed(EventArgs e) {
            ViewModel.SelectedModuleType = ModuleType.Unknown;
            base.OnClosed(e);
        }
        void BindCommands() {
            biGetStarted.BindCommand(() => ViewModel.GetStarted(), ViewModel);
            biGetSupport.BindCommand(() => ViewModel.GetSupport(), ViewModel);
            biBuyNow.BindCommand(() => ViewModel.BuyNow(), ViewModel);
            //
            biAbout.BindCommand(() => ViewModel.About(), ViewModel);
            //
            biBackstageViewGetStarted.BindCommand(() => ViewModel.GetStarted(), ViewModel);
            biBackstageViewGetSupport.BindCommand(() => ViewModel.GetSupport(), ViewModel);
            biBackstageViewBuyNow.BindCommand(() => ViewModel.BuyNow(), ViewModel);
            // Reading Mode
            bbiNormal.BindCommand(() => ViewModel.TurnOffReadingMode(), ViewModel);
            bbiReading.BindCommand(() => ViewModel.TurnOnReadingMode(), ViewModel);
            //
            ((PeekFormButton)officeNavigationBar.OptionsPeekFormButtonPanel.Buttons[0]).BindCommand(() => ViewModel.DockPeekModule(ModuleType.Unknown), ViewModel, () => GetActivePeekModule());
        }
        ModuleType GetActivePeekModule() {
            return (officeNavigationBar.PeekItem != null) ? (ModuleType)officeNavigationBar.PeekItem.Tag : ModuleType.Unknown;
        }
        void viewModel_ModuleAdded(object sender, EventArgs e) {
            var moduleControl = sender as Control;
            moduleControl.Dock = DockStyle.Fill;
            moduleControl.Parent = modulesContainer;
            navBar.SendToBack();
            Text = string.Format("{1} - {0}", ViewModel.GetModuleCaption(ViewModel.SelectedModuleType), "DevAV");
            IRibbonModule ribbonModuleControl = moduleControl as IRibbonModule;
            if(ribbonModuleControl != null) {
                Ribbon.MergeRibbon(ribbonModuleControl.Ribbon);
                Ribbon.StatusBar.MergeStatusBar(ribbonModuleControl.Ribbon.StatusBar);
            }
            else {
                Ribbon.UnMergeRibbon();
                Ribbon.StatusBar.UnMergeStatusBar();
            }
        }
        void viewModel_ModuleRemoved(object sender, EventArgs e) {
            var moduleControl = sender as Control;
            GridHelper.HideCustomization(moduleControl);
            moduleControl.Parent = null;
        }
        void viewModel_SelectedModuleTypeChanged(object sender, EventArgs e) {
            if(ViewModel.SelectedNavPaneModuleType != ModuleType.Unknown)
                navBar.ActiveGroup = GetNavBarGroup(ViewModel.SelectedNavPaneModuleType);
            UpdateCompactLayout(!ribbonControl.Minimized);
        }
        void viewModel_ShowAllFolders(object sender, EventArgs e) {
            navBar.NavPaneShowCollapsedGroupContent();
        }
        void viewModel_IsReadingModeChanged(object sender, EventArgs e) {
            officeNavigationBar.Visible = !ViewModel.IsReadingMode;
            navBar.OptionsNavPane.NavPaneState = ViewModel.IsReadingMode ? NavPaneState.Collapsed : NavPaneState.Expanded;
        }
        void Ribbon_MinimizedChanged(object sender, EventArgs e) {
            UpdateCompactLayout(!ribbonControl.Minimized);
        }
        void UpdateCompactLayout(bool compact) {
            if(ViewModel.SelectedNavPaneModuleType != ModuleType.Unknown)
                UpdateCompactLayout(GetNavPaneModule(ViewModel.SelectedNavPaneModuleType) as ISupportCompactLayout, compact);
            if(ViewModel.SelectedNavPaneHeaderModuleType != ModuleType.Unknown)
                UpdateCompactLayout(GetNavPaneModule(ViewModel.SelectedNavPaneHeaderModuleType) as ISupportCompactLayout, compact);
        }
        void UpdateCompactLayout(ISupportCompactLayout module, bool compact) {
            if(module != null) module.Compact = compact;
        }
        void backstageViewControl_SelectedTabChanged(object sender, BackstageViewItemEventArgs e) {
            if(e.Item == tabBackstageViewExport)
                AddBackStageViewModule(ViewModel.SelectedExportModuleType, tabBackstageViewExport);
            if(e.Item == tabBackstageViewPrint)
                AddBackStageViewModule(ViewModel.SelectedPrintModuleType, tabBackstageViewPrint);
        }
        void viewModel_Print(object sender, PrintEventArgs e) {
            backstageViewControl.SelectedTab = tabBackstageViewPrint;
            ribbonControl.ShowApplicationButtonContentControl();
        }
        void backstageViewControl_Hidden(object sender, EventArgs e) {
            if(backstageViewControl.SelectedTab != tabBackstageViewAbout)
                ViewModel.AfterReportHidden();
            backstageViewControl.SelectedTab = tabBackstageViewAbout;
        }
        void AddBackStageViewModule(ModuleType moduleType, BackstageViewTabItem tabItem) {
            ViewModel.BeforeReportShown(moduleType);
            tabItem.ContentControl.Controls.Clear();
            var moduleControl = GetReportModule(moduleType);
            ViewModel.AfterReportShown(moduleType);
            moduleControl.Dock = DockStyle.Fill;
            moduleControl.Parent = tabItem.ContentControl;
        }
        #region Filters Visibility
        void BindFiltersVisibility() {
            navBar.NavPaneStateChanged += navBar_NavPaneStateChanged;
            ViewModel.ViewFiltersVisibilityChanged += ViewModel_ViewFiltersVisibilityChanged;
            bmiFolderNormal.BindCommand(() => ViewModel.ShowFilters(), ViewModel);
            bmiFolderMinimized.BindCommand(() => ViewModel.MinimizeFilters(), ViewModel);
            bmiFolderOff.BindCommand(() => ViewModel.HideFilters(), ViewModel);
        }
        void navBar_NavPaneStateChanged(object sender, EventArgs e) {
            if(navBar.OptionsNavPane.NavPaneState == NavPaneState.Collapsed)
                ViewModel.FiltersVisibility = CollectionViewFiltersVisibility.Minimized;
            else
                ViewModel.FiltersVisibility = CollectionViewFiltersVisibility.Visible;
        }
        void ViewModel_ViewFiltersVisibilityChanged(object sender, System.EventArgs e) {
            switch(ViewModel.FiltersVisibility) {
                case CollectionViewFiltersVisibility.Visible:
                    navBar.OptionsNavPane.NavPaneState = XtraNavBar.NavPaneState.Expanded;
                    navBar.Visible = true;
                    break;
                case CollectionViewFiltersVisibility.Minimized:
                    navBar.OptionsNavPane.NavPaneState = XtraNavBar.NavPaneState.Collapsed;
                    navBar.Visible = true;
                    break;
                case CollectionViewFiltersVisibility.Hidden:
                    navBar.Visible = false;
                    break;
            }
        }
        #endregion
        #region Services
        bool IsDockedCore(ModuleType peekModuleType) {
            DockPanel panel = GetPanel(peekModuleType);
            return (panel != null) && (panel.Visibility == DockVisibility.Visible);
        }
        bool IPeekModulesHost.IsDocked(ModuleType moduleType) {
            return IsDockedCore(moduleType);
        }
        void IPeekModulesHost.DockModule(ModuleType moduleType) {
            officeNavigationBar.HidePeekForm();
            DockPanel panel = GetPanel(moduleType);
            if(panel != null) panel.Restore();
        }
        void IPeekModulesHost.UndockModule(ModuleType moduleType) {
            DockPanel panel = GetPanel(moduleType);
            if(panel != null) panel.Close();
        }
        void IPeekModulesHost.ShowPeek(ModuleType moduleType) {
            officeNavigationBar.ShowPeekForm(GetNavigationBarItem(moduleType));
        }
        void ISupportTransitions.StartTransition(bool forward, object waitParameter) {
            var transition = transitionManager.Transitions[modulesContainer];
            var animator = transition.TransitionType as DevExpress.Utils.Animation.SlideFadeTransition;
            animator.Parameters.EffectOptions = forward ? Utils.Animation.PushEffectOptions.FromRight : Utils.Animation.PushEffectOptions.FromLeft;
            if(waitParameter == null)
                transition.ShowWaitingIndicator = DefaultBoolean.False;
            else {
                transition.ShowWaitingIndicator = DefaultBoolean.True;
                transition.WaitingIndicatorProperties.Caption = DevExpress.XtraEditors.EnumDisplayTextHelper.GetDisplayText(waitParameter);
                transition.WaitingIndicatorProperties.Description = "Loading...";
                transition.WaitingIndicatorProperties.ContentMinSize = new System.Drawing.Size(160, 0);
            }
            transitionManager.StartTransition(modulesContainer);
        }
        void ISupportTransitions.EndTransition() {
            transitionManager.EndTransition();
        }
        void ISupportModuleLayout.SaveLayoutToStream(MemoryStream ms) {
            dockManager.SaveLayoutToStream(ms);
        }
        void ISupportModuleLayout.RestoreLayoutFromStream(MemoryStream ms) {
            dockManager.RestoreLayoutFromStream(ms);
        }
        #endregion Services
        #region Navigation Menu
        void RegisterNavigationMenuItems(BarLinkContainerItem menuItem, ModuleType[] types) {
            for(int i = 0; i < types.Length; i++)
                RegisterNavigationMenuItem(menuItem, types[i]);
        }
        void RegisterNavigationMenuItem(BarLinkContainerItem menuItem, ModuleType type) {
            BarCheckItem biModule = new BarCheckItem();
            biModule.Caption = ViewModel.GetModuleCaption(type);
            biModule.Name = "biModule" + ViewModel.GetModuleName(type);
            biModule.Glyph = (System.Drawing.Image)ViewModel.GetModuleImage(type);
            biModule.GroupIndex = 1;
            biModule.BindCommand((t) => ViewModel.SelectModule(t), ViewModel, () => type);
            menuItem.AddItem(biModule);
        }
        #endregion Navigation Menu
        #region Navigation Bar
        void RegisterNavPanes(NavBarControl navBar, ModuleType[] types) {
            for(int i = 0; i < types.Length; i++)
                RegisterNavPane(navBar, ViewModel.GetNavPaneModuleType(types[i]));
            officeNavigationBar.RegisterItem += officeNavigationBar_RegisterItem;
            officeNavigationBar.NavigationClient = navBar;
        }
        void RegisterNavPane(NavBarControl navBar, ModuleType type) {
            NavBarGroup navGroup = new NavBarGroup();
            navGroup.Tag = type;
            navGroup.Name = "navGroup" + ViewModel.GetModuleName(type);
            navGroup.Caption = ViewModel.GetModuleCaption(type);
            navGroup.LargeImage = (System.Drawing.Image)ViewModel.GetModuleImage(type);
            navGroup.GroupStyle = NavBarGroupStyle.ControlContainer;
            navGroup.ControlContainer = new NavBarGroupControlContainer();
            navBar.Controls.Add(navGroup.ControlContainer);
            navBar.Groups.Add(navGroup);
        }
        void officeNavigationBar_RegisterItem(object sender, NavigationBarNavigationClientItemEventArgs e) {
            NavBarGroup navGroup = (NavBarGroup)e.NavigationItem;
            var type = ViewModel.GetMainModuleType((ModuleType)navGroup.Tag);
            e.Item.Tag = ViewModel.GetPeekModuleType(type);
            e.Item.Text = ViewModel.GetModuleCaption(type);
            e.Item.Name = "navItem" + ViewModel.GetModuleName(type);
            if(type == ModuleType.Orders || type == ModuleType.Quotes)
                e.Item.ShowPeekFormOnItemHover = Utils.DefaultBoolean.False;
            e.Item.BindCommand((t) => ViewModel.SelectModule(t), ViewModel, () => type);
        }
        void officeNavigationBar_QueryPeekFormContent(object sender, QueryPeekFormContentEventArgs e) {
            ModuleType peekModuleType = (ModuleType)e.Item.Tag;
            if(!IsDockedCore(peekModuleType))
                e.Control = GetModule(peekModuleType);
        }
        void officeNavigationBar_PopupMenuShowing(object sender, NavigationBarPopupMenuShowingEventArgs e) {
            if(e.MenuKind == NavigationBarMenuKind.Item) {
                if(e.Item.ShowPeekFormOnItemHover != Utils.DefaultBoolean.False)
                    CreateMenu(e.Menu, (ModuleType)e.Item.Tag);
                else e.Cancel = true;
            }
        }
        void CreateMenu(DevExpress.Utils.Menu.DXPopupMenu menu, ModuleType peekModuleType) {
            if(IsDockedCore(peekModuleType)) {
                var undockItem = new DevExpress.Utils.Menu.DXMenuItem();
                undockItem.Caption = "Hide the peek";
                undockItem.BindCommand((t) => ViewModel.UndockPeekModule(t), ViewModel, () => peekModuleType);
                menu.Items.Add(undockItem);
            }
            else {
                var dockItem = new DevExpress.Utils.Menu.DXMenuItem();
                dockItem.Caption = "Dock the peek";
                dockItem.BindCommand((t) => ViewModel.DockPeekModule(t), ViewModel, () => peekModuleType);
                var showItem = new DevExpress.Utils.Menu.DXMenuItem();
                showItem.Caption = "Show the peek";
                showItem.BindCommand((t) => ViewModel.ShowPeekModule(t), ViewModel, () => peekModuleType);
                menu.Items.Add(dockItem);
                menu.Items.Add(showItem);
            }
        }
        void navBar_ActiveGroupChanged(object sender, NavBarGroupEventArgs e) {
            var navPaneModuleType = (ModuleType)e.Group.Tag;
            if(ViewModel.SelectedNavPaneModuleType != navPaneModuleType)
                ViewModel.SelectedModuleType = ViewModel.GetMainModuleType(navPaneModuleType);
            Control moduleControl = GetNavPaneModule(navPaneModuleType);
            moduleControl.Dock = DockStyle.Fill;
            e.Group.ControlContainer.Controls.Add(moduleControl);

            var collapsedGroupModuleType = ViewModel.GetNavPaneModuleType(navPaneModuleType, true);
            e.Group.CollapsedNavPaneContentControl = GetNavPaneModule(collapsedGroupModuleType);
        }
        #endregion Navigation Bar
        #region Peek Panels
        void InitializePeekPanels() {
            var types = new ModuleType[] { ModuleType.Employees, ModuleType.Customers, ModuleType.Products };
            new PeekPanelsRegistrator(ViewModel).RegisterPeekPanels(dockManager, types);
        }
        class PeekPanelsRegistrator {
            MainViewModel viewModel;
            public PeekPanelsRegistrator(MainViewModel viewModel) {
                this.viewModel = viewModel;
            }
            public void RegisterPeekPanels(DockManager dockManager, ModuleType[] types) {
                dockManager.ClosedPanel += dockManager_ClosedPanel;
                dockManager.VisibilityChanged += dockManager_VisibilityChanged;
                dockManager.StartDocking += dockManager_StartDocking;
                dockManager.BeginInit();
                RegisterPeekPanelsCore(dockManager, Array.ConvertAll(types, viewModel.GetPeekModuleType));
                dockManager.EndInit();
            }
            void RegisterPeekPanelsCore(DockManager dockManager, ModuleType[] types) {
                for(int i = 0; i < types.Length; i++)
                    RegisterPeekPanel(dockManager, types[i]);
            }
            void RegisterPeekPanel(DockManager dockManager, ModuleType type) {
                var panel = new DockPanel();
                panel.ID = viewModel.GetModuleID(type);
                panels.Add(panel.ID, type);
                panel.Name = "peekPanel" + viewModel.GetModuleName(type);
                panel.Options.AllowDockBottom = false;
                panel.Options.AllowDockLeft = false;
                panel.Options.AllowDockTop = false;
                panel.Options.AllowFloating = false;
                panel.Text = viewModel.GetModuleCaption(type);
                panel.Visibility = DockVisibility.Hidden;
                panel.SavedDock = DockingStyle.Right;
                panel.OriginalSize = new System.Drawing.Size(200, 200);
                if(dockManager.HiddenPanels.Count > 0) {
                    panel.SavedParent = dockManager.HiddenPanels[0];
                    panel.Dock = DockingStyle.Fill;
                    panel.SavedDock = DockingStyle.Fill;
                    panel.SavedIndex = dockManager.HiddenPanels.Count - 1;
                }
                var container = new ControlContainer();
                container.Name = panel.Name + "_ControlContainer";
                panel.Controls.Add(container);
                panel.Register(dockManager);
                dockManager.HiddenPanels.AddRange(new DockPanel[] { panel });
            }
            void dockManager_StartDocking(object sender, DockPanelCancelEventArgs e) {
                e.Cancel = true;
            }
            void dockManager_VisibilityChanged(object sender, VisibilityChangedEventArgs e) {
                if(e.Visibility == DockVisibility.Visible && panels.ContainsKey(e.Panel.ID)) {
                    Control module = GetPeekModuleControl(e.Panel);
                    ViewModelHelper.EnsureModuleViewModel(module, viewModel);
                    module.Dock = DockStyle.Fill;
                    e.Panel.ControlContainer.Controls.Add(module);
                }
            }
            void dockManager_ClosedPanel(object sender, DockPanelEventArgs e) {
                Control module = GetPeekModuleControl(e.Panel);
                e.Panel.ControlContainer.Controls.Remove(module);
            }
            static IDictionary<Guid, ModuleType> panels = new Dictionary<Guid, ModuleType>();
            Control GetPeekModuleControl(DockPanel panel) {
                return viewModel.GetModule(panels[panel.ID]) as Control;
            }
        }
        #endregion Peek Panels
        DockPanel GetPanel(ModuleType peekModuleType) {
            var id = ViewModel.GetModuleID(peekModuleType);
            return dockManager.Panels.Concat(dockManager.HiddenPanels)
                .FirstOrDefault(p => p.ID == id);
        }
        NavigationBarItem GetNavigationBarItem(ModuleType peekModuleType) {
            return officeNavigationBar.Items
                .FirstOrDefault(item => object.Equals(item.Tag, peekModuleType));
        }
        NavBarGroup GetNavBarGroup(ModuleType navPaneModuleType) {
            return navBar.Groups
                .FirstOrDefault(g => object.Equals(g.Tag, navPaneModuleType));
        }
        Control GetModule(ModuleType moduleType) {
            Control moduleControl = ViewModel.GetModule(moduleType) as Control;
            ViewModelHelper.EnsureModuleViewModel(moduleControl, ViewModel);
            return moduleControl;
        }
        Control GetNavPaneModule(ModuleType navPaneModuleType) {
            Control moduleControl = ViewModel.GetModule(navPaneModuleType, ViewModel.SelectedModuleViewModel) as Control;
            ViewModelHelper.EnsureModuleViewModel(moduleControl, ViewModel);
            return moduleControl;
        }
        Control GetReportModule(ModuleType moduleType) {
            Control moduleControl = ViewModel.GetModule(moduleType) as Control;
            ViewModelHelper.EnsureModuleViewModel(moduleControl, ViewModel.SelectedModuleViewModel, ViewModel.ReportParameter);
            return moduleControl;
        }
        #region ISupportViewModel
        object ISupportViewModel.ViewModel { get { return viewModelCore; } }
        void ISupportViewModel.ParentViewModelAttached() { }
        #endregion
        #region Notifications
        Timer notificationsTimer;
        DevExpress.XtraBars.Alerter.AlertControl alertControl;
        void InitNotifications() {
            if(CanUseToastNotifications()) {
                notificationManager.TryCreateApplicationShortcut();
                notificationManager.Activated += notificationsManager_Activated;
            }
            else {
                alertControl = new XtraBars.Alerter.AlertControl();
                alertControl.AllowHtmlText = true;
                alertControl.FormLocation = XtraBars.Alerter.AlertFormLocation.TopRight;
                alertControl.ShowPinButton = false;
                alertControl.AlertClick += alertControl_AlertClick;
            }
            EnsureNotificationsTimer();
        }
        void EnsureNotificationsTimer() {
            if(notificationsTimer == null) {
                notificationsTimer = new Timer();
                notificationsTimer.Interval = 15000;
                notificationsTimer.Tick += notificationsTimer_Tick;
            }
            notificationsTimer.Start();
        }
        void DestroyNotificationsTimer() {
            notificationsTimer.Stop();
            notificationsTimer.Tick -= notificationsTimer_Tick;
            notificationsTimer.Dispose();
            notificationsTimer = null;
        }
        int notificationsCount;
        void notificationsTimer_Tick(object sender, EventArgs e) {
            if(notificationsCount < notificationManager.Notifications.Count) {
                notificationsTimer.Interval = 5000;
                ShowNotification(notificationsCount++);
            }
            else DestroyNotificationsTimer();
        }
        void alertControl_AlertClick(object sender, XtraBars.Alerter.AlertClickEventArgs e) {
            object notificationID = e.Info.Tag;
            e.AlertForm.Close();
            OnNotificationClick(notificationID);
        }
        void notificationsManager_Activated(object sender, XtraBars.ToastNotifications.ToastNotificationEventArgs e) {
            OnNotificationClick(e.NotificationID);
        }
        bool CanUseToastNotifications() {
            return DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager.AreToastNotificationsSupported;
        }
        void ShowNotification(int index) {
            var notification = notificationManager.Notifications[index];
            if(CanUseToastNotifications())
                notificationManager.ShowNotification(notification);
            else {
                string alertCaption = "<b>" + notification.Header + "</b>";
                string alertText = notification.Body + " " + notification.Body2;
                alertControl.Show(this, new XtraBars.Alerter.AlertInfo(alertCaption, alertText, AppHelper.AppImage) { Tag = notification.ID });
            }
        }
        void OnNotificationClick(object notificationID) {
            var backstageViewForm = backstageViewControl.FindForm();
            if(backstageViewForm != null) {
                backstageViewForm.Hide();
                ribbonControl.HideApplicationButtonContentControl();
            }
            if(notificationID == notificationManager.Notifications[0].ID) {
                ViewModel.SelectedModuleType = ModuleType.Orders;
            }
            if(notificationID == notificationManager.Notifications[1].ID) {
                ISupportMap supportMap = ViewModel.SelectedModuleViewModel as ISupportMap;
                if(supportMap != null) supportMap.ShowMap();
            }
            if(notificationID == notificationManager.Notifications[2].ID) {
                ViewModel.SelectedModuleType = ModuleType.Products;
            }
            if(notificationID == notificationManager.Notifications[3].ID) {
                if(!(ViewModel.SelectedModuleViewModel is ISupportAnalysis))
                    ViewModel.SelectedModuleType = ModuleType.Customers;
                ISupportAnalysis supportAnalysis = ViewModel.SelectedModuleViewModel as ISupportAnalysis;
                if(supportAnalysis != null) supportAnalysis.ShowAnalysis();
            }
        }
        #endregion Notifications
        #region TaskBar
        void InitTaskBarCommands() {
            taskbarAssistant.IconsAssembly = "DevExpress.OutlookInspiredApp.Win.exe";
            taskNewEmployee.Click += taskNewEmployee_Click;
            taskSalesMap.Click += taskSalesMap_Click;
            taskOpportunities.Click += taskOpportunities_Click;
        }
        void taskNewEmployee_Click(object sender, EventArgs e) {
            ViewModel.SelectedModuleType = ModuleType.Employees;
            var collection = ViewModel.SelectedModuleViewModel as EmployeeCollectionViewModel;
            if(collection != null)
                collection.New();
        }
        void taskSalesMap_Click(object sender, EventArgs e) {
            ViewModel.SelectedModuleType = ModuleType.Products;
            var collection = ViewModel.SelectedModuleViewModel as ProductCollectionViewModel;
            if(collection != null)
                collection.ShowMap();
        }
        void taskOpportunities_Click(object sender, EventArgs e) {
            ViewModel.SelectedModuleType = ModuleType.Quotes;
        }
        #endregion TaskBar
    }
}
