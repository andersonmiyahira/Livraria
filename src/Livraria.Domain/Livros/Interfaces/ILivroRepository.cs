using Livraria.Domain.Interfaces;
using Livraria.Domain.Livros.Models;
using System.Linq;

namespace Livraria.Domain.Livros.Interfaces
{
    public interface ILivroRepository : IRepository<Livro>
    {
        IQueryable<Livro> ObterPorTitulo(string titulo);
    }
}
