using Ninject.Modules;
using Northwind.Bussiunes.Abstract;
using Northwind.Bussiunes.Concrete;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bussiunes.DependencyResolvers.Ninject
{
    public class BusinesModule : NinjectModule
    {
        public override void Load()
        {
            // Eğer biri senden IProductService isterse ProductManager sınıfı döndür. Somut bir productManager oluştur.
            // .InSingletonScope() -> Sadece bir kere üretilir ve uygulama kapanana kadar bellekte kalır.
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();
        }
    }
}
