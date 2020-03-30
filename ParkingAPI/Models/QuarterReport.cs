using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAPI.Models
{
    public class QuarterReport
    {
        public long Id { get; set; }
        public string Quarter { get; set; }
        public string Income { get; set; }
        public string CarQuantity { get; set; }
    }
}
