using PrintManager.Interfaces;

namespace PrintManager.Models
{
    public class Printer : Device, IPrinter
    {
        public async Task PrintAsync(Document document)
        {
            Console.WriteLine($"Printing document {document?.Uri}");
        }

    }
}