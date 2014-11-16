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
            Settings = new SettingsViewModel(Kernel.Kernel.AccuracySettings);
            Tracker = new TrackerViewModel(Kernel.Kernel.Tracker, Kernel.Kernel.AccuracySettings);
        }
    }
}