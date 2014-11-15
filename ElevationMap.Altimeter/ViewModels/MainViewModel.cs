using ElevationMap.Altimeter.Data;
using NV.ElevationMap.Altimeter.ViewModels.Tracker;

namespace NV.ElevationMap.Altimeter.ViewModels
{
    public class MainViewModel
    {
        public TrackerViewModel Tracker { get; private set; }

        public MainViewModel()
        {
            Tracker = new TrackerViewModel(new Models.Tracker.Tracker(), new Accuracy{Horizontal = 5, Vertical = 5});
        }
    }
}