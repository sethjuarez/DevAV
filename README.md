## Get Basic Modules Up ##
1. Add Dashboards Module
2. Add DashboardsPane Pane Module
3. Add Modules to Interfaces.cs `ModuleType` enum (**ViewModel**)
3. Add type to ModuleType in MainForm.cs
4. Add new Modules to ModuleTypesResolver in `GetId`, `GetMainModule`, and `GetNavPaneModuleType` (**Services**)
4. **RUN** (note bad title)
5. Add string to `ModuleResourceProvider` (**Services**)
6. **RUN** again!

## Adding First Dashboard ##
1. Add data to DashboardsViewModel using the `dashdata` template.
2. Add basic code to DashboardViewModel using the `dashvm` template.
3. Drop DashboardViewer into Dashboard
4. Change view object in Presenter constructor to `DashboardViewer`
5. Wire up CurrentDashboard in DashboardsPresenter using the `dashbind` template.

## Working with the List Presenter ##
1. Go to DashboardPanePresenter and add PopulateTree method using `dashlist`
2. Add event handler for _tree.DoubleClick
3. Add if statement with `dashlif`
4. Add code

    	var viewModel = ViewModel.ParentViewModel;
    	viewModel.CurrentDashboard = _tree.Selection[0].Tag.ToString();

5. Add Message type to DashboardViewModel using `dashmsg` (creates types for dashboard messages)
6. Add Message sender to event

		Messenger.Default.Send<DashboardMessage>(DashboardMessage.View());

7. Register message in DashboardsPresenter

		Messenger.Default.Register<DashboardMessage>(this, OnDashboardMessage);

8. Add appropriate method as well as call to `BindDashboard()`
9. **RUN**

## New & Edit Window
1. Add **New** and **Edit** buttons to Dashboard (use [icon new opportunities] and [icon edit]
2. Add code to BindCommands using `dashevt` template.
3. Add methods using CodeRush to ViewModel, decorate with `[Command]` attribute.
4. Add Form open code using `dashform` (will add ServiceProperty and Open command)
5. Go to DetailFormDocumentManagerService and add "Dashboard" to `GetActualViewModuleType` (**Services**, line 134)

        if (documentType == "Dashboard")
        {
            var resolver = GetService<Services.IModuleTypesResolver>(parentViewModel);
            return resolver.GetDashboardModuleType(viewModuleType);
        }

6. Add appropriate `GetDashboardModuleType` function to interface and class
7. Modify `NewDashboard` and `EditDashboard` functions using `dashcmd` (overwrite)

        [Command]
        public void NewDashboard()
        {
            Dashboard d = new Dashboard();
            BindDashboard(d);
            OpenDashboard(d);
        }

        [Command]
        public void EditDashboard()
        {
            OpenDashboard(GetCurrentDashboard());
        }
8. **RUN**

## New & Edit - Open Dashboard
1. Drop designer onto DashboardEdit form
2. Add New Save button (remove all others)
3. Remove Data Source tab
4. Modify Presenter to accept a DashboardDesigner and add the following

        void View_DashboardClosing(object sender, DashboardClosingEventArgs e)
        {
            e.IsDashboardModified = false;
        }

        public void BindDashboard()
        {
            View.Dashboard = ViewModel.Parameter as Dashboard;
        }

5. Make sure to wire closing event as well as BindDashboard method in `.ctor` of Presenter

        View.DashboardClosing += View_DashboardClosing;

6. In DashboardEdit add the following to wait for proper ViewModel attachment

        protected override void OnParentViewModelAttached()
        {
            Presenter.BindDashboard();
        }

16. **RUN**

## New & Edit - Saving

17. Bind Save button in `BindCommands` method using `dashsave` template. Will look like:

        private void BindCommands()
        {
            // bind commands to DashboardsEditViewModel here
            barButtonSave.BindCommand(() => ViewModel.SaveDashboard(), ViewModel);
        }

18. Implement SaveDashboard method:

        [Command]
        public void SaveDashboard()
        {
            Messenger.Default.Send<DashboardMessage>(new DashboardMessage(Parameter as Dashboard, DashboardMessageType.Save));
        }

19. Capture message in DashboardsPresenter

        private void OnDashboardMessage(DashboardMessage message)
        {
            if (message.MessageType == DashboardMessageType.View) 
                BindDashboard();
            else if (message.MessageType == DashboardMessageType.Save)
                ViewModel.Save(message.Dashboard);
        }

20. Handle new `Save` method (inner code uses `dashsv` template)

        public void Save(Dashboard dashboard)
        {
            var file = string.Format("{0}\\{1}.xml", DashboardDirectory, dashboard.Title.Text);
            dashboard.SaveToXml(file);
            // refresh dashboard list just in case
            Dashboards = Directory.EnumerateFiles(DashboardDirectory, "*.xml").ToArray();
        }

21. Notify everyone involved something has changed using `dashnote` template

        public void Save(Dashboard dashboard)
        {
            var file = string.Format("{0}\\{1}.xml", DashboardDirectory, dashboard.Title.Text);
            dashboard.SaveToXml(file);
            // refresh dashboard list just in case
            Dashboards = Directory.EnumerateFiles(DashboardDirectory, "*.xml").ToArray();

            // send out messages
            CurrentDashboard = file;
            Messenger.Default.Send<DashboardMessage>(DashboardMessage.View());
            Messenger.Default.Send<DashboardMessage>(DashboardMessage.Refresh());
        }

22. Register message in DashboardPanePresenter

		Messenger.Default.Register<DashboardMessage>(this, OnDashboardMessage);

23. Handle `OnDashboardMessage` event

        private void OnDashboardMessage(DashboardMessage message)
        {
            if (message.MessageType == DashboardMessageType.Refresh)
                PopulateTree();
        }

24. **RUN**


