using PrintManager.Enums;

namespace PrintManager.Models
{
    public class PrintQueueElement
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public virtual Document Document { get; set; }
        public Status Status { get; set; }
        public int PrinterId { get; set; }
        public virtual Device Printer { get; set; }
    }
}