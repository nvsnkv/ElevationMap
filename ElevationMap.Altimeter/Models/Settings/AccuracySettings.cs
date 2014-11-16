using System;
using System.IO.IsolatedStorage;
using NV.ElevationMap.Altimeter.Annotations;
using NV.ElevationMap.Altimeter.Models.Data;

namespace NV.ElevationMap.Altimeter.Models.Settings
{
    public class AccuracySettings:IAccuracy
    {
        private const double DefaultHorizontalAccuracy = 9;
        private const double DefaultVerticalAccuracy = 9;
        private const string HorizontalAccuracyKey = "DesiredAccuracy.Horizontal";
        private const string VerticalAccuracyKey = "DesiredAccuracy.Vertical";

        private readonly IsolatedStorageSettings _settingsProvider;
        private readonly Accuracy _stored = new Accuracy();
        private double _horizontal;
        private double _vertical;

        public AccuracySettings([NotNull] IsolatedStorageSettings settingsProvider)
        {
            if (settingsProvider == null) throw new ArgumentNullException("settingsProvider");
            _settingsProvider = settingsProvider;
            Load();
        }

        public double Horizontal
        {
            get { return _horizontal; }
            set
            {
                if (Math.Abs(value - _horizontal) < double.Epsilon) return;
                _horizontal = value;
                HasChanges = true;
            }
        }

        public double Vertical
        {
            get { return _vertical; }
            set
            {
                if (Math.Abs(value - _vertical) < double.Epsilon) return;
                _vertical = value;
                HasChanges = true;
            }
        }

        public bool HasChanges { get; private set; }

        public void Load()
        {
            if (!_settingsProvider.Contains(HorizontalAccuracyKey))
                _settingsProvider.Add(HorizontalAccuracyKey, DefaultHorizontalAccuracy);

            if (!_settingsProvider.Contains(VerticalAccuracyKey))
                _settingsProvider.Add(VerticalAccuracyKey,DefaultVerticalAccuracy);

            _stored.Horizontal = Horizontal = (double)_settingsProvider[HorizontalAccuracyKey];
            _stored.Vertical = Vertical = (double) _settingsProvider[VerticalAccuracyKey];

            HasChanges = false;
        }

        public void Save()
        {
            _settingsProvider[HorizontalAccuracyKey] = _stored.Horizontal = Horizontal;
            _settingsProvider[VerticalAccuracyKey] = _stored.Vertical = Vertical;

            HasChanges = false;
        }
    }
}