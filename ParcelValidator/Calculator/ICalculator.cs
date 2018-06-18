namespace ParcelValidator
{
    internal interface ICalculator
    {
        bool IsSuitableCorner(ParcelSize parcel, PipeCorner corner);
    }
}
