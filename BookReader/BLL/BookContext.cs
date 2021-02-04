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
        public BookContext() : base("Data Source=DESKTOP-UNPN1DK;Initial Catalog=BookReader;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Book> TB_BOOK { get; set; }
        public DbSet<Author> TB_AUTHOR { get; set; }
        public DbSet<Genre> TB_GENRE { get; set; }
        public DbSet<Read> TB_READ { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookMAP());
            modelBuilder.Configurations.Add(new AuthorMAP());
            modelBuilder.Configurations.Add(new GenreMAP());
            modelBuilder.Configurations.Add(new ReadMAP());

            modelBuilder.Entity<Genre>()
              .HasMany(x => x.Authors)
              .WithRequired(y => y.Genre)
              .HasForeignKey(y => y.IdGenre)
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