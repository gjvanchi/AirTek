using AirTek.Model;
using System.Configuration;
using System.Text.Json;
using AirTek.Repository;

namespace AirTek.Service
{
    internal class JSONFileReader : IFileRead<JSONFileReader>
    {
        IOrderRepository _orderRepository = null;
        public JSONFileReader(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public void Read()
        {
            if(!File.Exists(ConfigurationManager.AppSettings["coding-assignment-orders"]))
            {
                Console.WriteLine($"File {ConfigurationManager.AppSettings["coding-assignment-orders"]} Not Available. Please check");
                return;
            }
            try
            {
                var data = File.ReadAllText(ConfigurationManager.AppSettings["coding-assignment-orders"]);
                var serializationOptions = new System.Text.Json.JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var orders = JsonSerializer.Deserialize<Dictionary<string, Order>>(data, serializationOptions);
                _orderRepository.AddOrders(orders);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
