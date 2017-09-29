using System;
using CycloBit.Common.Objects;

namespace CycloBit.Common.Conversion {
    public static partial class Length {

        public static int ConvertCentimetersToInches(this int centimeters) {
            var inches = Math.Round(centimeters / 2.54, 0);
            return Convert.ToInt32(inches);
        }

        public static int ConvertInchesToCentimeters(this int inches) {
            FeetInches feetInches = new FeetInches(inches);
            return feetInches.ToCentimeters();
        }

        public static double ConvertMetersToMiles(this double meters) {
            return meters / 1609.344;
        }

        public static double ConvertMilesToMeters(this double miles) {
            return miles * 1609.344;
        }

    }
}