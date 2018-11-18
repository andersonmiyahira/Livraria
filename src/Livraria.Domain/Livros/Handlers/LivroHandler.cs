using Livraria.Domain.Core.Bus;
using Livraria.Domain.Core.Notifications;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Livros.CommandHandlers;
using Livraria.Domain.Livros.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Livraria.Domain.Livros.Handlers
{
    public class LivroHandler : CommandHandler,
                                IRequestHandler<AdicionarLivroCommand>,
                                IRequestHandler<AtualizarLivroCommand>,
                                IRequestHandler<ExcluirLivroCommand>
    {
        public LivroHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) 
            : base(uow, bus, notifications)
        {
        }

        public Task Handle(AdicionarLivroCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Handle(AtualizarLivroCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Handle(ExcluirLivroCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
