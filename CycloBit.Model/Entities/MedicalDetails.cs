using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using CycloBit.Common.Conversion;

namespace CycloBit.Model.Entities {
    public class MedicalDetials {
        private FeetInches feetInches = null;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string IdentityUserId { get; set; }

        [ForeignKey("IdentityUserId")]
        public ApplicationUser IdentityUser { get; set; }

        public int HeightCm { get; set; }

        public double WeightKg { get; set; }

        public FeetInches FeetInches { 
            get {
                if (feetInches == null)
                    feetInches = new FeetInches(HeightCm.ConvertCentimetersToInches());

                return feetInches;
            }
        }

        public double WeightLb => WeightKg.ConvertKgtoLb(); 

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