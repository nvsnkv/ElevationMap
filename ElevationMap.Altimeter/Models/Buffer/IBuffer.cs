using System;
using NV.ElevationMap.Altimeter.Models.Data;

namespace NV.ElevationMap.Altimeter.Models.Buffer
{
    public interface IBuffer
    {
        void Add(Measurement item);
        void Clear();
        int Count { get; }
        event EventHandler ItemBuffered;
    }
}