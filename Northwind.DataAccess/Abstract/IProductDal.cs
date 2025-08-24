using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Abstract
{
    // IEntityRepository'den miras alırız ve generic yapı
    // kullandığımız için bir Tablo adı gibi değer almamız gerekir
    // Product gibi
    public interface IProductDal : IEntityRepository<Product>
    {
        #region 32.Ders ile İşlemi bitti
        // Buradaki işlemin temel bitme sebebi Aynı CRUD işlemleri
        // Diğer ORM'ler içinde aynı olduğu için EF'den bağımsız
        // halen getirilecek temel ihtiyaç olarak.
        /*
        List<Product> GetAll();
        Product GetId(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        */
        #endregion

    }
}
