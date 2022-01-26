using PrintManager.DbContexts;
using PrintManager.Interfaces;
using PrintManager.Models;

namespace PrintManager.Repositories
{
    public class ScannerRepository : IScannerRepository
    {
        private readonly ApplicationDbContext _context;

        public ScannerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(Scanner scanner)
        {
            _context.Scanners.Remove(scanner);
            _context.SaveChanges();
        }

        public IQueryable<Scanner> GetAll()
        {
            return _context.Scanners;
        }

        public bool Save(Scanner scanner)
        {
            if (scanner.Id == 0)
            {
                _context.Scanners.Add(scanner);
            }
            else
            {
                var dbEntry = _context.Scanners.FirstOrDefault(p => p.Id == scanner.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = scanner.Name;
                    dbEntry.Location = scanner.Location;
                    dbEntry.Description = scanner.Description;
                }
            }
            return _context.SaveChanges() > 0;
        }

    }
}