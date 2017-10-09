using System.ComponentModel.DataAnnotations.Schema;

namespace CycloBit.Model.Entities {
    [ComplexType]
    public class Address : Common.Objects.Address {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}