using System;
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
        public decimal Budget { get; set; }
        public DateTime HomeYear { get; set; }

        //public Leaper(string name, int age, decimal budget, DateTime homeYear)
        //{
        //    Name = name;
        //    Age = age;
        //    Budget = budget;
        //    HomeYear = homeYear;
        //}
    }
}
