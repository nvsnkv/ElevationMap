using System;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using NV.ElevationMap.Altimeter.Annotations;
using NV.ElevationMap.Altimeter.Models.Data;
using NV.ElevationMap.Altimeter.Models.Tracker;

namespace NV.ElevationMap.Altimeter.ViewModels.Tracker
{
    public class TrackerViewModel:NotificationObject
    {
        private readonly Models.Tracker.Tracker _tracker;
        private readonly ICommand _start;
        private readonly ICommand _stop;

        private double _latitude;
        private double _longitude;
        private double _altitude;
        private object _trackerState;
        private DateTime _timestamp;
        private bool _isRunning;

        public TrackerViewModel(Models.Tracker.Tracker tracker, IAccuracy desiredAccuracy)
        {
            if (tracker == null) throw new ArgumentNullException("tracker");

            _tracker = tracker;
            _trackerState = "Unknown";

            _latitude = _longitude = _altitude = double.NaN;
            _timestamp = new DateTime(0);

            Accuracy = new AccuracyViewModel(desiredAccuracy);

            _start = new DelegateCommand(PerformStart);
            _stop = new DelegateCommand(PerformStop);
        }

        [UsedImplicitly]
        public double Latitude
        {
            get { return _latitude; }
            private set
            {
                if (value.Equals(_latitude)) return;
                _latitude = value;
                RaisePropertyChanged("Latitude");
            }
        }

        [UsedImplicitly]
        public double Longitude
        {
            get { return _longitude; }
            private set
            {
                if (value.Equals(_longitude)) return;
                _longitude = value;
                RaisePropertyChanged("Longitude");
            }
        }

        [UsedImplicitly]
        public double Altitude
        {
            get { return _altitude; }
            private set
            {
                if (value.Equals(_altitude)) return;
                _altitude = value;
                RaisePropertyChanged("Altitude");
            }
        }

        [UsedImplicitly]
        public DateTime Timestamp
        {
            get { return _timestamp; }
            private set
            {
                if (value.Equals(_timestamp)) return;
                _timestamp = value;
                RaisePropertyChanged("Timestamp");
            }
        }

        [UsedImplicitly]
        public object TrackerState
        {
            get { return _trackerState; }
            private set
            {
                if (Equals(value, _trackerState)) return;
                _trackerState = value;
                RaisePropertyChanged("TrackerState");
            }
        }

        [UsedImplicitly]
        public AccuracyViewModel Accuracy { get; private set; }

        [UsedImplicitly]
        public bool IsRunning
        {
            get { return _isRunning; }
            private set
            {
                if (value.Equals(_isRunning)) return;
                _isRunning = value;
                RaisePropertyChanged("IsRunning");
            }
        }

        [UsedImplicitly]
        public ICommand Start
        {
            get { return _start; }
        }

        [UsedImplicitly]
        public ICommand Stop
        {
            get { return _stop; }
        }

        private void PerformStart()
        {
            _tracker.PositionChanged += TrackerPositionChanged;
            _tracker.StateChanged += TrackerStateChanged;

            _tracker.Start();
            IsRunning = true;
        }

        private void PerformStop()
        {
            _tracker.Stop();
            
            _tracker.PositionChanged -= TrackerPositionChanged;
            _tracker.StateChanged -= TrackerStateChanged;
            TrackerState = "Unknown";

            IsRunning = false;
        }

        private void TrackerPositionChanged(object sender, PositionChangedEventHandlerArgs e)
        {
            Latitude = e.Measurement.Latitude;
            Longitude = e.Measurement.Longitude;
            Altitude = e.Measurement.Altitude;
            Timestamp = e.Measurement.Timestamp;

            Accuracy.Update(e.Measurement.Accuracy);
            
        }

        private void TrackerStateChanged(object sender, StageChangedEventHandlerArgs e)
        {
            TrackerState = e.Current;
        }
    }
}