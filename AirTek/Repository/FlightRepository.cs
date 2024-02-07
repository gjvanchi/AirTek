using AirTek.Model;

namespace AirTek.Repository
{
    internal class FlightRepository : IFlightRepository
    {
        List<Flight> _flights = null;
        public FlightRepository()
        {
            _flights = new List<Flight>();
        }
        public List<Flight> GetAllFlights()
        {
            return _flights;
        }

        public void UpdateFlight(List<Flight> flights)
        {
            _flights = flights;
        }
        public void AddFlight(List<Flight> flights)
        {
            _flights.AddRange(flights);
        }
    }
}
