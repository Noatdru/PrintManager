using PrintManager.Interfaces;

namespace PrintManager.Models
{
    public class Copier : Device, ICopier
    {
        public Task PrintAsync(Document document)
        {
            throw new NotImplementedException();
        }

        public Task CopyAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Document> ScanAsync()
        {
            var randomizer = new Random();
            await Task.Delay(3000);
            return new Document
            {
                Uri = $"https://picsum.photos/id/{randomizer.Next(999)}/400/600"
            };
        }

    }
}