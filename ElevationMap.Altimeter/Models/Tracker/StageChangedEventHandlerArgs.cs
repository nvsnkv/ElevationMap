using System;
using System.Device.Location;

namespace NV.ElevationMap.Altimeter.Models.Tracker
{
    public class StageChangedEventHandlerArgs:EventArgs
    {
        public StageChangedEventHandlerArgs(GeoPositionStatus current)
        {
            Current = current;
        }

        public GeoPositionStatus Current { get; private set; }
    }
}