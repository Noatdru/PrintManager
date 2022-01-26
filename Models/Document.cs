namespace PrintManager.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Uri { get; set; }
        public byte[] Content { get; set; }
    }
}