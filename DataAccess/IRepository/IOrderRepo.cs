using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IOrderRepo
    {
        List<Order> GetAllOrder();
        Order GetOrderByOrderId(int OrderId);
        void AddNewOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
