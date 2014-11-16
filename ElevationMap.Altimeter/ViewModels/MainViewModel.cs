using ElevationMap.Altimeter.Data;
using NV.ElevationMap.Altimeter.Annotations;
using NV.ElevationMap.Altimeter.ViewModels.Settings;
using NV.ElevationMap.Altimeter.ViewModels.Tracker;

namespace NV.ElevationMap.Altimeter.ViewModels
{
    public class MainViewModel
    {
        [UsedImplicitly]
        public TrackerViewModel Tracker { get; private set; }
        
        [UsedImplicitly]
        public SettingsViewModel Settings { get; private set; }

        public MainViewModel()
        {
            Settings = new SettingsViewModel();
            Tracker = new TrackerViewModel(new Models.Tracker.Tracker(), Settings.DesiredAccuracy.Accuracy);
        }
    }
}