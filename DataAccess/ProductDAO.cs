using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{ 
    public class ProductDAO
    {
        private Sales_Management_lab03Context _databaseContext;
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }
        public List<Product> GetAllProducts()
        {
            using(_databaseContext = new Sales_Management_lab03Context())
            {
                return _databaseContext.Products.ToList();
            }
        }

        public Product GetProductByProductId(int ProductId)
        {
            using (_databaseContext = new Sales_Management_lab03Context())
            {
                return _databaseContext.Products.SingleOrDefault<Product>(product => product.ProductId == ProductId);
            }
        }

        public void AddNewProduct(Product product)
        {
            using (_databaseContext = new Sales_Management_lab03Context())
            {
                _databaseContext.Add<Product>(product);
                _databaseContext.SaveChanges();
            }
        }

        public void UpdateProduct(Product product)
        {
            using(_databaseContext = new Sales_Management_lab03Context())
            {
                _databaseContext.Update<Product>(product);
                _databaseContext.SaveChanges();
            }
        }

        public void DeleteProduct(Product product)
        {
            using(_databaseContext = new Sales_Management_lab03Context())
            {
                _databaseContext.Remove<Product>(product);
                _databaseContext.SaveChanges();
            }
        }
    }
}
