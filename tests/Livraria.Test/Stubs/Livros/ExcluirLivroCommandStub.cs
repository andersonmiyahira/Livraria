using Livraria.Domain.Livros.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Test.Stubs.Livros
{
    public class ExcluirLivroCommandStub
    {
        public static ExcluirLivroCommand LivroSemId()
        {
            return new ExcluirLivroCommand(Guid.Empty);
        }

        public static ExcluirLivroCommand LivroComId()
        {
            return new ExcluirLivroCommand(Guid.NewGuid());
        }
    }
}
