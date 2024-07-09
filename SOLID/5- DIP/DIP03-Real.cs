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

        public interface IServiceCollection : ISet<IService>
        {

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
            private readonly HashSet<IService> _services = [];

            public int Count { get; }
            public bool IsReadOnly { get; }

            public bool Add(IService item)
                => _services.Add(item);
            public void Clear() => throw new NotImplementedException();
            public bool Contains(IService item) => throw new NotImplementedException();
            public void CopyTo(IService[] array, int arrayIndex) => throw new NotImplementedException();
            public void ExceptWith(IEnumerable<IService> other) => throw new NotImplementedException();
            public IEnumerator<IService> GetEnumerator() => throw new NotImplementedException();
            public void IntersectWith(IEnumerable<IService> other) => throw new NotImplementedException();
            public bool IsProperSubsetOf(IEnumerable<IService> other) => throw new NotImplementedException();
            public bool IsProperSupersetOf(IEnumerable<IService> other) => throw new NotImplementedException();
            public bool IsSubsetOf(IEnumerable<IService> other) => throw new NotImplementedException();
            public bool IsSupersetOf(IEnumerable<IService> other) => throw new NotImplementedException();
            public bool Overlaps(IEnumerable<IService> other) => throw new NotImplementedException();
            public bool Remove(IService item) => throw new NotImplementedException();
            public bool SetEquals(IEnumerable<IService> other) => throw new NotImplementedException();
            public void SymmetricExceptWith(IEnumerable<IService> other) => throw new NotImplementedException();
            public void UnionWith(IEnumerable<IService> other) => throw new NotImplementedException();
            void ICollection<IService>.Add(IService item) => throw new NotImplementedException();
            IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();

            public TService Get<TService>()
                where TService : class, IService
                => (_services.Single(x => x is TService) as TService)!;
        }
    }

	namespace Application1
	{
		public static class Configurator
		{
			public static Domain.IServiceCollection AddApplication1Services(this Domain.IServiceCollection services)
			{
                services.Add(new AccountingService()); // Invalid. Just for learning
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
                services.Add(new AccountingService()); // Invalid. Just for learning
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
