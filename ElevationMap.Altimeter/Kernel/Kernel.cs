using System.IO.IsolatedStorage;
using NV.ElevationMap.Altimeter.Models.Buffer;
using NV.ElevationMap.Altimeter.Models.Settings;
using NV.ElevationMap.Altimeter.Models.Tracker;
using Wintellect.Sterling;
using Wintellect.Sterling.IsolatedStorage;

namespace NV.ElevationMap.Altimeter.Kernel
{
    public static class Kernel
    {
        private static SterlingEngine _engine;
        private static ISterlingDatabaseInstance _database;
        private static IsolatedStorageFile _userStore;

        public static Tracker Tracker { get; private set; }

        public static IBuffer Buffer { get; private set; }

        public static AccuracySettings AccuracySettings { get; private set; }

        public static void Run()
        {
            AccuracySettings = new AccuracySettings(IsolatedStorageSettings.ApplicationSettings);
            Tracker = new Tracker();

            _engine = new SterlingEngine();
            _engine.Activate();
            _database = _engine.SterlingDatabase.RegisterDatabase<BufferDatabase>(new IsolatedStorageDriver());
            
            Buffer = new Buffer(_database);
            _userStore = IsolatedStorageFile.GetUserStoreForApplication();

            Tracker.PositionChanged += TrackerPositionChanged;
        }

        public static void Shutdown()
        {
            Tracker.PositionChanged -= TrackerPositionChanged;
            Tracker.Dispose();
            
            _database.Flush();
            _engine.Dispose();
            _database = null;
            _engine = null;

            _userStore.Dispose();
        }

        public static void OnDeactivate()
        {
            _database.Flush();
        }

        private static void TrackerPositionChanged(object sender, PositionChangedEventHandlerArgs e)
        {
            Buffer.Add(e.Measurement);
        }


        public static double GetFreeSpace()
        {
            return _userStore.AvailableFreeSpace;
        }
    }
}