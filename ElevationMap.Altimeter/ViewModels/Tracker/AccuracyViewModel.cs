using System;
using Microsoft.Practices.Prism.ViewModel;
using NV.ElevationMap.Altimeter.Annotations;
using NV.ElevationMap.Altimeter.Models.Data;

namespace NV.ElevationMap.Altimeter.ViewModels.Tracker
{
    public class AccuracyViewModel:NotificationObject
    {
        private readonly IAccuracy _desiredAccuracy;
        private double _horizontal;
        private double _vertical;
        private bool _isPoor;

        public AccuracyViewModel(IAccuracy desiredAccuracy)
        {
            if (desiredAccuracy == null) throw new ArgumentNullException("desiredAccuracy");
            _isPoor = true;
            _horizontal = _vertical = double.NaN;

            _desiredAccuracy = desiredAccuracy;
        }

        [UsedImplicitly]
        public double Horizontal
        {
            get { return _horizontal; }
            private set
            {
                if (value.Equals(_horizontal)) return;
                _horizontal = value;
                RaisePropertyChanged("Horizontal");
            }
        }

        [UsedImplicitly]
        public double Vertical
        {
            get { return _vertical; }
            private set
            {
                if (value.Equals(_vertical)) return;
                _vertical = value;
                RaisePropertyChanged("Vertical");
            }
        }

        public bool IsPoor
        {
            get { return _isPoor; }
            private set
            {
                if (value.Equals(_isPoor)) return;
                _isPoor = value;
                RaisePropertyChanged("IsPoor");
            }
        }

        public void Update(Accuracy current)
        {
            IsPoor = _desiredAccuracy.Horizontal <= current.Horizontal 
                     || _desiredAccuracy.Vertical <= current.Vertical;

            Horizontal = current.Horizontal;
            Vertical = current.Vertical;
        }
    }
}