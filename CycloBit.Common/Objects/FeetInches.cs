using System;

namespace CycloBit.Common.Objects {
    public class FeetInches {
        private int inchesInFeet => 12;

        ///<summary>
        /// Constructs a FeetInches object by using inches
        ///</summary>
        ///<param name="inches">the total inches to be humanized</param>
        public FeetInches(int inches) {
            this.Foot = (int)(inches / inchesInFeet);
            this.Inch = inches % inchesInFeet;
        }

        public FeetInches() { }

        public int Foot { get; set; }

        public int Inch { get; set; }

        ///<summary>
        /// Provides the total inches from feet and inches
        ///</summary>
        ///<returns>the feet and inches in inches</returns>
        public int ToInches() {
            return this.Foot * inchesInFeet + this.Inch;
        }

        ///<summary>
        /// Provides the centimeter conversion of feet and inches
        ///</summary>
        ///<returns>the feet and inches in centimeters</returns>
        public int ToCentimeters() {
            var centimeters = Math.Round(this.ToInches() * 2.54, 0);
            return Convert.ToInt32(centimeters);
        }

        ///<returns>feet and inches in (x'y") notation</returns>
        public override string ToString() {
            return this.Foot + "'" + this.Inch + "\"";
        }
    }
}