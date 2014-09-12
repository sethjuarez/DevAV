namespace DevExpress.OutlookInspiredApp.Win.ViewModel {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DevExpress.DevAV;
    using DevExpress.DevAV.DevAVDbDataModel;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.Mvvm;

    public class CustomerAnalysisViewModel {
        IDevAVDbUnitOfWork unitOfWork;
        public CustomerAnalysisViewModel() {
            unitOfWork = DbUnitOfWorkFactory.Instance.CreateUnitOfWork();
        }
        [DevExpress.Mvvm.DataAnnotations.ServiceProperty]
        protected virtual IDocumentManagerService DocumentManagerService {
            get { throw new NotImplementedException(); }
        }
        [DevExpress.Mvvm.DataAnnotations.Command]
        public void Close() {
            if(DocumentManagerService != null) {
                IDocument document = DocumentManagerService.FindDocument(this);
                if(document != null)
                    document.Close();
            }
        }
        public IEnumerable<CustomersAnalysis.Item> GetSalesReport() {
            return unitOfWork.GetSalesReport();
        }
        public IEnumerable<CustomersAnalysis.Item> GetSalesData() {
            return unitOfWork.GetSalesData();
        }
        public IEnumerable<string> GetStates(IEnumerable<StateEnum> states) {
            return
                from ss in unitOfWork.States.GetEntities()
                join s in states on ss.ShortName equals s
                select ss.LongName;
        }
    }
}
