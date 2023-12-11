using Microsoft.AspNetCore.Identity;

namespace ToDoList.Persistence.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            Items = new List<ToDoListItem>();
        }
        public virtual ICollection<ToDoListItem> Items { get; set; }
    }
}
