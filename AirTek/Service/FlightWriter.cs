
namespace AirTek.Service
{
    internal class FlightWriter : IWriter<FlightWriter>
    {
        IFlight _flightService;
        public FlightWriter(IFlight flightService)
        {
            _flightService = flightService;
        }
        public void Write()
        {
            var flights = _flightService.GetAllFlights();
            Console.WriteLine("Flight Schedule Info");
            foreach(var flight in flights)
            {
                Console.WriteLine($"Flight: {flight.Id}, departure: {flight.IATASource}, arrival: {flight.IATADestination}, day: {flight.Day}");
            }
            Console.WriteLine("End of Flight Schedule Info");
        }
    }
}
