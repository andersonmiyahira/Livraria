using Livraria.Domain.Core.Bus;
using Livraria.Domain.Core.Notifications;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Livros.Handlers;
using Livraria.Domain.Livros.Interfaces;
using Livraria.Test.Stubs.Livros;
using Livraria.Test.Stubs.Models;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace Livraria.Test.Domain.Livros.Commands
{
    public class AtualizarLivroCommandTest
    {
        private Mock<IMediatorHandler> _bus;
        private Mock<ILivroRepository> _livroRepository;
        private Mock<IUnitOfWork> _uow;
        private Mock<DomainNotificationHandler> _notifications;

        public AtualizarLivroCommandTest()
        {
            _bus = new Mock<IMediatorHandler>();
            _livroRepository = new Mock<ILivroRepository>();
            _uow = new Mock<IUnitOfWork>();
            _notifications = new Mock<DomainNotificationHandler>();
        }

        [Fact, Trait("Command", "Command/Livro/AtualizarLivroCommand")]
        public void Command_Sem_Id_Deve_Exibir_Erro()
        {
            var command = AtualizarLivroCommandStub.LivroSemId();

            command.IsValid();

            Assert.True(command.ValidationResult.Errors.Count > default(int));
        }

        [Fact, Trait("Command", "Command/Livro/AtualizarLivroCommand")]
        public void Command_Valido_Nao_Deve_Exibir_Erro()
        {
            var command = AtualizarLivroCommandStub.LivroComId();

            command.IsValid();

            Assert.True(command.ValidationResult.Errors.Count == default(int));
        }

        [Fact, Trait("Command", "Command/Livro/AtualizarLivroCommand")]
        public void Livro_Com_Id_Inexistente_Deve_Exibir_Erro()
        {
            _livroRepository
               .Setup(x => x.GetById(It.IsAny<Guid>()))
               .Returns<LivroStub>(null);

            var command = AtualizarLivroCommandStub.LivroComIdInexistente();
            CancellationToken cancellationToken = new CancellationToken();

            var commandHandler = new LivroHandler(_uow.Object, _bus.Object, _notifications.Object, _livroRepository.Object);
            commandHandler.Handle(command, cancellationToken);

            _bus.Verify(x => x.RaiseEvent(It.Is<DomainNotification>(m => m.Key == "AtualizarLivroCommandOverride")), Times.AtLeastOnce());
        }

        [Fact, Trait("Command", "Command/Livro/AtualizarLivroCommand")]
        public void Livro_Com_Id_Existente_Nao_Deve_Exibir_Erro()
        {
            _livroRepository
               .Setup(x => x.GetById(It.IsAny<Guid>()))
               .Returns(LivroStub.Novo());

            var command = AtualizarLivroCommandStub.LivroComIdInexistente();
            CancellationToken cancellationToken = new CancellationToken();

            var commandHandler = new LivroHandler(_uow.Object, _bus.Object, _notifications.Object, _livroRepository.Object);
            commandHandler.Handle(command, cancellationToken);

            _bus.Verify(x => x.RaiseEvent(It.Is<DomainNotification>(m => m.Key == "AtualizarLivroCommandOverride")), Times.Never());
        }
    }
}
