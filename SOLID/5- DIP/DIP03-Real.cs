using System.Collections;

using SOLID.DIP03.Application1;
using SOLID.DIP03.Application2;
using SOLID.DIP03.Domain;

namespace SOLID.DIP03
{
	namespace Domain
	{
		public interface IService
		{

		}

        public interface IServiceCollection
        {
            IServiceCollection Add<TService, TImplementation>(Func<TImplementation> getImplementation)
                where TImplementation : class;
            
            IServiceCollection Add<TImplementation>(Func<TImplementation> getImplementation)
                where TImplementation : class;
            
            IServiceCollection Add<TService, TImplementation>()
                where TImplementation : class, new();
            IServiceCollection Add<TImplementation>()
                where TImplementation : class, new();
            IServiceCollection Add<TService>(Func<object> getImplementation);
            
            TService Get<TService>()
                where TService : class;
        }

        public interface IAccountingService : IService
        {
            void Register(/*..*/);
        }
    }

	namespace Infrastructure
	{
        public class ServiceCollection : IServiceCollection
        {
            private readonly Dictionary<Type, Func<object>> _services = [];

            public IServiceCollection Add<TService, TImplementation>(Func<TImplementation> getImplementation)
                where TImplementation : class => Add(typeof(TService), getImplementation);

            public IServiceCollection Add<TService, TImplementation>()
                where TImplementation : class, new() => Add<TService, TImplementation>(() => new TImplementation());

            public IServiceCollection Add<TImplementation>()
                where TImplementation : class, new() => Add(typeof(TImplementation), () => new TImplementation());

            public IServiceCollection Add<TImplementation>(Func<TImplementation> getImplementation)
                where TImplementation : class => Add(typeof(TImplementation), getImplementation);

            public IServiceCollection Add<TService>(Func<object> getImplementation)
                => Add(typeof(TService), getImplementation);

            private IServiceCollection Add<TImplementation>(Type service, Func<TImplementation> getImplementation)
                where TImplementation: class
            {
                /* Add to _services */
                return this;
            }

            public TService Get<TService>()
                where TService : class
                => (_services.Single(x => x.Key is TService).Value() as TService)!;            
        }
    }

	namespace Application1
	{
		public static class Configurator
		{
			public static Domain.IServiceCollection AddApplication1Services(this Domain.IServiceCollection services)
			{
                services.Add<IAccountingService>(() => new AccountingService());
                return services;
			}
        }

        class AccountingService : IAccountingService
        {
            public void Register() { /* Save using Ef */}
        }
    }

	namespace Application2
	{
        public static class Configurator
        {
            public static Domain.IServiceCollection AddApplication2Services(this Domain.IServiceCollection services)
            {
                services.Add(()=>new AccountingService()); // Invalid. Just for learning
                return services;
            }
        }

        class AccountingService : IAccountingService
        {
            public void Register() { /* Save using Dapper */}
        }
    }

    namespace Presentation
    {
        public class WebApplication
        {
            public void Startup()
            {
                var services = new Infrastructure.ServiceCollection();
                //services.AddApplication1Services();
                services.AddApplication2Services();                
            }
        }
    }
}
