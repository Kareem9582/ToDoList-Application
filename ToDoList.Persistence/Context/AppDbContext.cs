using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoList.Persistence.Entities;

namespace ToDoList.Context
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
            Database.EnsureCreated(); 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ToDoListItem>()
                .HasOne(op => op.User)
                .WithMany(p => p.Items)
                .HasForeignKey(op => op.UserId);
        }
        public DbSet<ToDoListItem> Items { get; set; }
    }
}
