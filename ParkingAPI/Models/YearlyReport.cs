using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAPI.Models
{
    public class YearlyReport
    {
        public long Id { get; set; }
        public string Year { get; set; }
        public string Income { get; set; }
        public string CarQuantity { get; set; }
    }
}
