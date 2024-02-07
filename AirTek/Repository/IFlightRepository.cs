using AirTek.Model;

namespace AirTek.Repository
{
    internal interface IFlightRepository
    {
        List<Flight> GetAllFlights();
        void UpdateFlight(List<Flight> flights);
        void AddFlight(List<Flight> flights);
    }
}
