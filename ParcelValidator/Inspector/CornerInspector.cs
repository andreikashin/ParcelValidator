using System.Collections.Generic;
using System.Linq;

namespace ParcelValidator
{
    public class CornerInspector : Inspector
    {

        private readonly ICalculator _calc;

        public CornerInspector(ICalculator calc)
        {
            _calc = calc;
        }

        public CornerInspector() : this(new Calculator())
        {
        }

        /// <summary>
        ///     Inspect every given corner in the list of <paramref name="corners"/> 
        ///     in appliance to the size of <paramref name="parcel"/>
        /// </summary>
        /// <param name="parcel">Size of parcel</param>
        /// <param name="corners">List of corner dimensions</param>
        /// <returns>The array of boolean results for each corner</returns>
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

        public List<PipeCorner> ParseCorners(string[] values)
        {
            var result = new List<PipeCorner>();

            for (var idx = 2; idx < values.Length - 1; idx++)
            {
                result.Add(new PipeCorner
                {
                    Inlet = int.Parse(values[idx]),
                    Outlet = int.Parse(values[idx + 1])
                });
            }

            return result;
        }
    }
}
