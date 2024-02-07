using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTek.Model
{
    internal class Schedule
    {
        
        public int Id { get; set; }
        public List<Flight> Flights { get; set; }
        public ScheduleStatus ScheduleStatus { get; set; } = ScheduleStatus.NotScheduled;
        public int Day { get; set; }   //Probably should be date and time
    }
}
