using AirTek.Model;

namespace AirTek.Service
{
    internal class OrderWriter : IWriter<OrderWriter>
    {
        IOrder _orderService = null;
        IFlight _flightService = null;
        public OrderWriter(IOrder orderService, IFlight flightService)
        {
            _orderService = orderService;
            _flightService = flightService;
        }
        public void Write()
        {
            var flights = _flightService.GetAllFlights();
            var orders = _orderService.GetOrders();
            Flight flight = null;

            Console.WriteLine("Order Scheduled Status");
            foreach (var order in orders)
            {
                if(flight == null || (flight.Id != order.Value.FlightNo  && order.Value.FlightNo != 0)   )
                    flight = flights.Find(x => x.Id == order.Value.FlightNo);
                if(order.Value.Status == ScheduleStatus.Scheduled)
                    Console.WriteLine($"order: {order.Key}, flightNumber: {order.Value.FlightNo}, departure: {flight.IATASource}, arrival: {flight.IATADestination}, day: {flight.Day}");
                else
                    Console.WriteLine($"order: {order.Key}, flightNumber: {ScheduleStatus.NotScheduled}");
            }
            Console.WriteLine("End of Order Scheduled Status");
        }
    }
}
