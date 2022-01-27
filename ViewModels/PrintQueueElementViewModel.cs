using PrintManager.Enums;
using PrintManager.Models;

namespace PrintManager.ViewModels
{
    public class PrintQueueElementViewModel
    {
        public int DocumentId { get; set; }
        public int PrinterId { get; set; }
        public Status Status { get; set; }
        public int Id { get; set; }

        internal static PrintQueueElementViewModel FromPrintQueueElement(PrintQueueElement printQueueElement)
        {
            return new PrintQueueElementViewModel
            {
                DocumentId = printQueueElement.DocumentId,
                PrinterId = printQueueElement.PrinterId,
                Status = printQueueElement.Status,
                Id = printQueueElement.Id
            };
        }
    }
}