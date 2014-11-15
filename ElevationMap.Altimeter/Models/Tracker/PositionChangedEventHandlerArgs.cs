using System;
using NV.ElevationMap.Altimeter.Models.Data;

namespace NV.ElevationMap.Altimeter.Models.Tracker
{
    public class PositionChangedEventHandlerArgs:EventArgs
    {
        public PositionChangedEventHandlerArgs(Measurement measurement)
        {
            if (measurement == null) throw new ArgumentNullException("measurement");
            Measurement = measurement;
        }

        public Measurement Measurement { get; private set; }
    }
}