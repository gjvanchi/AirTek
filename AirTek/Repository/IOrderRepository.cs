using AirTek.Model;

namespace AirTek.Repository
{
    internal interface IOrderRepository
    {
        Dictionary<string,Order> GetAllOrders();
        void AddOrders(Dictionary<string, Order> orders);
    }
}
