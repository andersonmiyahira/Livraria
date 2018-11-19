using Livraria.Test.Stubs.Livros;
using Xunit;

namespace Livraria.Test.Domain.Livros.Commands
{
    public class ExcluirLivroCommandTest
    {
        [Fact, Trait("Command", "Command/Livro/ExcluirLivroCommand")]
        public void Command_Sem_Id_Deve_Exibir_Erro()
        {
            var command = ExcluirLivroCommandStub.LivroSemId();

            command.IsValid();

            Assert.True(command.ValidationResult.Errors.Count > default(int));
        }

        [Fact, Trait("Command", "Command/Livro/ExcluirLivroCommand")]
        public void Command_Valido_Nao_Deve_Exibir_Erro()
        {
            var command = ExcluirLivroCommandStub.LivroComId();

            command.IsValid();

            Assert.True(command.ValidationResult.Errors.Count == default(int));
        }
    }
}
