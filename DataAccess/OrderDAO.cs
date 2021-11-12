using BusinessObject.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class OrderDAO
    {
        private Sales_Management_lab03Context _databaseContext;
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }

        public List<Order> GetAllOrder()
        {
            using (_databaseContext = new Sales_Management_lab03Context())
            {
                return _databaseContext.Orders.ToList();
            }
        }

        public Order GetOrderByOrderId(int OrderId)
        {
            using(_databaseContext = new Sales_Management_lab03Context())
            {
                return _databaseContext.Orders.FirstOrDefault(order => order.OrderId == OrderId);
            }
        }

        public void AddNewOrder(Order order)
        {
            using(_databaseContext = new Sales_Management_lab03Context())
            {
                _databaseContext.Add<Order>(order);
                _databaseContext.SaveChanges();
            }
        }

        public void UpdateOrder(Order order)
        {
            using(_databaseContext = new Sales_Management_lab03Context())
            {
                _databaseContext.Update<Order>(order);
                _databaseContext.SaveChanges();
            }
        }

        public void DeleteOrder(Order order)
        {
            using(_databaseContext = new Sales_Management_lab03Context())
            {
                _databaseContext.Remove<Order>(order);
                _databaseContext.SaveChanges();
            }
        }
    }
}
