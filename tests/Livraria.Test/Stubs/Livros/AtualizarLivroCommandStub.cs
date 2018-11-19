using Livraria.Domain.Livros.Commands;
using Livraria.Test.Stubs.Overrides;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Test.Stubs.Livros
{
    public class AtualizarLivroCommandStub
    {
        public static AtualizarLivroCommand LivroSemId()
        {
            return new AtualizarLivroCommandOverride(Guid.Empty);
        }

        public static AtualizarLivroCommand LivroComId()
        {
            return new AtualizarLivroCommandOverride(Guid.NewGuid());
        }

        public static AtualizarLivroCommand LivroComIdInexistente()
        {
            return new AtualizarLivroCommandOverride(Guid.NewGuid());
        }

        public static AtualizarLivroCommand LivroComIdExistente()
        {
            return new AtualizarLivroCommandOverride(Guid.Parse("fe864811-648c-466b-9b2b-a9ef8e26e282"));
        }
    }
}
