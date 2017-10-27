using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using CycloBit.Common.Conversion;
using CycloBit.Common.Objects;

namespace CycloBit.Model.Entities {
    public class MedicalDetail : IMedicalDetail {
        private FeetInches feetInches = null;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string IdentityUserId { get; set; }

        [ForeignKey("IdentityUserId")]
        public ApplicationUser IdentityUser { get; set; }

        public int? HeightCm { get; set; }

        public double? WeightKg { get; set; }

        [NotMapped]
        public FeetInches HeightFeet { 
            get {
                if (HeightCm == null) return null;

                if (feetInches == null)
                    feetInches = new FeetInches(HeightCm.ConvertCentimetersToInches().Value);

                return feetInches;
            }
        }

        [NotMapped]
        public int? WeightLb => WeightKg.ConvertKgtoLb(); 

        [NotMapped]
        public DateTime? DateOfBirth => this.IdentityUser.DateOfBirth;

        [NotMapped]
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