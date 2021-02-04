using BookReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookReader.BLL
{
    public class ReadBLL
    {
        private BookContext context;

        public ReadBLL(BookContext context)
        {
            this.context = context;
        }

        public void Add(Read read)
        {
            context.TB_READ.Add(read);
            context.SaveChanges();
        }
        public IList<Read> List()
        {
            return context.TB_READ.ToList();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}