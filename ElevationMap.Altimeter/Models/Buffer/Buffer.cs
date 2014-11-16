using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NV.ElevationMap.Altimeter.Annotations;
using NV.ElevationMap.Altimeter.Models.Data;
using Wintellect.Sterling;

namespace NV.ElevationMap.Altimeter.Models.Buffer
{
    public class Buffer:IBuffer
    {
        private readonly ISterlingDatabaseInstance _database;

        public Buffer([NotNull] ISterlingDatabaseInstance database)
        {
            if (database == null) throw new ArgumentNullException("database");
            _database = database;
        }

        public void Add(Measurement item)
        {
            _database.Save(item);
            OnItemBuffered();
        }

        public void Clear()
        {
            _database.Truncate(typeof(Measurement));
        }

        public int Count { get { return _database.Query<Measurement, DateTime>().Count; } }
        
        public event EventHandler ItemBuffered;

        protected virtual void OnItemBuffered()
        {
            var handler = ItemBuffered;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}