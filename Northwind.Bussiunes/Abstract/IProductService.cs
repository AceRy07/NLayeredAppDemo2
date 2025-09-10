using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bussiunes.Abstract
{
    public interface IProductService
    {
        void AddProducts(Product product);
        List<Product> GetAll();
        List<Product> GetProductByPropductName(string productName);
        List<Product> GetProductsByCategory(int categoryId);
        void ProductUpdate(Product product);
    }
}
