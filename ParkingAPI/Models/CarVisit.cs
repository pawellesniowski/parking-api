using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAPI.Models
{
    public class CarVisit
    {
        public Guid Id { get; set; } = new Guid();
        public string RegistryNumber { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime? EndTime { get; set; } = null;

    }
}
