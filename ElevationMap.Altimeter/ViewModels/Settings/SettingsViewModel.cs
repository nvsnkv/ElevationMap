using Microsoft.Practices.Prism.ViewModel;

namespace NV.ElevationMap.Altimeter.ViewModels.Settings
{
    public class SettingsViewModel:NotificationObject
    {
        public SettingsViewModel()
        {
            DesiredAccuracy = new DesiredAccuracyViewModel();
        }
        public DesiredAccuracyViewModel DesiredAccuracy { get; private set; }

    }
}