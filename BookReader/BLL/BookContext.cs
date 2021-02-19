using BookReader.Mapping;
using BookReader.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookReader.BLL
{
    public class BookContext : DbContext
    {
        public BookContext() : base("Server=tcp:book.database.windows.net,1433;Initial Catalog=BookReader;Persist Security Info=False;User ID=matheusveiga;Password=m68695412@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Book> TB_BOOK { get; set; }
        public DbSet<Author> TB_AUTHOR { get; set; }
        public DbSet<Genre> TB_GENRE { get; set; }
        public DbSet<BookRead> TB_BOOK_READ { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookMAP());
            modelBuilder.Configurations.Add(new AuthorMAP());
            modelBuilder.Configurations.Add(new GenreMAP());
            modelBuilder.Configurations.Add(new BookReadMAP());

            modelBuilder.Entity<Genre>()
              .HasMany(x => x.Authors)
              .WithRequired(y => y.Genre)
              .HasForeignKey(y => y.IdGenre)
              .WillCascadeOnDelete();

            modelBuilder.Entity<Book>()
              .HasMany(x => x.BookReads)
              .WithRequired(y => y.Book)
              .HasForeignKey(y => y.IdBK)
              .WillCascadeOnDelete();
        }


        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}