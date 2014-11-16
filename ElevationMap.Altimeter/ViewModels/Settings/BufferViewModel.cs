using System;
using Microsoft.Practices.Prism.ViewModel;
using NV.ElevationMap.Altimeter.Annotations;
using NV.ElevationMap.Altimeter.Models.Buffer;

namespace NV.ElevationMap.Altimeter.ViewModels.Settings
{
    public class BufferViewModel:NotificationObject
    {
        private readonly IBuffer _buffer;
        private readonly Func<double> _getFreeSpaceFunc;
        private int _count;
        private double _spaceAvailable;

        public BufferViewModel([NotNull] IBuffer buffer, [NotNull] Func<double> getFreeSpaceFunc)
        {
            if (buffer == null) throw new ArgumentNullException("buffer");
            if (getFreeSpaceFunc == null) throw new ArgumentNullException("getFreeSpaceFunc");

            _buffer = buffer;
            _buffer.ItemBuffered += BufferOnItemBuffered;

            _getFreeSpaceFunc = getFreeSpaceFunc;

            BufferOnItemBuffered(this, EventArgs.Empty);
        }

        [UsedImplicitly]
        public int Count
        {
            get { return _count; }
            private set
            {
                if (value == _count) return;
                _count = value;
                RaisePropertyChanged("Count");
            }
        }

        [UsedImplicitly]
        public double SpaceAvailable
        {
            get { return _spaceAvailable; }
            private set
            {
                if (value.Equals(_spaceAvailable)) return;
                _spaceAvailable = value;
                RaisePropertyChanged("SpaceAvailable");
            }
        }

        private void BufferOnItemBuffered(object sender, EventArgs eventArgs)
        {
            Count = _buffer.Count;
            SpaceAvailable = _getFreeSpaceFunc();
        }
    }
}