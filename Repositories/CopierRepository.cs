using PrintManager.DbContexts;
using PrintManager.Interfaces;
using PrintManager.Models;

namespace PrintManager.Repositories
{
    public class CopierRepository : ICopierRepository
    {
        private readonly ApplicationDbContext _context;

        public CopierRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(Copier copier)
        {
            _context.Copiers.Remove(copier);
            _context.SaveChanges();
        }

        public IQueryable<Copier> GetAll()
        {
            return _context.Copiers;
        }

        public Copier GetById(int scannerId)
        {
            return _context.Copiers.FirstOrDefault(p => p.Id == scannerId);
        }

        public bool Save(Copier copier)
        {
            if (copier.Id == 0)
            {
                _context.Copiers.Add(copier);
            }
            else
            {
                var dbEntry = _context.Scanners.FirstOrDefault(p => p.Id == copier.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = copier.Name;
                    dbEntry.Location = copier.Location;
                    dbEntry.Description = copier.Description;
                }
            }
            return _context.SaveChanges() > 0;
        }

    }
}