using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamProject.Models
{
    public class Order
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "The Name field is required")]
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
       // [Required(ErrorMessage = "The Street field is required")]
        public string Street { get; set; }
       // [Required(ErrorMessage = "The City field is required")]
        public string City { get; set; }
        public int HouseNumber { get; set; }
        public string IceCream { get; set; }
        public DateTime Date { get; set; }
        public double FeelsLike { get; set; }
        public double Humidity { get; set; }//לחות
        public double Pressure { get; set; }//לחץ אויר

    }
}
