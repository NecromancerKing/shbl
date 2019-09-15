using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using SHBL.SPT.BASE.Providers;
using System;

namespace SHBL.SPT.ApiFactory.Core
{
    public abstract class FactoryBase<TFactory, TBaseType> : SafeSingletonProvider<TFactory>
        where TFactory : class
    {
        private static readonly object padlock = new object();

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

        public TType Resolve<TType>() where TType : TBaseType, new()
        {
            try
            {
                lock (padlock)
                {
                    if (!this.Container.IsRegistered<TType>())
                    {
                        this.RegisterType<TType>();
                    }

                    return this.Container.Resolve<TType>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected virtual void RegisterType<TRules>()
        {
            Container.RegisterType<TRules>(new ContainerControlledLifetimeManager(),
                                           new Interceptor<VirtualMethodInterceptor>());
        }

        protected virtual void InitializeContainer()
        {
            this._Container = new UnityContainer();
        }
    }

    public abstract class FactoryBase<TFactory, TBaseType, TInterception> : FactoryBase<TFactory, TBaseType>
        where TFactory : class
        where TInterception : IInterceptionBehavior
    {
        protected override void InitializeContainer()
        {
            base.InitializeContainer();
            this.Container.AddNewExtension<Interception>();
        }

        protected override void RegisterType<TRules>()
        {
            Container.RegisterType<TRules>(new ContainerControlledLifetimeManager(),
                                           new Interceptor<VirtualMethodInterceptor>(),
                                           new InterceptionBehavior<TInterception>());
        }
    }
}
