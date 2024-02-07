using AirTek.Model;

namespace AirTek.Repository
{
    internal class ScheduleRepository : IScheduleRepository
    {
        List<Schedule> _schedules;
        public ScheduleRepository()
        {
            _schedules = new List<Schedule>();
        }
        public void AddFlight(int id, Flight flight)
        {
            _schedules.Find(x => x.Day == id).Flights.Add(flight);
        }

        public void AddNewSchedule(Schedule schedule)
        {
            _schedules.Add(schedule);
        }

        public List<Schedule> GetSchedules()
        {
            return _schedules;
        }

    }
}
