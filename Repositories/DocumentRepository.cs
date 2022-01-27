using PrintManager.DbContexts;
using PrintManager.Interfaces;
using PrintManager.Models;

namespace PrintManager.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDbContext _context;

        public DocumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(Document document)
        {
            _context.Documents.Remove(document);
            _context.SaveChanges();
        }

        public IQueryable<Document> GetAll()
        {
            return _context.Documents;
        }

        public bool Save(Document document)
        {
            if (document.Content is null)
                document.Content = new byte[0];
            if (document.Id == 0)
            {
                _context.Documents.Add(document);
            }
            else
            {
                var dbEntry = _context.Documents.FirstOrDefault(p => p.Id == document.Id);
                if (dbEntry != null)
                {
                    dbEntry.Content = document.Content;
                    dbEntry.Uri = document.Uri;
                }
            }
            return _context.SaveChanges() > 0;
        }
    }
}