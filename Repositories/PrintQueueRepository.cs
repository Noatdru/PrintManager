using PrintManager.DbContexts;
using PrintManager.Enums;
using PrintManager.Interfaces;
using PrintManager.Models;

namespace PrintManager.Repositories
{
    public class PrintQueueRepository : IPrintQueueRepository
    {
        private readonly ApplicationDbContext _context;

        public PrintQueueRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void ChangeStatus(int PrintQueueElementId, Status status)
        {
            var element = _context.PrintQueueElements.FirstOrDefault(p => p.Id == PrintQueueElementId);
            if (element is null)
                return;
            element.Status = status;
            _context.SaveChanges();
        }

        public IQueryable<PrintQueueElement> GetAll()
        {
            return _context.PrintQueueElements;
        }

        public PrintQueueElement GetById(int printQueueElementId)
        {
            return _context.PrintQueueElements.FirstOrDefault(p => p.Id == printQueueElementId);
        }

        public bool Save(PrintQueueElement printQueueElement)
        {
            var element = _context.PrintQueueElements.FirstOrDefault(p => p.Id == printQueueElement.Id);
            if (element is null)
            {
                _context.PrintQueueElements.Add(printQueueElement);
            }
            else
            {
                element.Status = printQueueElement.Status;
                element.DocumentId = printQueueElement.DocumentId;
                element.PrinterId = printQueueElement.PrinterId;
            }
            return _context.SaveChanges() > 0;
        }
    }
}