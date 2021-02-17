using BookReader.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookReader.Controllers
{
    public class BookReadController : Controller
    {
        private BookReadBLL bookReadBLL;
        // GET: BookRead
        public BookReadController(BookReadBLL bookReadBLL)
        {
            this.bookReadBLL = bookReadBLL;
        }

        public ActionResult Index()
        {
            return View(bookReadBLL.List());
        }
    }
}