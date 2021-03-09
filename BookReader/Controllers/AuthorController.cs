using BookReader.BLL;
using BookReader.Models;
using System;
using System.Web.Mvc;

namespace BookReader.Controllers
{
    public class AuthorController : Controller
    {
        public AuthorBLL authorBLL;
        public GenreBLL genreBLL;
        public BookContext bookContext;


        public AuthorController()
        {
            authorBLL = new AuthorBLL();
            genreBLL = new GenreBLL();
            bookContext = new BookContext();
        }
        // GET: Author
        public ActionResult Index(Author author)
        {
            GenreBLL genreBLL = new GenreBLL();
            ViewBag.Genre = genreBLL.List();

            return View(authorBLL.IList());
        }

        public ActionResult RegisterAuthor(Author author)
        {
            GenreBLL genreBLL = new GenreBLL();
            ViewBag.Genre = genreBLL.List();

            return View("Register", author);
        }

        public ActionResult AddAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
                authorBLL.Add(author);
                return RedirectToAction("Index");

            }
            else
            {
                return View("Index", author);
            }
        }
        public void RemoveAuthor(string id)
        {
            AuthorBLL author = new AuthorBLL();
            author.Remove(id);
        }
        public void UpdateAuthor(int id, string name, int idGenre,string mainSaga,string favoriteBook, DateTime date)
        {
            AuthorBLL authorBLL = new AuthorBLL();
            Author author = new Author();
            author.Id = id;
            author.Name = name;
            author.IdGenre = idGenre;
            author.MainSaga = mainSaga;
            author.FavoriteBook = favoriteBook;
            author.DateCreate = date;

            authorBLL.Update(author);
        }

    }
}