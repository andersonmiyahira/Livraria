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
    public class AdicionarLivroCommandTest
    {
        private Mock<IMediatorHandler> _bus;
        private Mock<ILivroRepository> _livroRepository;
        private Mock<IUnitOfWork> _uow;
        private Mock<DomainNotificationHandler> _notifications;

        public AdicionarLivroCommandTest()
        {
            _bus = new Mock<IMediatorHandler>();
            _livroRepository = new Mock<ILivroRepository>();
            _uow = new Mock<IUnitOfWork>();
            _notifications = new Mock<DomainNotificationHandler>();
        }

        [Fact, Trait("Command", "Command/Livro/AdicionarLivroCommand")]
        public void Command_Valido_Nao_Deve_Exibir_Erro()
        {
            var command = AdicionarLivroCommandStub.LivroValido();

            command.IsValid();

            Assert.True(command.ValidationResult.Errors.Count == default(int));
        }

        [Fact, Trait("Command", "Command/Livro/AdicionarLivroCommand")]
        public void Command_Titulo_Invalido_Deve_Exibir_Erro()
        {
            var command = AdicionarLivroCommandStub.LivroTituloInvalido();

            command.IsValid();

            Assert.True(command.ValidationResult.Errors.Count > default(int));
        }

        [Fact, Trait("Command", "Command/Livro/AdicionarLivroCommand")]
        public void Command_Autor_Invalido_Deve_Exibir_Erro()
        {
            var command = AdicionarLivroCommandStub.LivroAutorInvalido();

            command.IsValid();

            Assert.True(command.ValidationResult.Errors.Count > default(int));
        }

        [Fact, Trait("Command", "Command/Livro/AdicionarLivroCommand")]
        public void Command_Descricao_Invalido_Deve_Exibir_Erro()
        {
            var command = AdicionarLivroCommandStub.LivroDescricaoInvalida();

            command.IsValid();

            Assert.True(command.ValidationResult.Errors.Count > default(int));
        }

        [Fact, Trait("Command", "Command/Livro/AdicionarLivroCommand")]
        public void Command_Editora_Invalido_Deve_Exibir_Erro()
        {
            var command = AdicionarLivroCommandStub.LivroEditoraInvalida();

            command.IsValid();

            Assert.True(command.ValidationResult.Errors.Count > default(int));
        }

        [Fact, Trait("Command", "Command/Livro/AdicionarLivroCommand")]
        public void Command_ISBN_Invalido_Deve_Exibir_Erro()
        {
            var command = AdicionarLivroCommandStub.LivroISBNInvalida();

            command.IsValid();

            Assert.True(command.ValidationResult.Errors.Count > default(int));
        }

        [Fact, Trait("Command", "Command/Livro/AdicionarLivroCommand")]
        public void Livro_Com_Mesmo_Titulo_Deve_Exibir_Erro()
        {
            _livroRepository
               .Setup(x => x.ObterPorTitulo(It.IsAny<string>()))
               .Returns(LivroStub.NovoQueryable());

            var command = AdicionarLivroCommandStub.LivroValido();
            CancellationToken cancellationToken = new CancellationToken();

            var commandHandler = new LivroHandler(_uow.Object, _bus.Object, _notifications.Object, _livroRepository.Object);
            commandHandler.Handle(command, cancellationToken);

            _bus.Verify(x => x.RaiseEvent(It.Is<DomainNotification>(m => m.Key == "AdicionarLivroCommandOverride")), Times.AtLeastOnce());
        }

        [Fact, Trait("Command", "Command/Livro/AdicionarLivroCommand")]
        public void Livro_Com_Titulo_Novo_Nao_Deve_Exibir_Erro()
        {
            _livroRepository
               .Setup(x => x.GetById(It.IsAny<Guid>()))
               .Returns(LivroStub.Novo());

            var command = AdicionarLivroCommandStub.LivroValidoComNovoTitulo();
            CancellationToken cancellationToken = new CancellationToken();

            var commandHandler = new LivroHandler(_uow.Object, _bus.Object, _notifications.Object, _livroRepository.Object);
            commandHandler.Handle(command, cancellationToken);

            _bus.Verify(x => x.RaiseEvent(It.Is<DomainNotification>(m => m.Key == "AdicionarLivroCommandOverride")), Times.Never());
        }
    }
}
