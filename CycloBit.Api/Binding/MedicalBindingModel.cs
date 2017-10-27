using System;
using CycloBit.Common.Conversion;
using CycloBit.Common.Objects;

namespace CycloBit.Api.Binding {
    public class MedicalBindingModel : IMedicalDetail {
        private int? heightCm;
        private double? weightKg;
        public int? HeightCm { 
            get => this.heightCm;
            set { this.heightCm = value; }
        }
        public double? WeightKg {
            get => this.weightKg;
            set { this.weightKg = value; }
        }
        
        public FeetInches HeightFeet {
            get => this.heightCm == null ? null : new FeetInches(this.heightCm.Value);
            set { 
                if (value != null) 
                    this.heightCm = value.ToCentimeters();
            }
        }

        public int? WeightLb {
            get => this.weightKg.ConvertKgtoLb();
            set { 
                if (value != null)
                    this.weightKg = value.ConvertLbtoKg(); 
            }
        }
        public DateTime? DateOfBirth { get; set; }

        public int? AgeYears => null;
    }
}