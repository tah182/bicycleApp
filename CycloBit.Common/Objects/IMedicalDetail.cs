using System;

namespace CycloBit.Common.Objects {
    public interface IMedicalDetail {
        int? HeightCm { get; set; }
        double? WeightKg { get; set; }
        FeetInches HeightFeet { get; }
        int? WeightLb { get; }
        DateTime? DateOfBirth { get; }
        int? AgeYears { get; }
    }
}