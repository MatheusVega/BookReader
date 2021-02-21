using BookReader.Models;
using System.Data.Entity.ModelConfiguration;

namespace BookReader.Mapping
{
    public class AuthorMAP : EntityTypeConfiguration<Author>
    {
        public AuthorMAP()
        {
            ToTable("TB_AUTHOR");

            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("AUT_ID");
            Property(x => x.Name).HasColumnName("AUT_NAME");
            Property(x => x.IdGenre).HasColumnName("AUT_GENID");
            Property(x => x.MainSaga).HasColumnName("AUT_MAIN_SAGA");
            Property(x => x.FavoriteBook).HasColumnName("AUT_FAVORITE_BOOK");
            Property(x => x.DateCreate).HasColumnName("AUT_DATE_CREATE");


            HasRequired(x => x.Genre)
              .WithMany()
              .HasForeignKey(y => y.IdGenre);

        }
    }
}