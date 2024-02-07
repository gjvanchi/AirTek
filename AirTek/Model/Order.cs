using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTek.Model
{
 
    internal class Order
    {
        public string Id { get; set; }
        public string Destination { get; set; }
        public int FlightNo { get; set; }
        public ScheduleStatus Status { get; set; } = ScheduleStatus.NotScheduled;
        //Destination Destination { get; set; }

    }
}
