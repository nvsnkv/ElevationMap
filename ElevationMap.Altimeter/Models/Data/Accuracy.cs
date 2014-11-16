namespace NV.ElevationMap.Altimeter.Models.Data
{
    public class Accuracy : IAccuracy
    {
        public double Horizontal { get; set; }
        public double Vertical { get; set; }
    }
}