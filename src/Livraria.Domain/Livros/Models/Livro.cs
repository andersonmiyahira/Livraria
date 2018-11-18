﻿using Livraria.Domain.Core.Models;

namespace Livraria.Domain.Livros.Models
{
    public class Livro : Entity
    {
        protected Livro() {  }

        public Livro(string titulo, string descricao, string autor, string editora, int edicao, string iSBN, string idioma)
        {
            Titulo = titulo;
            Descricao = descricao;
            Autor = autor;
            Editora = editora;
            Edicao = edicao;
            ISBN = iSBN;
            Idioma = idioma;
        }

        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Autor { get; private set; }
        public string Editora { get; private set; }
        public int Edicao { get; private set; }
        public string ISBN { get; private set; }
        public string Idioma { get; private set; }
    }
}
