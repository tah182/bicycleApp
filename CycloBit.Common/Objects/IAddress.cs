namespace CycloBit.Common.Objects {
    public interface IAddress {
        int HouseNumber { get; set; }
        string StreetAddress { get; set; }
        string City { get; set; }
        string State { get; set; }
        string PostalCode { get; set; }
        LatLng LatLng { get; set; }
    }
}