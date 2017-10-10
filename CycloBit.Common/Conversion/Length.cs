using System;
using CycloBit.Common.Objects;

namespace CycloBit.Common.Conversion {
    public static class Length {
        private static double milesToMeters => 1609.344;
        ///<summary>
        /// Converts inches to centimeters
        ///</summary>
        ///<param name="inches">(int)</param>
        ///<returns>Returns centimeters rounded to nearest integer.</returns>
        public static int ConvertInchesToCentimeters(this int inches) {
            FeetInches feetInches = new FeetInches(inches);
            return feetInches.ToCentimeters();
        }

        ///<summary>
        /// Converts centimeters to inches
        ///</summary>
        ///<param name="centimeters">(int)</param>
        ///<returns>Returns inches rounded to nearest integer.</returns>
        public static int ConvertCentimetersToInches(this int centimeters) {
            var inches = Math.Round(centimeters / 2.54, 0);
            return Convert.ToInt32(inches);
        }

        ///<summary>
        /// Converts miles to meters
        ///</summary>
        ///<param name="miles">(int)</param>
        ///<returns>Returns meters rounded to nearest integer.</returns>
        public static double ConvertMilesToMeters(this double miles) => miles * milesToMeters;

        ///<summary>
        /// Converts meters to miles
        ///</summary>
        ///<param name="meters">(int)</param>
        ///<returns>Returns miles rounded to nearest integer.</returns>
        public static double ConvertMetersToMiles(this double meters) => meters / milesToMeters;

    }
}