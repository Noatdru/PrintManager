using PrintManager.DbContexts;
using PrintManager.Interfaces;

namespace PrintManager.Repositories
{
    public class PrinterRepository : IPrinterRepository
    {
        private readonly ApplicationDbContext _context;

        public PrinterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<IPrinter> GetAll()
        {
            var printers = _context.Printers.ToList<IPrinter>();
            var copiers = _context.Copiers.ToList<IPrinter>();
            return printers.Union(copiers).AsQueryable();
        }

    }
}