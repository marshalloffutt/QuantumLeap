﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuantumLeap.Models
{
    public class CreateEventRequest
    {
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Year { get; set; }
        public bool IsCorrect { get; set; }
    }
}
