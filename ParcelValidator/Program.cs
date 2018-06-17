using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcelValidator
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            var parcelSize = new ParcelSize();
            var pipeCorners = new List<PipeCorner>();

            if (args.Length == 1)
            {
                var values = args.FirstOrDefault()?.Split(',');

                if (values == null)
                {
                    throw new ArgumentNullException();
                }
                if (values.Length < Constants.ParcelDimensionCount +
                    Constants.CornerDimensionCount)
                {
                    throw new ArgumentException("Insufficient arguments");
                }

                parcelSize.Length = int.Parse(values[0]);
                parcelSize.Width = int.Parse(values[1]);
                pipeCorners = ParseCorners(values);
            }

            else if (args.Length > 1)
            {
                throw new ArgumentException();
            }

        }

        private static List<PipeCorner> ParseCorners(string[] values)
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
