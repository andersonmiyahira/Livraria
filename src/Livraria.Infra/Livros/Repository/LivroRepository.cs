using Livraria.Domain.Livros.Interfaces;
using Livraria.Domain.Livros.Models;
using Livraria.Infra.Data.Context;
using Livraria.Infra.Data.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Livraria.Infra.Livros.Repository
{
    public class LivroRepository : Repository<Livro>, ILivroRepository
    {
        public LivroRepository(LivrariaContext context)
          : base(context)
        {
        } 

        public IQueryable<Livro> ObterPorTitulo(string titulo)
        {
            return DbSet
                      .AsNoTracking()
                      .Where(_ => string.IsNullOrEmpty(titulo) || _.Titulo.ToUpper().Contains(titulo.ToUpper()));
        }

        public override Livro GetById(Guid id)
        {
            return DbSet
                        .AsNoTracking()
                        .FirstOrDefault(_ => _.Id == id);
        }
    }
}
