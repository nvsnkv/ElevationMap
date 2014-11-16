using System;

namespace NV.ElevationMap.Altimeter.Models.Data
{
    public class Measurement
    {
        public Measurement()
        {
            Accuracy = new Accuracy();
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }

        public DateTime Timestamp { get; set; }

        public Accuracy Accuracy { get; set; }
    }
}