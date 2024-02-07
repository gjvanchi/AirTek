using AirTek.Model;
using AirTek.Repository;

internal class FlightService : IFlight
{
    IFlightRepository _flightRepository = null;
    public FlightService(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;   
    }
    public List<Flight> GetAllFlights()
    {
        return _flightRepository.GetAllFlights();
    }
}