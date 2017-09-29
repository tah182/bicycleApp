using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CycloBit.Api.Model {
    public class MedicalDetials {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string IdentityUserId { get; set; }

        [ForeignKey("IdentityUserId")]
        public ApplicationUser IdentityUser { get; set; }

        public int HeightCm { get; set; }

        public int WeightKg { get; set; }

        public int? AgeYears { 
            get {
                if (this.IdentityUser.DateOfBirth == null) return null;
                
                var dobYear = this.IdentityUser.DateOfBirth?.Year;
                var age = DateTime.Today.Year - (int)dobYear;
                return this.IdentityUser.DateOfBirth > DateTime.Today.AddYears(-age) ? --age : age; 
            }
        }
    }
}