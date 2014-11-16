using Microsoft.Practices.Prism.ViewModel;
using NV.ElevationMap.Altimeter.Models.Settings;

namespace NV.ElevationMap.Altimeter.ViewModels.Settings
{
    public class SettingsViewModel:NotificationObject
    {
        public SettingsViewModel(AccuracySettings accuracy)
        {
            DesiredAccuracy = new DesiredAccuracyViewModel(accuracy);
        }
        public DesiredAccuracyViewModel DesiredAccuracy { get; private set; }

    }
}