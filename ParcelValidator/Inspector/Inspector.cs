using System.Collections.Generic;
using System.Linq;

namespace ParcelValidator
{
    internal class Inspector
    {
        private readonly IInspectorProvider _provider;

        public Inspector(IInspectorProvider provider)
        {
            _provider = provider;
        }

        internal Inspector() : this(new InspectorProvider())
        {
        }


        public List<bool> InspectPipeCorners(ParcelSize parcel, List<PipeCorner> corners)
        {
            return corners
                .Select(x => _provider.WillPass(parcel, x))
                .ToList();
        }
    }
}
