using BookReader.BLL;
using BookReader.DAL;
using BookReader.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookReader.Controllers
{
    public class BookController : Controller
    {
        private BookBLL bookBLL;

        public BookController(BookBLL bookBLL)
        {
            this.bookBLL = bookBLL;
        }

        // GET: Book
        public ActionResult Register(Book book)
        {
            ViewBag.listaAut = bookBLL.ListAuthors();
            ViewBag.listaGen = bookBLL.ListGenres();


            return View("Register",book);
        }

        public ActionResult Index(Book book)
        {
            return View(bookBLL.List());
        }

        public ActionResult AddBook(FormCollection form)
        {
            Book book = new Book
            {
                Name = Request.Form["Name"],
                IdAuthor = int.Parse(Request.Form["IdAut"]),
                IdGenre = int.Parse(Request.Form["IdGen"]),
                Indication = Request.Form["Indication"],
                Saga = Request.Form["Saga"],
                DateCreate = DateTime.Today

            };
            Conexao conexao = new Conexao();
            conexao.Conectar();

            ExecutaSP executa = new ExecutaSP("BOOK_SP_INS_BOOK",conexao.VoltaConexaoAberta());
            try {
                executa.addParam("@NAME", book.Name);
                executa.addParam("@IDAUT", book.IdAuthor);
                executa.addParam("@IDGEN", book.IdGenre);
                executa.addParam("@INDICATION", book.Indication);
                executa.addParam("@SAGA", book.Saga.ToString());
                executa.addParam("@DATE", book.DateCreate);

                executa.Executa();
                executa.Confirma();
            }
            catch (Exception ex)
            {

            }
            

            return View();

        }
    }
}