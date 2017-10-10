using System.ComponentModel.DataAnnotations.Schema;

namespace CycloBit.Model.Entities {
    [ComplexType]
    public class ActivityHealth {
        public float HeartBpm { get; set; }
        ///<Summary>
        /// Distance returned in Meters.
        ///</Summary>
        public float Distance { get; set; }
    }
}