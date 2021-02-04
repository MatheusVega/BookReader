using BookReader.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BookReader.Mapping
{
    public class ReadMAP : EntityTypeConfiguration<Read>
    {
        public ReadMAP()
        {
            ToTable("TB_READ");

            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("RD_ID");
            Property(x => x.IdBook).HasColumnName("RD_BKID");
            Property(x => x.DateStart).HasColumnName("RD_DATE_START");
            Property(x => x.DateEnd).HasColumnName("RD_DATE_END");
            Property(x => x.Note).HasColumnName("RD_NOTE");
            Property(x => x.Type).HasColumnName("RD_TYPE");
            Property(x => x.DateCreate).HasColumnName("RD_DATE_CREATE");

            HasRequired(x => x.Book)
                .WithMany()
                .HasForeignKey(y => y.IdBook);

        }
    }
}