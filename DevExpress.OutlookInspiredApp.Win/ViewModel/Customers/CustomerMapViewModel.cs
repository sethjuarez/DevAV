namespace DevExpress.OutlookInspiredApp.Win.ViewModel {
    using System;
    using System.Drawing;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.Mvvm.DataAnnotations;
    using DevExpress.Mvvm.POCO;

    public class CustomerMapViewModel : CustomerViewModel, ISalesMapViewModel {
        public virtual Sales.Period Period { get; set; }
        [Command(UseCommandManager = false)]
        public void SetLifetimePeriod() {
            Period = Sales.Period.Lifetime;
        }
        public bool CanSetLifetimePeriod() {
            return Period != Sales.Period.Lifetime;
        }
        [Command(UseCommandManager = false)]
        public void SetThisYearPeriod() {
            Period = Sales.Period.ThisYear;
        }
        public bool CanSetThisYearPeriod() {
            return Period != Sales.Period.ThisYear;
        }
        [Command(UseCommandManager = false)]
        public void SetThisMonthPeriod() {
            Period = Sales.Period.ThisMonth;
        }
        public bool CanSetThisMonthPeriod() {
            return Period != Sales.Period.ThisMonth;
        }
        protected virtual void OnPeriodChanged() {
            this.RaiseCanExecuteChanged(x => x.SetLifetimePeriod());
            this.RaiseCanExecuteChanged(x => x.SetThisYearPeriod());
            this.RaiseCanExecuteChanged(x => x.SetThisMonthPeriod());
            RaisePeriodChanged();
        }
        public event EventHandler PeriodChanged;
        void RaisePeriodChanged() {
            EventHandler handler = PeriodChanged;
            if(handler != null) 
                handler(this, EventArgs.Empty);
        }
        #region Properties
        public string Name {
            get { return (Entity != null) ? Entity.Name : null; }
        }
        public Image Image {
            get { return (Entity != null) ? Entity.Image : null; }
        }
        public string AddressLine1 {
            get { return (Entity != null) ? Entity.HomeOffice.Line : null; }
        }
        public string AddressLine2 {
            get { return (Entity != null) ? Entity.HomeOffice.CityLine : null; }
        }
        #endregion
    }
}
