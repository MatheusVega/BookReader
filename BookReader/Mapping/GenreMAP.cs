using BookReader.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BookReader.Mapping
{
    public class GenreMAP : EntityTypeConfiguration<Genre>
    {
        public GenreMAP()
        {
            ToTable("TB_GENRE");

            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("GEN_ID");
            Property(x => x.Name).HasColumnName("GEN_NAME");
            Property(x => x.Description).HasColumnName("GEN_DESCRIPTION");
            Property(x => x.DateCreate).HasColumnName("GEN_DATE_CREATE");
        }
    }
}