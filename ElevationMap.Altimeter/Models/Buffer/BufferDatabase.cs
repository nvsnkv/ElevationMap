using System;
using System.Collections.Generic;
using NV.ElevationMap.Altimeter.Models.Data;
using Wintellect.Sterling.Database;

namespace NV.ElevationMap.Altimeter.Models.Buffer
{
    public class BufferDatabase:BaseDatabaseInstance
    {
        protected override List<ITableDefinition> RegisterTables()
        {
            return new List<ITableDefinition>
            {
                CreateTableDefinition<Measurement, DateTime>(m => m.Timestamp)
            };
        }
    }
}