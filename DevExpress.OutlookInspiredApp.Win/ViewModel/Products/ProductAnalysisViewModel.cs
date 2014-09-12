namespace DevExpress.OutlookInspiredApp.Win.ViewModel {
    using System;
    using System.Collections.Generic;
    using DevExpress.DevAV.DevAVDbDataModel;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.Mvvm;

    public class ProductAnalysisViewModel {
        IDevAVDbUnitOfWork unitOfWork;
        public ProductAnalysisViewModel() {
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
        public IEnumerable<ProductsAnalysis.Item> GetFinancialReport() {
            return unitOfWork.GetFinancialReport();
        }
        public IEnumerable<ProductsAnalysis.Item> GetFinancialData() {
            return unitOfWork.GetFinancialData();
        }
    }
}
