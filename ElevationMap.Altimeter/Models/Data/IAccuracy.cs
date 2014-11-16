namespace NV.ElevationMap.Altimeter.Models.Data
{
    public interface IAccuracy
    {
        double Horizontal { get; }
        double Vertical { get; }
    }
}