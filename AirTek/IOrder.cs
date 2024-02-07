using AirTek.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTek
{
    internal interface IOrder
    {
        Dictionary<string, Order> GetOrders();
    }
}
