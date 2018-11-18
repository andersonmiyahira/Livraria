using Livraria.Application.AppService.Livros;
using Livraria.Application.AppService.Livros.Interfaces;
using Livraria.Domain.Core.Bus;
using Livraria.Domain.Core.Notifications;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Livros.Commands;
using Livraria.Domain.Livros.Handlers;
using Livraria.Domain.Livros.Interfaces;
using Livraria.Infra.Data.Context;
using Livraria.Infra.Data.UnitOfWork;
using Livraria.Infra.Livros.Repository;
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
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<LivrariaContext>();
        }

        private static void DomainCommand(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarLivroCommand>, LivroHandler>();
            services.AddScoped<IRequestHandler<AtualizarLivroCommand>, LivroHandler>();
            services.AddScoped<IRequestHandler<ExcluirLivroCommand>, LivroHandler>();

        }

        private static void AppService(IServiceCollection services)
        {
            services.AddScoped<ILivroAppService, LivroAppService>();
        }

        private static void DomainBus(IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, InMemoryBus>();
        }
    }
}
