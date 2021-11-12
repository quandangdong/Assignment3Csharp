using BusinessObject.Models;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepo
    {
        public void AddNewProduct(Product product) => ProductDAO.Instance.AddNewProduct(product);

        public void DeleteProduct(Product product) => ProductDAO.Instance.DeleteProduct(product);

        public List<Product> GetAllProducts() => ProductDAO.Instance.GetAllProducts();

        public Product GetProductByProductId(int ProductId) => ProductDAO.Instance.GetProductByProductId(ProductId);

        public void UpdateProduct(Product product) => ProductDAO.Instance.UpdateProduct(product);
    }
}
