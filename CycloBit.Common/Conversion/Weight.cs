using System;

namespace CycloBit.Common.Conversion {
    public static partial class Weight {
        private static double kgToLb => 2.20462;

        public static double ConvertKgtoLb(this int kg) {
            return kg * kgToLb;
        }

        public static double ConvertLbtoKg(this int kg) {
            return kg / kgToLb;
        }

    }
}