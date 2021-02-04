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
    public class BookBLL
    {
        private BookContext context;

        public BookBLL()
        {
            context = new BookContext();
        }

        public void Add(Book livro)
        {
            context.TB_BOOK.Add(livro);
            context.SaveChanges();
        }
        public IList<Book> List()
        {
            return context.TB_BOOK.ToList();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public DataTable Authors()
        {
            Conexao conexao = new Conexao();
            conexao.Conectar();

            SelectSP selAuthor = new SelectSP("BOOK_SP_SEL_AUTHORS", conexao.VoltaConexaoAberta());
            selAuthor.Executa();

            return selAuthor.sDataTable;
        }

        public List<SelectListItem> ListAuthors()
        {
            List<SelectListItem> listAuthor = new List<SelectListItem>();
            SelectSP selAuthor = new SelectSP("BOOK_SP_SEL_AUTHORS");
            selAuthor.Executa();

            foreach (DataRow author in selAuthor.sDataTable.Rows)
            {
                listAuthor.Add(new SelectListItem
                {
                    Value = author.Field<int>("AUT_ID").ToString(),
                    Text = author.Field<string>("AUT_NAME")
                });
            }

            return listAuthor;
        }

        public List<SelectListItem> ListGenres()
        {
            List<SelectListItem> listGenre = new List<SelectListItem>();
            SelectSP selGenre = new SelectSP("BOOK_SP_SEL_GENRES");
            selGenre.Executa();

            foreach (DataRow genre in selGenre.sDataTable.Rows)
            {
                listGenre.Add(new SelectListItem
                {
                    Value = genre.Field<int>("GEN_ID").ToString(),
                    Text = genre.Field<string>("GEN_NAME")
                });
            }

            return listGenre;
        }
    }
}