using System;
using CycloBit.Common.Objects;

namespace CycloBit.Common.Conversion {
    public static class Length {
        private static double milesToMeters => 1609.344;

        public static int ConvertInchesToCentimeters(this int inches) {
            FeetInches feetInches = new FeetInches(inches);
            return feetInches.ToCentimeters();
        }

        public static int ConvertCentimetersToInches(this int centimeters) {
            var inches = Math.Round(centimeters / 2.54, 0);
            return Convert.ToInt32(inches);
        }

        public static double ConvertMilesToMeters(this double miles) {
            return miles * milesToMeters;
        }

        public static double ConvertMetersToMiles(this double meters) {
            return meters / milesToMeters;
        }

    }
}