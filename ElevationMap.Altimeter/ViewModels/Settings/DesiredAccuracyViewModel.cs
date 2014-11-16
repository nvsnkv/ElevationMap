using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using NV.ElevationMap.Altimeter.Annotations;
using NV.ElevationMap.Altimeter.Models.Settings;

namespace NV.ElevationMap.Altimeter.ViewModels.Settings
{
    public class DesiredAccuracyViewModel:NotificationObject
    {
        private readonly ICommand _save;

        private bool _hasChanged;
        private readonly AccuracySettings _settings;

        public DesiredAccuracyViewModel(AccuracySettings accuracy)
        {
            _save = new DelegateCommand(PerformSave);
            _settings = accuracy;
        }

        [UsedImplicitly]
        public double Horizontal
        {
            get { return _settings.Horizontal; }
            set
            {
                if (value.Equals(_settings.Horizontal)) return;

                _settings.Horizontal = value;
                HasChanged = _settings.HasChanges;
                RaisePropertyChanged("Horizontal");
            }
        }

        [UsedImplicitly]
        public double Vertical
        {
            get { return _settings.Vertical; }
            set
            {
                if (value.Equals(_settings.Vertical)) return;
                _settings.Vertical = value;
                HasChanged = _settings.HasChanges;
                RaisePropertyChanged("Vertical");
            }
        }

        [UsedImplicitly]
        public bool HasChanged
        {
            get { return _hasChanged; }
            private set
            {
                if (value.Equals(_hasChanged)) return;
                _hasChanged = value;
                RaisePropertyChanged("HasChanged");
            }
        }

        [UsedImplicitly]
        public ICommand Save
        {
            get { return _save; }
        }

        private void PerformSave()
        {
            _settings.Save();
            HasChanged = _settings.HasChanges;
        }        
    }
}