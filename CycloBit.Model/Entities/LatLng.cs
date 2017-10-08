using CycloBit.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace CycloBit.Model.Entities {
    [ComplexType]
    public class LatLng : Common.Objects.LatLng {
        
        public LatLng() : base() { }

        public LatLng(double lat, double lng) : base(lat, lng) { }

        public LatLng(string latLng) : base(latLng) { }
    }
}