using System;

namespace CycloBit.Common.Objects {
    public class FeetInches {
        public FeetInches(int inches) {
            this.Foot = (int)(inches / 12);
            this.Inch = inches % 12;
        }

        public FeetInches() { }

        public int Foot { get; set; }

        public int Inch { get; set; }

        public int ToInches() {
            return this.Foot * 12 + this.Inch;
        }

        public int ToCentimeters() {
            var centimeters = Math.Round(this.ToInches() * 2.54, 0);
            return Convert.ToInt32(centimeters);
        }

        public override string ToString() {
            return this.Foot + "'" + this.Inch + "\"";
        }
    }
}