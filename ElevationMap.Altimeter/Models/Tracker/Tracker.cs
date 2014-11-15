using System;
using System.Device.Location;
using NV.ElevationMap.Altimeter.Models.Data;

namespace NV.ElevationMap.Altimeter.Models.Tracker
{
    public class Tracker : IDisposable
    {
        private readonly GeoCoordinateWatcher _watcher;
        private bool _disposed;

        public Tracker()
        {
            _watcher = new GeoCoordinateWatcher();
            _watcher.PositionChanged += WatcherPositionChanged;
            _watcher.StatusChanged += WatcherStatusChanged;
        }

        public void Start()
        {
            _watcher.Start();
        }

        public void Stop()
        {
            _watcher.Stop();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public event PositionChangedEventHandler PositionChanged;

        public event StageCHangedEventHandler StateChanged;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _watcher.PositionChanged -= WatcherPositionChanged;
                _watcher.StatusChanged -= WatcherStatusChanged;

                _watcher.Dispose();
            }

            _disposed = true;
        }

        protected virtual void OnStateChanged(GeoPositionStatus s)
        {
            var handler = StateChanged;
            if (handler != null) handler(this, new StageChangedEventHandlerArgs(s));
        }

        protected virtual void OnPositionChanged(Measurement m)
        {
            var handler = PositionChanged;
            if (handler != null) handler(this, new PositionChangedEventHandlerArgs(m));
        }

        private void WatcherStatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            OnStateChanged(e.Status);
        }

        private void WatcherPositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            var m = new Measurement
            {
                Latitude = e.Position.Location.Latitude,
                Longitude = e.Position.Location.Longitude,
                Altitude = e.Position.Location.Altitude,
                Timestamp = e.Position.Timestamp.DateTime,
                Accuracy =
                {
                    Horizontal = e.Position.Location.HorizontalAccuracy,
                    Vertical = e.Position.Location.VerticalAccuracy
                }
            };

            OnPositionChanged(m);
        }
    }
}