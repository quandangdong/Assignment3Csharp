using BusinessObject.Models;
using System.Collections.Generic;

namespace DataAccess.IRepository
{
    public interface IProductRepo
    {
        List<Product> GetAllProducts();
        Product GetProductByProductId(int ProductId);
        void AddNewProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
