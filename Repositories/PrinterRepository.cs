using PrintManager.DbContexts;
using PrintManager.Interfaces;
using PrintManager.Models;

namespace PrintManager.Repositories
{
    public class PrinterRepository : IPrinterRepository
    {
        private readonly ApplicationDbContext _context;

        public PrinterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(Printer printer)
        {
            _context.Printers.Remove(printer);
            _context.SaveChanges();
        }

        public IQueryable<Printer> GetAll()
        {
            return _context.Printers;
        }

        public Printer GetById(int printerId)
        {
            return _context.Printers.Find(printerId);
        }

        public bool Save(Printer printer)
        {
            if (printer.Id == 0)
            {
                _context.Printers.Add(printer);
            }
            else
            {
                var dbEntry = _context.Printers.FirstOrDefault(p => p.Id == printer.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = printer.Name;
                    dbEntry.Location = printer.Location;
                    dbEntry.Description = printer.Description;
                }
            }
            return _context.SaveChanges() > 0;
        }
    }
}