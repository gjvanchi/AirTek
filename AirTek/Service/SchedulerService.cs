using AirTek.Model;
using AirTek.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTek.Service
{
    internal class SchedulerService : ISchedule
    {
        IScheduleRepository _schedulerRepository = null;
        IOrder _orderService = null;
        public SchedulerService(IScheduleRepository scheduleRepository, IOrder orderService)
        {
            _schedulerRepository = scheduleRepository;
            _orderService = orderService;
        }
        public List<Schedule> GetAllSchedules()
        {
            return _schedulerRepository.GetSchedules();
        }
        public void AddSchedule(Schedule schedule) 
        {
            _schedulerRepository.AddNewSchedule(schedule);
        }
        public void AddFlight(int id, Flight flight)
        {
            _schedulerRepository.AddFlight(id, flight);
        }
        public void ScheduleFlight()
        {
            var maxOrder = ConfigurationManager.AppSettings["AircraftCapacity"];
            var schedules = _schedulerRepository.GetSchedules();   
            
            foreach(var shedule in schedules)
            {
                foreach(var flight in shedule.Flights)
                {
                    var unScheduledOrder = _orderService.GetOrders().Where(x => x.Value.Status == ScheduleStatus.NotScheduled && x.Value.Destination == flight.IATADestination).Take(int.Parse(maxOrder));
                    foreach (var item in unScheduledOrder)
                    {
                        item.Value.Status = ScheduleStatus.Scheduled;
                        item.Value.FlightNo = flight.Id;
                    }
                }
            }
            

        }

    }
}
