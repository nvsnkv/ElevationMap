using System.Collections.Generic;
using System.IO.IsolatedStorage;
using NV.ElevationMap.Altimeter.Models.Buffer;
using NV.ElevationMap.Altimeter.Models.Data;
using NV.ElevationMap.Altimeter.Models.Settings;
using NV.ElevationMap.Altimeter.Models.Tracker;

namespace NV.ElevationMap.Altimeter.Kernel
{
    public static class Kernel
    {
        public static Tracker Tracker { get; private set; }

        public static ICollection<Measurement> Buffer { get; private set; }

        public static AccuracySettings AccuracySettings { get; private set; }

        public static void Run()
        {
            AccuracySettings = new AccuracySettings(IsolatedStorageSettings.ApplicationSettings);
            Tracker = new Tracker();
            Buffer = new MeasurementBuffer();

            Tracker.PositionChanged += TrackerPositionChanged;
        }

        public static void Shutdown()
        {
            Tracker.PositionChanged -= TrackerPositionChanged;
            Tracker.Dispose();
        }

        private static void TrackerPositionChanged(object sender, PositionChangedEventHandlerArgs e)
        {
            Buffer.Add(e.Measurement);
        }


    }
}