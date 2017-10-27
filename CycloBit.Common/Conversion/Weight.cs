namespace CycloBit.Common.Conversion
{
    public static class Weight {
        private static double kgToLb => 2.20462;
        ///<summary>
        /// Converts kilograms to pounds
        ///</summary>
        ///<param name="kg">(double)</param>
        ///<returns>Returns converted kilograms.</returns>
        public static int? ConvertKgtoLb(this double? kg) => (int?)(kg * kgToLb);

        ///<summary>
        /// Converts pounds to kilograms
        ///</summary>
        ///<param name="lb">(double)</param>
        ///<returns>Returns converted pounds.</returns>
        public static double? ConvertLbtoKg(this int? lb) => lb / kgToLb;

    }
}