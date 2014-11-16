using System.Collections;
using System.Collections.Generic;
using NV.ElevationMap.Altimeter.Models.Data;

namespace NV.ElevationMap.Altimeter.Models.Buffer
{
    public class MeasurementBuffer:ICollection<Measurement>
    {
        public IEnumerator<Measurement> GetEnumerator()
        {
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Measurement item)
        {
           
        }

        public void Clear()
        {
            
        }

        public bool Contains(Measurement item)
        {
            return false;
        }

        public void CopyTo(Measurement[] array, int arrayIndex)
        {
            
        }

        public bool Remove(Measurement item)
        {
            return false;
        }

        public int Count { get { return 0; } }
        public bool IsReadOnly { get { return false; } }
    }
}