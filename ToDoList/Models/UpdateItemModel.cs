namespace ToDoList.Api.Models
{
    public class UpdateItemModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CompletionDate { get; set; }
    }
}
