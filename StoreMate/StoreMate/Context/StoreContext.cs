using Microsoft.EntityFrameworkCore;
using StoreMate.Entities;

namespace StoreMate.Context
{
    public class StoreContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;initial Catalog=StoreDb;integrated Security=true;");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Activity> Activitys { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Message> messages { get; set; }
    }
}
