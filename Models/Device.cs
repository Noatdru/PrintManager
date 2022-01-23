namespace PrintManager.Models
{
    public abstract class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

    }
}