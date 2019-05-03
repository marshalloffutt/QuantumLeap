﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuantumLeap.Models
{
    public class Leaper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Leaper(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
