using BookReader.BLL;
using BookReader.Models;
using System.Web.Mvc;

namespace BookReader.Controllers
{
    public class GenreController : Controller
    {
        private GenreBLL genreBLL;

        public GenreController(GenreBLL genreBLL)
        {
            this.genreBLL = genreBLL;
        }
        // GET: Genre
        public ActionResult Index(Genre genre)
        {
            return View(genreBLL.List());
        }
        public ActionResult Register(Genre genre)
        {
            return View(genre);
        }

        public ActionResult AddGenre(Genre genre)
        {
            if (ModelState.IsValid)
            {
                genreBLL.Add(genre);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Register", genre);
            }
        }
        public void RemoveGenre(string id)
        {
            GenreBLL genreBLL = new GenreBLL();
            genreBLL.Remove(id);
        }
    }
}