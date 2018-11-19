using Livraria.Domain.Livros.Commands;
using System;

namespace Livraria.Test.Stubs.Overrides
{
    public class AdicionarLivroCommandOverride : AdicionarLivroCommand
    {
        public AdicionarLivroCommandOverride(Guid id, string titulo, string descricao, string autor, string editora, int edicao, string iSBN, string idioma)
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
    }
}
