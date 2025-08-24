using Northwind.Entities.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Abstract
{
    // Generic oluşturduğumuz için T harfini kullandık.
    public interface IEntityRepository<T> where T : class, IEntity ,new()
    {
        // Kullanıcı parametre verirse ürün ismi filtreleme
        // filtre=null -> filtre vermeyebilir de
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T GetId(Expression<Func<T,bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}