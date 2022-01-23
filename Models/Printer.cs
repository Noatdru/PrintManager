using PrintManager.Interfaces;

namespace PrintManager.Models
{
    public class Printer : Device, IPrinter
    {
        public Task PrintAsync(Document document)
        {
            throw new NotImplementedException();
        }
        public bool CanPrint => true;


    }
}