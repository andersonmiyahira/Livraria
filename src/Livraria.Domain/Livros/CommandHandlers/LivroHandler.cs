using Livraria.Domain.Core.Bus;
using Livraria.Domain.Core.Notifications;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Livros.CommandHandlers;
using Livraria.Domain.Livros.Commands;
using Livraria.Domain.Livros.Interfaces;
using Livraria.Domain.Livros.Models;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Livraria.Domain.Livros.Handlers
{
    public class LivroHandler : CommandHandler,
                                IRequestHandler<AdicionarLivroCommand>,
                                IRequestHandler<AtualizarLivroCommand>,
                                IRequestHandler<ExcluirLivroCommand>
    {

        private readonly ILivroRepository _livroRepository;
        private readonly IMediatorHandler _mediatr;

        public LivroHandler(IUnitOfWork uow, 
                            IMediatorHandler bus, 
                            INotificationHandler<DomainNotification> notifications,
                            ILivroRepository livroRepository) 
            : base(uow, bus, notifications)
        {
            _livroRepository = livroRepository;
            _mediatr = bus;
        }

        public Task Handle(AdicionarLivroCommand request, CancellationToken cancellationToken)
        {
            // simple fields validations
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.CompletedTask;
            }

            // init domain model
            var livro = new Livro(request.Titulo,
                                  request.Descricao,
                                  request.Autor,
                                  request.Editora,
                                  request.Edicao,
                                  request.ISBN,
                                  request.Idioma);

            // validating book title
            if (_livroRepository.ObterPorTitulo(livro.Titulo).FirstOrDefault() != null)
            {
                _mediatr.RaiseEvent(new DomainNotification(request.MessageType, "Já existe um livro com esse título."));
                return Task.CompletedTask;
            }

            _livroRepository.Add(livro);

            Commit();
            return Task.CompletedTask;
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
