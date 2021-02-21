using BookReader.BLL;
using System.Linq;
using System.Web.Mvc;

namespace BookReader.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AuthorBLL author = new AuthorBLL();
            BookBLL book = new BookBLL();
            GenreBLL genre = new GenreBLL();

            ViewBag.ContAuthor = author.IList().Count();
            ViewBag.ContGenre = genre.List().Count();
            ViewBag.ContBook = book.List().Count();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}