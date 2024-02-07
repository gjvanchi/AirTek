using AirTek.Model;

namespace AirTek.Repository
{
    internal interface IScheduleRepository
    {
        List<Schedule> GetSchedules();
        void AddNewSchedule(Schedule schedule);
        void AddFlight(int id, Flight flight);
        
    }
}
