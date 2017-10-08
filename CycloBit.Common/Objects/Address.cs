namespace CycloBit.Common.Objects {
    public class Address {
        public int HouseNumber { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public LatLng LatLng { get; set; }
    }
}