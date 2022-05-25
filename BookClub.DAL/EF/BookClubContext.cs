using BookClub.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookClub.DAL.EF
{
    public class BookClubContext : DbContext
    {
        public BookClubContext()
        {
            Database.EnsureCreated();
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
                    new Book { Id = 4, Name = "Книга №4" },
                    new Book { Id = 5, Name = "Книга №5" },
                }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=bookclub;Trusted_Connection=True;");
        }
    }
}
