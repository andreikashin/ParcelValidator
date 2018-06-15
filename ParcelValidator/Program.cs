using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace ParcelValidator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var parcelSize = new ParcelSize();


            if (args.Length == 1)
            {
                var values = args.FirstOrDefault()?.Split(',');

                if (values == null)
                {
                    throw new ArgumentNullException();
                }
                if (values.Length < Marshal.SizeOf(typeof(ParcelSize)) +
                    Marshal.SizeOf(typeof(PipeCorner)))
                {
                    throw new ArgumentException("Insufficient arguments");
                }

                parcelSize.Length = int.Parse(values[0]);
                parcelSize.Width = int.Parse(values[1]);
            }

            else if (args.Length > 1)
            {
                parcelSize.Length = 1;
                parcelSize.Width = 1;
            }
        }
    }

    internal struct ParcelSize
    {
        internal int Length;
        internal int Width;
    }

    internal struct PipeCorner
    {
        internal int Inlet;
        internal int Outlet;
    }
}
