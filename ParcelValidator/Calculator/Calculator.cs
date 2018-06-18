using System;

namespace ParcelValidator
{
    internal class Calculator : ICalculator
    {
        public bool IsSuitableCorner(ParcelSize parcel, PipeCorner corner)
        {
            double width = parcel.Width;
            double length = parcel.Length;

            var inlet = corner.Inlet;
            var outlet = corner.Outlet;

            // find suitability of parcel's sidewise entry
            if (width > inlet ||
                width > outlet)
            {
                return false;
            }

            var maxSuitableLength = Math.Sqrt(inlet * inlet + width * width) +
                                    Math.Sqrt(outlet * outlet + width * width);

            return length < maxSuitableLength;
        }
    }
}
