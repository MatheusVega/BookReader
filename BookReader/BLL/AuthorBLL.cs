using BookReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public void Remove(string id)
        {
            var list = context.TB_AUTHOR.ToList();
            Author author = list.First(x => x.Id == int.Parse(id));
            context.TB_AUTHOR.Remove(author);
            context.SaveChanges();
        }
        public void Update(Author author)
        {
            var list = context.TB_AUTHOR.ToList();
            var AuthorEdit = list.First(x => x.Id == author.Id);

            AuthorEdit.Id = author.Id ;
            AuthorEdit.Name = author.Name;
            AuthorEdit.IdGenre = author.IdGenre ;
            AuthorEdit.MainSaga = author.MainSaga ;
            AuthorEdit.FavoriteBook = author.FavoriteBook ;
            AuthorEdit.DateCreate = author.DateCreate ;

            context.SaveChanges();
        }
    }
}