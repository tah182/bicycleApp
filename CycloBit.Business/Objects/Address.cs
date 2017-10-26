using CycloBit.Common.Objects;

namespace CycloBit.Business.Objects {
    public class Address : IAddress {
        public int HouseNumber { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public LatLng LatLng { get; set; }
    }

    public static partial class ExtensionMethods {
        public static Address ToViewModel(this Model.Entities.Address address) {
            return new Address {
                HouseNumber = address.HouseNumber,
                StreetAddress = address.StreetAddress,
                City = address.City,
                State = address.State,
                PostalCode = address.PostalCode,
                LatLng = address.Coordinate
            };
        }
    }
}