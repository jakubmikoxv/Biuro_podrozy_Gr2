using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biuro_Podróży.Models
{
    public class Hotel
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public decimal Prize { get; set; }
        public int Rating { get; set; }

    }
    public var ListofHotels = new List<Hotel>
    {
        new Hotel() { Name = "Cancun Bay Resort", Country = "Meksyk", Prize = 450m, Rating = 4 },
        new Hotel() { Name = "Iberostar Quetzal", Country = "Meksyk", Prize = 690m, Rating = 5 }
    };
