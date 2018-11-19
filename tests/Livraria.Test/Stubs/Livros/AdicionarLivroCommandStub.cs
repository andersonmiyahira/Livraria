using Livraria.Domain.Livros.Commands;
using Livraria.Test.Stubs.Overrides;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Test.Stubs.Livros
{
    public class AdicionarLivroCommandStub : AdicionarLivroCommand
    {
        public static AdicionarLivroCommand LivroValido()
        {
            return new AdicionarLivroCommandOverride(Guid.NewGuid(),
                                                     "Clean Code - A Handbook of Agile Software Craftsmanship",
                                                     "Noted software expert Robert C. Martin presents a revolutionary paradigm with Clean Code: A Handbook of Agile Software Craftsmanship ",
                                                     "Martin,Robert C.",
                                                     "PEARSON TECHNOLOGY GROUP",
                                                     1,
                                                     "9780136083252",
                                                     "Inglês");
        }

        public static AdicionarLivroCommand LivroValidoComNovoTitulo()
        {
            return new AdicionarLivroCommandOverride(Guid.NewGuid(),
                                                     "Clean Code - A Handbook of Agile Software Craftsmanship 2",
                                                     "Noted software expert Robert C. Martin presents a revolutionary paradigm with Clean Code: A Handbook of Agile Software Craftsmanship ",
                                                     "Martin,Robert C.",
                                                     "PEARSON TECHNOLOGY GROUP",
                                                     1,
                                                     "9780136083252",
                                                     "Inglês");
        }

        public static AdicionarLivroCommand LivroTituloInvalido()
        {
            return new AdicionarLivroCommandOverride(Guid.NewGuid(),
                                                     "",
                                                     "Noted software expert Robert C. Martin presents a revolutionary paradigm with Clean Code: A Handbook of Agile Software Craftsmanship ",
                                                     "Martin,Robert C.",
                                                     "PEARSON TECHNOLOGY GROUP",
                                                     1,
                                                     "9780136083252",
                                                     "Inglês");
        }

        public static AdicionarLivroCommand LivroDescricaoInvalida()
        {
            return new AdicionarLivroCommandOverride(Guid.NewGuid(),
                                                     "Clean Code - A Handbook of Agile Software Craftsmanship",
                                                     "",
                                                     "Martin,Robert C.",
                                                     "PEARSON TECHNOLOGY GROUP",
                                                     1,
                                                     "9780136083252",
                                                     "Inglês");
        }

        public static AdicionarLivroCommand LivroAutorInvalido()
        {
            return new AdicionarLivroCommandOverride(Guid.NewGuid(),
                                                     "Clean Code - A Handbook of Agile Software Craftsmanship",
                                                     "Noted software expert Robert C. Martin presents a revolutionary paradigm with Clean Code: A Handbook of Agile Software Craftsmanship ",
                                                     "",
                                                     "PEARSON TECHNOLOGY GROUP",
                                                     1,
                                                     "9780136083252",
                                                     "Inglês");
        }

        public static AdicionarLivroCommand LivroEditoraInvalida()
        {
            return new AdicionarLivroCommandOverride(Guid.NewGuid(),
                                                     "Clean Code - A Handbook of Agile Software Craftsmanship",
                                                     "Noted software expert Robert C. Martin presents a revolutionary paradigm with Clean Code: A Handbook of Agile Software Craftsmanship ",
                                                     "Martin,Robert C.",
                                                     "",
                                                     1,
                                                     "9780136083252",
                                                     "Inglês");
        }

        public static AdicionarLivroCommand LivroISBNInvalida()
        {
            return new AdicionarLivroCommandOverride(Guid.NewGuid(),
                                                     "Clean Code - A Handbook of Agile Software Craftsmanship",
                                                     "Noted software expert Robert C. Martin presents a revolutionary paradigm with Clean Code: A Handbook of Agile Software Craftsmanship ",
                                                     "Martin,Robert C.",
                                                     "",
                                                     1,
                                                     "",
                                                     "Inglês");
        }
    }
}
