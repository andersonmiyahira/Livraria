using Livraria.Domain.Core.Bus;
using Livraria.Domain.Core.Notifications;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Livraria.CrossCutting
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            DomainBus(services);
            AppService(services);
            DomainCommand(services);
            DomainEvents(services);
            InfraData(services);
        }

        private static void DomainEvents(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }

        private static void InfraData(IServiceCollection services)
        {
            
        }

        private static void DomainCommand(IServiceCollection services)
        {
           
        }

        private static void AppService(IServiceCollection services)
        {
           
        }

        private static void DomainBus(IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, InMemoryBus>();
        }
    }
}
