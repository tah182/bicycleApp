using System.ComponentModel.DataAnnotations.Schema;
using CycloBit.Common;

namespace CycloBit.Model.Entities {
    [ComplexType]
    public class FeetInches : Common.Objects.FeetInches { 
        public FeetInches(int inches) : base(inches) { }

        public FeetInches() : base() { }

    }
}