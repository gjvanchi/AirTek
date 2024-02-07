using AirTek.Model;
using AirTek.Repository;

namespace AirTek.Service
{
    internal class OrderService : IOrder
    {
        IOrderRepository _orderRepo;
        public OrderService(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public Dictionary<string, Order> GetOrders()
        {
            return _orderRepo.GetAllOrders();
        }
    }
}
