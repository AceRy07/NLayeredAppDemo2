using Northwind.Bussiunes.Abstract;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bussiunes.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        // PRoductManager new'lendiğinde bana IProductDal türünde bir nesne ver.
        // NHibernate veya EntityFramework herhangi ORM olabilir.
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void AddProducts(Product product)
        {
            _productDal.Add(product);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetProductByPropductName(string productName)
        {
            return _productDal.GetAll(p=>p.ProductName.ToLower().Contains(productName.ToLower()));
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryId);
        }

        public void ProductUpdate(Product product)
        {
            _productDal.Update(product);
        }

        public void ProrductDelete(Product product)
        {
            try
            {
                _productDal.Delete(product);
            }
            catch
            {
                throw new Exception("Silme gerçekleşemedi");
            }
        }
    }
}
