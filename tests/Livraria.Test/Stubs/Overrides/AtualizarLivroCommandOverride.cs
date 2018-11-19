using Livraria.Domain.Livros.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Test.Stubs.Overrides
{
    public class AtualizarLivroCommandOverride : AtualizarLivroCommand
    {
        public AtualizarLivroCommandOverride(Guid id, string titulo, string descricao, string autor, string editora, int edicao, string iSBN, string idioma)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Autor = autor;
            Editora = editora;
            Edicao = edicao;
            ISBN = iSBN;
            Idioma = idioma;
        }

        public AtualizarLivroCommandOverride(Guid id)
        {
            Id = id;
        }
    }
}
