using System;

namespace ParcelValidator
{
    public class Calculator : ICalculator
    {
        public bool IsSuitableCorner(ParcelSize parcel, PipeCorner corner)
        {
            double width = parcel.Width;
            double length = parcel.Length;

            var inlet = corner.Inlet;
            var outlet = corner.Outlet;

            if (width > inlet ||
                width > outlet)
            {
                return false;
            }

            if (corner.Inlet == corner.Outlet)
            {
                var side = corner.Inlet;
                var hypotenuse = Math.Sqrt(side * side * 2);

                return width < hypotenuse - length / 2;
            }

            var maxSuitableLength = Math.Sqrt(inlet * inlet + width * width) +
                                    Math.Sqrt(outlet * outlet + width * width);

            return length < maxSuitableLength;
        }
    }
}
