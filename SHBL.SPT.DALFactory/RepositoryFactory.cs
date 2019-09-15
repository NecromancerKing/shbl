using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using SHBL.SPT.BASE.Providers;
using SHBL.SPT.BASE.Repository;
using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace SHBL.SPT.DALFactory
{
    public class RepositoryFactory : SafeSingletonProvider<RepositoryFactory>
    {
        private RepositoryFactory()
        {

        }

        private static readonly object padlock = new object();

        private string _DLLPath;

        private IUnityContainer _Container;
        protected IUnityContainer Container
        {
            get
            {
                if (_Container == null)
                {
                    lock (padlock)
                    {
                        if (_Container == null)
                        {
                            this.InitializeContainer();
                        }
                    }
                }

                return _Container;
            }
        }

        public TIRepository Resolve<TIRepository>() where TIRepository : IRepository
        {
            try
            {
                lock (padlock)
                {
                    if (!this.Container.IsRegistered<TIRepository>())
                    {
                        Assembly assembly = Assembly.LoadFrom(_DLLPath);
                        var type = assembly.GetTypes().First(t => typeof(TIRepository).IsAssignableFrom(t));

                        var instance = (TIRepository)assembly.CreateInstance(type.FullName);

                        this.RegisterType<TIRepository>(instance);
                    }

                    return this.Container.Resolve<TIRepository>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected virtual void RegisterType<TIRepository>(TIRepository instance) where TIRepository : IRepository
        {
            this.Container.RegisterType<TIRepository>(new ContainerControlledLifetimeManager(),
                                                      new InjectionFactory((c) => instance));
                                                      //new Interceptor<InterfaceInterceptor>(),
                                                      //new InterceptionBehavior<LoggingInterceptionBehavior>());
        }

        protected virtual void InitializeContainer()
        {
            this._Container = new UnityContainer();
            //this._Container.AddNewExtension<Interception>();
        }

        public void Initialize(string dllPath)
        {
            _DLLPath = dllPath;
        }
    }
}