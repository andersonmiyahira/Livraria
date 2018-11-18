using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Livros.Commands
{
    public class AtualizarLivroCommand : LivroCommand
    {
        public override bool IsValid()
        {
            return true;
            //throw new NotImplementedException();
        }
    }
}
