using Microsoft.EntityFrameworkCore; 
using UserService.Api.Model.DomainModels;

namespace UserService.Api.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User {Id=1, EmailId = "abc@gmail.com", Password = "abc" },
                new User {Id=2, EmailId = "def@gmail.com", Password = "def" }
                );
        }

    }

}
