using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CycloBit.Common.Conversion;

namespace CycloBit.Model.Entities {
    public class Segment {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int ActivityId { get; set; }
        [ForeignKey("ActivityId")]
        public virtual Activity Activity { get; set; }
        public TimeSpan Duration { 
            get => SegmentEnd - SegmentStart;
        }
        public DateTime SegmentStart { get; set; }
        public DateTime SegmentEnd { get; set; }
        public ActivityHealth ActivityHealth { get; set; }
        [NotMapped]
        public List<LatLng> Route { 
            get => GooglePoints.Decode(EncodedRoute).Cast<LatLng>().ToList();
            set => EncodedRoute = GooglePoints.Encode(value);
        }
        ///<summary>
        /// Used only for EF storing and retrieving from db. Use Route instead
        ///</summary>
        public string EncodedRoute { get; set; }
    }
}