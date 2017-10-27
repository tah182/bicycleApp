using System;

namespace CycloBit.Common.Objects {
    public interface IMedicalDetail {
        int HeightCm { get; set; }
        int WeightKg { get; set; }
        FeetInches HeightFeet { get; set; }
        double WeightLb { get; set; }
        DateTime? DateOfBirth { get; set; }
    }
}