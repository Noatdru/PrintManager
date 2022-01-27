
using PrintManager.Models;

namespace PrintManager.Interfaces
{
    public interface IDocumentRepository
    {
        IQueryable<Document> GetAll();
        bool Save(Document document);
        void Delete(Document document);
    }
}