namespace EventApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string? Description { get; set; }
        public DateTime Creted {  get; set; }
        public DateTime Deadline { get; set; }
        public bool IsFinished { get; set; }
        public ItemType Type { get; set; }
        public Person CreatedBy { get; set; }
        public int CreatedById { get; set; }
        public Person? AssignedTo { get; set; }
        public int? AssignedToId { get; set; }
    }
}
