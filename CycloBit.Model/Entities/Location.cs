using System.ComponentModel.DataAnnotations.Schema;

namespace CycloBit.Model.Entities
{
    public class Location {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public Address Address { get; set; }
    }
}