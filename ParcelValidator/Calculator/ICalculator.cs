namespace ParcelValidator
{
    public interface ICalculator
    {
        bool IsSuitableCorner(ParcelSize parcel, PipeCorner corner);
    }
}
