using Livraria.Domain.Interfaces;
using Livraria.Infra.Data.Context;

namespace Livraria.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LivrariaContext _context;

        public UnitOfWork(LivrariaContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
