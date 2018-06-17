namespace ParcelValidator
{
    internal interface IInspectorProvider
    {
        bool WillPass(ParcelSize parcelSize, PipeCorner pipeCorner);
    }
}
