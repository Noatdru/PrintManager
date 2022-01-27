using PrintManager.Models;

namespace PrintManager.ViewModels
{
    public class DocumentViewModel
    {
        public int Id { get; set; }
        public string Uri { get; set; }
        public int Length { get; set; }
        private DocumentViewModel()
        {
        }
        public static DocumentViewModel FromDocument(Document document)
        {
            return new DocumentViewModel
            {
                Id = document.Id,
                Uri = document.Uri,
                Length = document.Content.Length
            };
        }
    }
}