using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuantumLeap.Models
{
    public class Leap
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int LeaperId { get; set; }
        public int LeapeeId { get; set; }
    }

}
