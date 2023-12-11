using System.ComponentModel.DataAnnotations;

namespace ToDoList.Persistence.Entities
{
    public class ToDoListItem
    {
        [Key]
        public Guid ItemId { get; set; }

        [Required]
        public string ItemTitle { get; set; } = string.Empty;

        [Required]
        public string ItemDescription { get; set; } = string.Empty;

        [Required]
        public required User User { get; set; }
        [Required]
        public required string UserId { get; set; }

        public bool IsCompleted { get; set; } = false;

        public DateTime? CompletionDate { get; set; }

    }
}
