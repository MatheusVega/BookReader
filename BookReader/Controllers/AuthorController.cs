using BookReader.BLL;
using BookReader.Models;
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
    }
}