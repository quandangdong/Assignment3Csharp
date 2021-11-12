using BusinessObject.Models;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepo
    {
        public void AddNewOrder(Order order) => OrderDAO.Instance.AddNewOrder(order);

        public void DeleteOrder(Order order) => OrderDAO.Instance.DeleteOrder(order);

        public List<Order> GetAllOrder() => OrderDAO.Instance.GetAllOrder();

        public Order GetOrderByOrderId(int OrderId) => OrderDAO.Instance.GetOrderByOrderId(OrderId);

        public void UpdateOrder(Order order) => OrderDAO.Instance.UpdateOrder(order);
    }
}
