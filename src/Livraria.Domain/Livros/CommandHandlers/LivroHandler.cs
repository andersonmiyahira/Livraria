using Livraria.Domain.Core.Bus;
using Livraria.Domain.Core.Notifications;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Livros.CommandHandlers;
using Livraria.Domain.Livros.Commands;
using Livraria.Domain.Livros.Interfaces;
using Livraria.Domain.Livros.Models;
using MediatR;
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

        public Task Handle(AdicionarLivroCommand command, CancellationToken cancellationToken)
        {
            // simple fields validations
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Task.CompletedTask;
            }

            // init domain model
            var livro = new Livro(command.Titulo,
                                  command.Descricao,
                                  command.Autor,
                                  command.Editora,
                                  command.Edicao,
                                  command.ISBN,
                                  command.Idioma);

            // validating book title
            if (_livroRepository.ObterPorTitulo(livro.Titulo).FirstOrDefault() != null)
            {
                _mediatr.RaiseEvent(new DomainNotification(command.MessageType, "Já existe um livro com esse título."));
                return Task.CompletedTask;
            }

            _livroRepository.Add(livro);

            Commit();
            return Task.CompletedTask;
        }

        public Task Handle(AtualizarLivroCommand command, CancellationToken cancellationToken)
        {
            // simple fields validations
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Task.CompletedTask;
            }  

            var livro = _livroRepository.GetById(command.Id);
            if(livro == null)
            {
                _mediatr.RaiseEvent(new DomainNotification(command.MessageType, "Livro não encontrado."));
                return Task.CompletedTask;
            }

            //updating data
            livro.Atualizar(command.Titulo, command.Descricao, command.Autor, command.Editora, command.Edicao, command.ISBN, command.Idioma);

            _livroRepository.Update(livro);

            Commit();
            return Task.CompletedTask;
        }

        public Task Handle(ExcluirLivroCommand command, CancellationToken cancellationToken)
        {
            // simple fields validations
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Task.CompletedTask;
            }

            _livroRepository.Remove(command.Id);

            Commit();
            return Task.CompletedTask;

        }
    }
}
