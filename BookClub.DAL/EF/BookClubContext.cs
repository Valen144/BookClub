using BookClub.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookClub.DAL.EF
{
    public class BookClubContext : DbContext
    {
        public BookClubContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookHistory> BookHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>().HasData(
                new Book[]
                {
                    new Book { Id = 1, Name = "Книга №1" },
                    new Book { Id = 2, Name = "Книга №2" },
                    new Book { Id = 3, Name = "Книга №3" },
                    new Book { Id = 4, Name = "Книга №4" }
                }
            );

            builder.Entity<User>().HasData(new User { Id = 1, Name = "User1", Login = "Login" });
            builder.Entity<User>().HasData(new User { Id = 2, Name = "User2", Login = "Login1" });

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=bookclub;Trusted_Connection=True;");
        }
    }
}
