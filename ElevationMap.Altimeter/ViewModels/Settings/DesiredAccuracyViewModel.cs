using System;
using System.IO.IsolatedStorage;
using System.Windows.Input;
using ElevationMap.Altimeter.Data;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using NV.ElevationMap.Altimeter.Annotations;

namespace NV.ElevationMap.Altimeter.ViewModels.Settings
{
    public class DesiredAccuracyViewModel:NotificationObject
    {
        private const double DefaultHorizontalAccuracy = 9;
        private const double DefaultVerticalAccuracy = 9;
        private const string HorizontalAccuracyKey = "DesiredAccuracy.Horizontal";
        private const string VerticalAccuracyKey = "DesiredAccuracy.Vertical";

        private readonly IsolatedStorageSettings _settings = IsolatedStorageSettings.ApplicationSettings;
        private readonly ICommand _save;

        private Accuracy _saved;
        private bool _hasChanged;

        public DesiredAccuracyViewModel()
        {
            _save = new DelegateCommand(PerformSave);

            Accuracy = new Accuracy();
            LoadSetings();
        }

        public Accuracy Accuracy { get; private set; }

        [UsedImplicitly]
        public double Horizontal
        {
            get { return Accuracy.Horizontal; }
            set
            {
                if (value.Equals(Accuracy.Horizontal)) return;
                
                Accuracy.Horizontal = value;
                HasChanged = Math.Abs(_saved.Horizontal - value) > double.Epsilon;
                RaisePropertyChanged("Horizontal");
            }
        }

        [UsedImplicitly]
        public double Vertical
        {
            get { return Accuracy.Vertical; }
            set
            {
                if (value.Equals(Accuracy.Vertical)) return;
                Accuracy.Vertical = value;
                HasChanged = Math.Abs(_saved.Vertical - value) > double.Epsilon;
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

        private void LoadSetings()
        {
            if (!_settings.Contains(HorizontalAccuracyKey))
                _settings.Add(HorizontalAccuracyKey, DefaultHorizontalAccuracy);

            if (!_settings.Contains(VerticalAccuracyKey))
                _settings.Add(VerticalAccuracyKey, DefaultVerticalAccuracy);

            _saved = new Accuracy
            {
                Horizontal = Accuracy.Horizontal = (double) _settings[HorizontalAccuracyKey],
                Vertical = Accuracy.Vertical = (double) _settings[VerticalAccuracyKey]
            };
        }

        private void PerformSave()
        {
            _settings[HorizontalAccuracyKey] = Accuracy.Horizontal;
            _settings[VerticalAccuracyKey] = Accuracy.Vertical;
            _settings.Save();

            _saved.Horizontal = Accuracy.Horizontal;
            _saved.Vertical = Accuracy.Vertical;
            HasChanged = false;
        }        
    }
}