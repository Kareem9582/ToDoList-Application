using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace ToDoList.Persistence.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            Items = new List<ToDoListItem>();
        }

        [JsonIgnore]
        public virtual ICollection<ToDoListItem> Items { get; set; }
    }
}
