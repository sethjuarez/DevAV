using System;
using System.Linq;
using DevExpress.Mvvm;
using System.Collections.Generic;
using DevExpress.Mvvm.DataAnnotations;

namespace DevExpress.OutlookInspiredApp.Win.ViewModel
{
    public class DashboardsEditViewModel : ISupportParameter
    {
        // Tip for instantiating this as a standalone window
        // 1. in the view
        // protected override void OnInitServices(IServiceContainer serviceContainer)
        // {
        //		base.OnInitServices(serviceContainer);
        //		serviceContainer.RegisterService(new DetailFormDocumentManagerService(ModuleType.DashboardsEdit));
        // }

        // 2. In the ViewModel we need this property
        // [ServiceProperty]
        // public virtual IDocumentManagerService DocumentManagerService
        // {
        //		get
        //		{
        //			return null;
        //		}
        // }

        // 3. Whenever you want to instantiate, use this:
        // var document = DocumentManagerService.CreateDocument("DashboardsEdit", someParameter, this);
        // if (document != null)
        //		document.Show();

        public virtual object Parameter { get; set; }
    }
}
