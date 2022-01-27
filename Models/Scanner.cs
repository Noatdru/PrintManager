using PrintManager.Interfaces;

namespace PrintManager.Models
{
    public class Scanner : Device, IScanner
    {
        public async Task<Document> ScanAsync()
        {
            var randomizer = new Random();
            await Task.Delay(2000);
            return new Document
            {
                Uri = $"https://picsum.photos/id/{randomizer.Next(999)}/400/600"
            };
        }
    }
}