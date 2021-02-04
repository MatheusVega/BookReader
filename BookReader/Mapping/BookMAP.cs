using BookReader.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BookReader.Mapping
{
    public class BookMAP : EntityTypeConfiguration<Book>
    {
        public BookMAP()
        {
            ToTable("TB_BOOK");

            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("BK_ID");
            Property(x => x.Name).HasColumnName("BK_NAME");
            Property(x => x.IdAuthor).HasColumnName("BK_AUTID");
            Property(x => x.IdGenre).HasColumnName("BK_GENID");
            Property(x => x.Indication).HasColumnName("BK_INDICATION");
            Property(x => x.Saga).HasColumnName("BK_SAGA");
            Property(x => x.DateCreate).HasColumnName("BK_DATE_CREATE");
            Property(x => x.Flag).HasColumnName("BK_FLAG");

            HasRequired(x => x.Author)
                .WithMany()
                .HasForeignKey(y => y.IdAuthor);

            HasRequired(x => x.Genre)
                .WithMany()
                .HasForeignKey(y => y.IdGenre);

        }
    }
}