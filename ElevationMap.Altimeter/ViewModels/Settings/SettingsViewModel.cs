using System;
using Microsoft.Practices.Prism.ViewModel;
using NV.ElevationMap.Altimeter.Models.Buffer;
using NV.ElevationMap.Altimeter.Models.Settings;

namespace NV.ElevationMap.Altimeter.ViewModels.Settings
{
    public class SettingsViewModel:NotificationObject
    {
        public SettingsViewModel(AccuracySettings accuracy, IBuffer buffer, Func<double> getFreeSpaceFunc)
        {
            DesiredAccuracy = new DesiredAccuracyViewModel(accuracy);
            Buffer = new BufferViewModel(buffer, getFreeSpaceFunc);
        }

        public DesiredAccuracyViewModel DesiredAccuracy { get; private set; }

        public BufferViewModel Buffer { get; private set; }

    }
}