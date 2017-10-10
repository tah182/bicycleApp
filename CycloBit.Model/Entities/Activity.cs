using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema; 

namespace CycloBit.Model.Entities {
    public class Activity {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public virtual List<Segment> Segments { get; set; }
    }
}