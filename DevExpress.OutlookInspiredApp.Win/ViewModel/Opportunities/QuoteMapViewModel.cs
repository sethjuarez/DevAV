namespace DevExpress.OutlookInspiredApp.Win.ViewModel {
    using System;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.Mvvm.DataAnnotations;
    using DevExpress.Mvvm.POCO;

    public class QuoteMapViewModel : QuoteViewModel {
        public virtual Opportunities.Stage Stage { get; set; }
        [Command(UseCommandManager = false)]
        public void SetHighStage() {
            Stage = Opportunities.Stage.High;
        }
        public bool CanSetHighStage() {
            return Stage != Opportunities.Stage.High;
        }
        [Command(UseCommandManager = false)]
        public void SetMediumStage() {
            Stage = Opportunities.Stage.Medium;
        }
        public bool CanSetMediumStage() {
            return Stage != Opportunities.Stage.Medium;
        }
        [Command(UseCommandManager = false)]
        public void SetLowStage() {
            Stage = Opportunities.Stage.Low;
        }
        public bool CanSetLowStage() {
            return Stage != Opportunities.Stage.Low;
        }
        [Command(UseCommandManager = false)]
        public void SetUnlikelyStage() {
            Stage = Opportunities.Stage.Unlikely;
        }
        public bool CanSetUnlikelyStage() {
            return Stage != Opportunities.Stage.Unlikely;
        }
        protected virtual void OnStageChanged() {
            this.RaiseCanExecuteChanged(x => x.SetHighStage());
            this.RaiseCanExecuteChanged(x => x.SetMediumStage());
            this.RaiseCanExecuteChanged(x => x.SetLowStage());
            this.RaiseCanExecuteChanged(x => x.SetUnlikelyStage());
            RaiseStageChanged();
        }
        public event EventHandler StageChanged;
        void RaiseStageChanged() {
            EventHandler handler = StageChanged;
            if(handler != null) handler(this, EventArgs.Empty);
        }
    }
}
