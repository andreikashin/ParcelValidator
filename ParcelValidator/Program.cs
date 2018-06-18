using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcelValidator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var values = new string[] { };

            if (args.Length == 1)
            {
                values = args.FirstOrDefault()?.Split(',');
            }

            else if (args.Length > 1)
            {
                values = args.Select(x => x.Trim(',')).ToArray();
            }

            var result = ProcessValues(values);
            var cnt = 1;

            if (!result.Contains(false))
            {
                Console.WriteLine("Fits.");
            }
            else
            {
                foreach (var passability in result)
                {
                    if (passability)
                    {
                        cnt++;
                        continue;
                    }

                    Console.WriteLine($"Does not fit. Parcel will stuck in corner {cnt}.");
                    break;
                }
            }
        }

        private static List<bool> ProcessValues(string[] values)
        {

            if (values == null)
            {
                throw new ArgumentNullException();
            }
            if (values.Length <
                Constants.Dimensions.ParcelDimensionCount +
                Constants.Dimensions.CornerDimensionCount)
            {
                throw new ArgumentException("Insufficient arguments");
            }

            var parcelSize = new ParcelSize
            {
                Length = int.Parse(values[0]),
                Width = int.Parse(values[1])
            };

            var inspector = new CornerInspector();

            var pipeCorners = inspector.ParseCorners(values);

            return inspector.InspectPipeCorners(parcelSize, pipeCorners);
        }

        //private static List<PipeCorner> ParseCorners(string[] values)
        //{
        //    var result = new List<PipeCorner>();

        //    for (var idx = 2; idx < values.Length - 1; idx++)
        //    {
        //        result.Add(new PipeCorner
        //        {
        //            Inlet = int.Parse(values[idx]),
        //            Outlet = int.Parse(values[idx + 1])
        //        });
        //    }

        //    return result;
        //}
    }
}
