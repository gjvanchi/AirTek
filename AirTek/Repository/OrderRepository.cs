using AirTek.Model;

namespace AirTek.Repository
{
    internal class OrderRepository : IOrderRepository
    {
        Dictionary<string, Order> _orders = null;
        public OrderRepository()
        {
            _orders = new Dictionary<string, Order>();   
        }
        public Dictionary<string, Order> GetAllOrders()
        {
            return _orders;
        }

        public void AddOrders(Dictionary<string, Order> orders)
        {
            foreach (var order in orders)
                _orders.TryAdd(order.Key, order.Value);
        }
    }
}
