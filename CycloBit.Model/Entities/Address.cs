using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CycloBit.Common.Objects;

namespace CycloBit.Model.Entities {
    public class Address : Common.Objects.IAddress {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int HouseNumber { get; set; }
        [StringLength(150)]
        public string StreetAddress { get; set; }
        [StringLength(100)]
        public string City { get; set; }
        [StringLength(50)]
        public string State { get; set; }
        public string PostalCode { get; set; }
        [NotMapped]
        public Common.Objects.LatLng LatLng { get; set; }
        public LatLng Coordinate { 
            get { return (Entities.LatLng)this.LatLng; }
            set { this.LatLng = value; }
        }
    }
}