using BusinessObject.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        private Sales_Management_lab03Context _databaseContext;

        public List<OrderDetail> GetAllOrderDetail()
        {
            using(_databaseContext = new Sales_Management_lab03Context())
            {
                return _databaseContext.OrderDetails.ToList();
            }
        }

        public OrderDetail GetOrderDetailByOrderId(int OrderId)
        {
            using(_databaseContext = new Sales_Management_lab03Context())
            {
                return _databaseContext.OrderDetails.SingleOrDefault<OrderDetail>(OrderDetail => OrderDetail.OrderId == OrderId);
            }
        }

        public void CreateNewOrderDetail(OrderDetail OrderDetail)
        {
            using(_databaseContext = new Sales_Management_lab03Context())
            {
                _databaseContext.Add<OrderDetail>(OrderDetail);
                _databaseContext.SaveChanges();
            }
        }

        public void UpdateOrderDetail(OrderDetail OrderDetail)
        {
            using(_databaseContext = new Sales_Management_lab03Context())
            {
                _databaseContext.Update<OrderDetail>(OrderDetail);
                _databaseContext.SaveChanges();
            }
        }

        public void DeleteOrderDetail(OrderDetail OrderDetail)
        {
            using(_databaseContext = new Sales_Management_lab03Context())
            {
                _databaseContext.Remove<OrderDetail>(OrderDetail);
                _databaseContext.SaveChanges();
            }
        }
    }
}
