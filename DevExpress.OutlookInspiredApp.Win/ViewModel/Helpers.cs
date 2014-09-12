namespace DevExpress.OutlookInspiredApp.Win {
    using System;
    using System.Collections.Generic;
    using DevExpress.DevAV;
    using DevExpress.Mvvm;
    using DevExpress.OutlookInspiredApp.Win.Modules;
    using DevExpress.XtraMap;

    public static class ViewModelHelper {
        public static TViewModel GetParentViewModel<TViewModel>(object viewModel) {
            ISupportParentViewModel parentViewModelSupport = viewModel as ISupportParentViewModel;
            if(parentViewModelSupport != null)
                return (TViewModel)parentViewModelSupport.ParentViewModel;
            return default(TViewModel);
        }
        public static void EnsureModuleViewModel(object module, object parentViewModel, object parameter = null) {
            ISupportViewModel vm = module as ISupportViewModel;
            if(vm != null) {
                object oldParentViewModel = null;
                ISupportParentViewModel parentViewModelSupport = vm.ViewModel as ISupportParentViewModel;
                if(parentViewModelSupport != null)
                    oldParentViewModel = parentViewModelSupport.ParentViewModel;
                EnsureViewModel(vm.ViewModel, parentViewModel, parameter);
                if(oldParentViewModel != parentViewModel)
                    vm.ParentViewModelAttached();
            }
        }
        public static void EnsureViewModel(object viewModel, object parentViewModel, object parameter = null) {
            ISupportParentViewModel parentViewModelSupport = viewModel as ISupportParentViewModel;
            if(parentViewModelSupport != null)
                parentViewModelSupport.ParentViewModel = parentViewModel;
            ISupportParameter parameterSupport = viewModel as ISupportParameter;
            if(parameterSupport != null && parameter != null)
                parameterSupport.Parameter = parameter;
        }
    }
    public static class AddressExtension {
        public static GeoPoint ToGeoPoint(this Address address) {
            return (address != null) ? new GeoPoint(address.Latitude, address.Longitude) : GeoPoint.Empty;
        }
        public static void ZoomTo(this DevExpress.XtraMap.Services.IZoomToRegionService zoomService, IEnumerable<Address> addresses, double margin = 0.25) {
            GeoPoint ptA = GeoPoint.Empty;
            GeoPoint ptB = GeoPoint.Empty;
            foreach(var address in addresses) {
                if(ptA.IsEmpty) {
                    ptA = ptB = address.ToGeoPoint();
                    continue;
                }
                GeoPoint pt = address.ToGeoPoint();
                if(pt.IsEmpty || object.Equals(pt, GeoPoint.Zero))
                    continue;
                ptA.Latitude = Math.Min(ptA.Latitude, pt.Latitude);
                ptA.Longitude = Math.Min(ptA.Longitude, pt.Longitude);
                ptB.Latitude = Math.Max(ptB.Latitude, pt.Latitude);
                ptB.Longitude = Math.Max(ptB.Longitude, pt.Longitude);
            }
            ZoomCore(zoomService, ptA, ptB, margin);
        }
        public static void ZoomTo(this DevExpress.XtraMap.Services.IZoomToRegionService zoomService, Address pointA, Address pointB, double margin = 0.2) {
            ZoomCore(zoomService, pointA.ToGeoPoint(), pointB.ToGeoPoint(), margin);
        }
        static void ZoomCore(DevExpress.XtraMap.Services.IZoomToRegionService zoomService, GeoPoint ptA, GeoPoint ptB, double margin) {
            if(ptA.IsEmpty || ptB.IsEmpty || zoomService == null) return;
            double latPadding = (ptB.Latitude - ptA.Latitude) * margin;
            double longPadding = (ptB.Longitude - ptA.Longitude) * margin;
            zoomService.ZoomToRegion(
                  new GeoPoint(ptA.Latitude - latPadding, ptA.Longitude - longPadding),
                  new GeoPoint(ptB.Latitude + latPadding, ptB.Longitude + longPadding),
                  new GeoPoint(0.5 * (ptA.Latitude + ptB.Latitude), 0.5 * (ptA.Longitude + ptB.Longitude)));
        }
    }
    public static class MapControlExtension {
        public static void Export(this MapControl mapControl, string path) {
            mapControl.ExportToImage(path, System.Drawing.Imaging.ImageFormat.Png);
            AppHelper.ProcessStart(path);
        }
    }
}
