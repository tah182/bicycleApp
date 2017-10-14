using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema; 

namespace CycloBit.Model.Entities {
    public class Activity {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public LatLng StartCoordinates { get; set; }
        public LatLng EndCoordinates { get; set; }
        public virtual ICollection<Segment> Segments { get; set; } = new List<Segment>();
    }
}