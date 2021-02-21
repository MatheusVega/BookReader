using BookReader.BLL;
using BookReader.Models;
using Newtonsoft.Json.Linq;
using System;
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


            return View("Register", book);
        }

        public ActionResult Index(Book book)
        {
            return View();
        }

        public ActionResult AddBook(FormCollection form)
        {
            BookBLL bookBLL = new BookBLL();

            Book book = new Book
            {
                Name = Request.Form["Name"],
                IdAuthor = int.Parse(Request.Form["IdAut"]),
                IdGenre = int.Parse(Request.Form["IdGen"]),
                Indication = Request.Form["Indication"],
                Saga = Request.Form["Saga"],
                DateCreate = DateTime.Today

            };

            bookBLL.AddBook(book);

            return RedirectToAction("Index");

        }

        public JArray GetBook()
        {
            BookBLL bookBLL = new BookBLL();

            return bookBLL.GetBook();
        }
        public ActionResult AddBookRead(int id, string resume, DateTime start, DateTime end)
        {
            BookBLL bookBLL = new BookBLL();

            bookBLL.AddBookRead(id, resume, start, end);

            return RedirectToAction("Index");
        }
    }
}