using BookReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookReader.BLL
{
    public class BookReadBLL
    {
        private BookContext context;

        public BookReadBLL()
        {
            context = new BookContext();
        }

        public IList<BookRead> List()
        {
            List<BookRead> LisstBookRead = context.TB_BOOK_READ.ToList();

            return LisstBookRead;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}