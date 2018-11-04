using Ninject;
using OnlineBookShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace OnlineBookShop.Core.Lib
{
    public class NinjectResolver : IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        private IKernel _Kernel;
        public NinjectResolver(IKernel kernel)
        {
            this._Kernel = kernel;
        }
        public NinjectResolver() : 
            this(new StandardKernel())
        {
            _Kernel.Bind<IBookrepository>().To<BookService>().InSingletonScope();
            _Kernel.Bind<IGetBook>().To<GetBookService>().InSingletonScope();
        }
        public object GetService(Type serviceType)
        {
            return _Kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _Kernel.GetAll(serviceType);
        }

        public IDependencyScope BeginScope()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
