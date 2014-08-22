namespace DevExpress.OutlookInspiredApp.Win.ViewModel {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using DevExpress.Data.Filtering;
    using DevExpress.DevAV.Common.DataModel;
    using DevExpress.DevAV.Common.Utils;
    using DevExpress.DevAV.Common.ViewModel;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.Mvvm;
    using DevExpress.Mvvm.DataAnnotations;
    using DevExpress.Mvvm.POCO;

    public class FilterTreeViewModel<TEntity, TPrimaryKey, TUnitOfWork> : FilterTreeViewModelBase
        where TEntity : class
        where TUnitOfWork : class, IUnitOfWork {
        CollectionViewModel<TEntity, TPrimaryKey, TUnitOfWork> collectionViewModelCore;
        public FilterTreeViewModel(
            CollectionViewModel<TEntity, TPrimaryKey, TUnitOfWork> collectionViewModel,
            IFilterTreeModelPageSpecificSettings settings) :
            base(settings) {
            this.collectionViewModelCore = collectionViewModel;
            ViewModelHelper.EnsureViewModel(this, CollectionViewModel);
            Init();
            ISupportCustomFilters scf = collectionViewModel as ISupportCustomFilters;
            if(scf != null)
                scf.CustomFiltersReset += scf_CustomFiltersReset;
        }
        void scf_CustomFiltersReset(object sender, EventArgs e) {
            ResetCustomFilters();
        }
        protected internal CollectionViewModel<TEntity, TPrimaryKey, TUnitOfWork> CollectionViewModel {
            get { return collectionViewModelCore; }
        }
        protected virtual void OnSelectedItemChanged() {
            this.RaiseCanExecuteChanged(x => x.Select(null));
            RaiseSelectedItemChanged();
            ApplyFilter(SelectedItem);
        }
        public bool CanSelectModule(FilterItem item) {
            return SelectedItem != item;
        }
        [Command]
        public void Select(FilterItem item) {
            SelectedItem = item;
        }
        public event EventHandler SelectedItemChanged;
        void RaiseSelectedItemChanged() {
            if(SelectedItemChanged != null)
                SelectedItemChanged(this, EventArgs.Empty);
        }
        void ApplyFilter(FilterItemBase filterItem) {
            if((filterItem != null) && !object.ReferenceEquals(filterItem.FilterCriteria, null)) {
                var converter = new CriteriaOperatorToExpressionConverter<TEntity>();
                CollectionViewModel.FilterExpression = converter.Convert(filterItem.FilterCriteria);
            }
            else CollectionViewModel.FilterExpression = null;
        }
        public event EventHandler FilterTreeChanged;
        void RaiseFilterTreeChanged() {
            if(FilterTreeChanged != null)
                FilterTreeChanged(this, EventArgs.Empty);
        }
        public override FilterItemBase CreateFilterItem(string name, CriteriaOperator filterCriteria) {
            return DevExpress.Mvvm.POCO.ViewModelSource.Create(() => new FilterItem(name, filterCriteria));
        }
        public override FilterItemBase CreateStaticFilterItem(string name, CriteriaOperator filterCriteria) {
            return DevExpress.Mvvm.POCO.ViewModelSource.Create(() => new StaticFilterItem(name, filterCriteria));
        }
        //
        [Command]
        public void New() {
            var newFilterItem = CreateFilterItem(null, null);
            CustomFilterViewModel viewModel = CreateCustomFilterViewModel<CustomFilterViewModel>(newFilterItem);
            if(ShowFilterDialog(viewModel, "Custom Filter")) {
                if(viewModel.Save) {
                    AddNewCustomFilter(newFilterItem);
                    RaiseFilterTreeChanged();
                }
                SelectedItem = newFilterItem;
            }
        }
        [Command]
        public void Modify(FilterItem item) {
            CustomFilterViewModel viewModel = CreateCustomFilterViewModel<CustomFilterViewModel>(item);
            if(ShowFilterDialog(viewModel, "Custom Filter")) {
                if(viewModel.Save) {
                    ModifyCustomFilter(item);
                    RaiseFilterTreeChanged();
                }
                ApplyFilter(item);
            }
        }
        [Command]
        public void Delete(FilterItem item) {
            DeleteCustomFilter(item);
            RaiseFilterTreeChanged();
            if(SelectedItem == item)
                SelectedItem = null;
        }
        [Command]
        public void NewGroup() {
            NewGroupCore(CreateFilterItem(null, null));
        }
        [Command]
        public void NewGroupFromSelection(IEnumerable<TEntity> selection) {
            NewGroupCore(CreateFilterItem(null, CollectionViewModel.GetInOperator(selection)));
        }
        void NewGroupCore(FilterItemBase newFilterItem) {
            GroupFilterViewModel viewModel = CreateCustomFilterViewModel<GroupFilterViewModel>(newFilterItem);
            if(ShowFilterDialog(viewModel, "Group Filter")) {
                if(viewModel.Save) {
                    AddNewGroupFilter(newFilterItem);
                    RaiseFilterTreeChanged();
                }
                SelectedItem = newFilterItem;
            }
        }
        [Command]
        public void ModifyGroup(FilterItem item) {
            GroupFilterViewModel viewModel = CreateCustomFilterViewModel<GroupFilterViewModel>(item);
            if(ShowFilterDialog(viewModel, "Group Filter")) {
                if(viewModel.Save) {
                    ModifyGroupFilter(item);
                    RaiseFilterTreeChanged();
                }
                ApplyFilter(item);
            }
        }
        [Command]
        public void DeleteGroup(FilterItem item) {
            DeleteGroupFilter(item);
            RaiseFilterTreeChanged();
            if(SelectedItem == item)
                SelectedItem = null;
        }
        public override void ResetCustomFilters() {
            base.ResetCustomFilters();
            RaiseFilterTreeChanged();
        }
        protected virtual T CreateCustomFilterViewModel<T>(FilterItemBase filterItem) where T : FilterViewModelBase, new() {
            T viewModel = ViewModelSource.Create<T>();
            ViewModelHelper.EnsureViewModel(viewModel, CollectionViewModel, filterItem);
            return viewModel;
        }
        bool ShowFilterDialog(FilterViewModelBase viewModel, string key) {
            var service = ((ISupportServices)this).ServiceContainer.GetService<IDocumentManagerService>(key);
            if(service != null) {
                var document = service.CreateDocument(key, viewModel, null, CollectionViewModel);
                viewModel.Document = document;
                document.Show();
                return viewModel.Result.GetValueOrDefault();
            }
            return false;
        }
        protected virtual bool EnableGroups { 
            get { return true; } 
        }
        public string GetFilterName(object filtersCollection, FilterItemBase filter) {
            if(filter != null) {
                var count = CollectionViewModel.GetCount(filter.FilterCriteria);
                if(count > 0)
                    return filter.Name + " (" + count + ")";
                else
                    return filter.Name;
            }
            else {
                if(object.Equals(filtersCollection, StaticFilters))
                    return StaticFiltersName;
                if(object.Equals(filtersCollection, CustomFilters))
                    return CustomFiltersName;
                if(object.Equals(filtersCollection, Groups))
                    return GroupFiltersName;
            }
            return null;
        }
        public IList GetСhildren(object dataItem) {
            if(dataItem == this) {
                if(EnableGroups)
                    return (IList)(new List<object> { StaticFilters, CustomFilters, Groups });
                else
                    return (IList)(new List<object> { StaticFilters, CustomFilters });
            }
            if(dataItem is System.Collections.ObjectModel.ObservableCollection<FilterItemBase>)
                return (IList)dataItem;
            return null;
        }
        #region Filter Item ViewModels
        public class FilterItem : FilterItemBase {
            public FilterItem(string name, CriteriaOperator filterCriteria) {
                this.Name = name;
                this.FilterCriteria = filterCriteria;
            }
        }
        public class StaticFilterItem : FilterItem {
            public StaticFilterItem(string name, CriteriaOperator filterCriteria)
                : base(name, filterCriteria) {
            }
        }
        #endregion Items
    }
    #region Custom Filter ViewModel
    [POCOViewModelAttribute(ImplementIDataErrorInfo = true)]
    public abstract class FilterViewModelBase : ISupportParameter {
        public FilterViewModelBase() {
            Save = true;
        }
        FilterItemBase filterItem;
        public IDocument Document { get; set; }
        public bool? Result { get; private set; }
        public virtual bool Save { get; set; }
        [Required]
        public virtual string Name { get; set; }
        public CriteriaOperator FilterCriteria {
            get { return filterItem.FilterCriteria; }
        }
        public event EventHandler<QueryFilterCriteriaEventArgs> QueryFilterCriteria;
        void RaiseQueryFilterCriteria() {
            EventHandler<QueryFilterCriteriaEventArgs> handler = QueryFilterCriteria;
            if(handler != null)
                handler(this, new QueryFilterCriteriaEventArgs(filterItem));
        }
        protected virtual IMessageBoxService MessageBoxService {
            get { return ((ISupportServices)this).ServiceContainer.GetService<IMessageBoxService>(); }
        }
        protected abstract string GetDefaultName();
        //
        [Command]
        public void OK() {
            Result = true;
            if(string.IsNullOrEmpty(Name))
                Name = GetDefaultName();
            if(Save)
                filterItem.Name = Name;
            RaiseQueryFilterCriteria();
            Document.Close();
        }
        [Command]
        public void Cancel() {
            Result = false;
            Document.Close();
        }
        object ISupportParameter.Parameter {
            get { return filterItem; }
            set {
                filterItem = (FilterItemBase)value;
                Name = filterItem.Name;
            }
        }
    }
    public class QueryFilterCriteriaEventArgs : EventArgs {
        FilterItemBase item;
        public QueryFilterCriteriaEventArgs(FilterItemBase item) {
            this.item = item;
        }
        public CriteriaOperator FilterCriteria {
            get { return item.FilterCriteria; }
            set { item.FilterCriteria = value; }
        }
    }
    public class CustomFilterViewModel : FilterViewModelBase {
        static int id = 0;
        protected override string GetDefaultName() {
            return "Custom Filter " + (id++).ToString();
        }
    }
    public class GroupFilterViewModel : FilterViewModelBase {
        static int id = 0;
        protected override string GetDefaultName() {
            return "Group " + (id++).ToString();
        }
    }
    #endregion
}
