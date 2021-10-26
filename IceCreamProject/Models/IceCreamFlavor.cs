using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamProject.Models
{
    public class IceCreamFlavor
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public string Flavour { get; set; }
        public string ImagePath { get; set; }
        public string Details { get; set; }
    }
}
