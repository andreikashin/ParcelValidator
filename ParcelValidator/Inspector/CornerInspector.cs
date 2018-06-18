using System.Collections.Generic;
using System.Linq;

namespace ParcelValidator
{
    internal class CornerInspector : Inspector
    {

        private readonly ICalculator _calc;

        public CornerInspector(ICalculator calc)
        {
            _calc = calc;
        }

        public CornerInspector() : this(new Calculator())
        {
        }

        public List<bool> InspectPipeCorners(ParcelSize parcel, List<PipeCorner> corners)
        {
            var firstElbow = corners.FirstOrDefault();

            if (_calc.IsSuitableCorner(parcel, firstElbow))
            {
                return corners
                    .Select(x => _calc.IsSuitableCorner(parcel, x))
                    .ToList();
            }

            var len = parcel.Length;
            var wid = parcel.Width;

            parcel.Length = wid;
            parcel.Width = len;

            return corners
                .Select(x => _calc.IsSuitableCorner(parcel, x))
                .ToList();
        }
    }
}
