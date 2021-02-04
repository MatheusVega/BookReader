using BookReader.DAL;
using BookReader.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookReader.BLL
{
    public class AuthorBLL
    {
        private BookContext context;

        public AuthorBLL()
        {
            context = new BookContext();
        }

        public void Add(Author author)
        {
            try
            {
                context.TB_AUTHOR.Add(author);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
            }
            
        }
        public IList<Author> IList()
        {
            return context.TB_AUTHOR.ToList();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        


    }
}