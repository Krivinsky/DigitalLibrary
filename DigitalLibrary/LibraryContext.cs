using DigitalLibrary.Model;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary
{
    public class LibraryContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }

        public LibraryContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=SAMSUNG\SQLEXPRESS;Database=DigitalLibrary;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
