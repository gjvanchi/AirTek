using AirTek.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTek
{
    internal interface ISchedule
    {
        List<Schedule> GetAllSchedules();
        void AddSchedule(Schedule schedule);
        void AddFlight(int id, Flight flight);
        void ScheduleFlight();
    }
}
