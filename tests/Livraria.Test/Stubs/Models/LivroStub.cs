using Livraria.Domain.Livros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Livraria.Test.Stubs.Models
{
    public class LivroStub
    {
        public static Livro Novo()
        {
            return new Livro("Clean Code - A Handbook of Agile Software Craftsmanship",
                            "Noted software expert Robert C. Martin presents a revolutionary paradigm with Clean Code: A Handbook of Agile Software Craftsmanship ",
                            "",
                            "PEARSON TECHNOLOGY GROUP",
                            1,
                            "9780136083252",
                            "Inglês");
        }

        public static IQueryable<Livro> NovoQueryable()
        {
            return new List<Livro>(){
                            new Livro(
                            "Clean Code - A Handbook of Agile Software Craftsmanship",
                            "Noted software expert Robert C. Martin presents a revolutionary paradigm with Clean Code: A Handbook of Agile Software Craftsmanship ",
                            "",
                            "PEARSON TECHNOLOGY GROUP",
                            1,
                            "9780136083252",
                            "Inglês") }.AsQueryable();
        } 
    }
}
