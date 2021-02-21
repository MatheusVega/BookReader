using BookReader.Models;
using System.Data.Entity.ModelConfiguration;

namespace BookReader.Mapping
{
    public class BookReadMAP : EntityTypeConfiguration<BookRead>
    {
        public BookReadMAP()
        {
            ToTable("TB_BOOK_READ");

            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("BKR_ID");
            Property(x => x.IdBK).HasColumnName("BKR_IDBK");
            Property(x => x.Resume).HasColumnName("BKR_RESUME");
            Property(x => x.DateStart).HasColumnName("BKR_DATESTART");
            Property(x => x.DateEnd).HasColumnName("BKR_DATEEND");


            HasRequired(x => x.Book)
                .WithMany()
                .HasForeignKey(y => y.IdBK);

        }
    }
}