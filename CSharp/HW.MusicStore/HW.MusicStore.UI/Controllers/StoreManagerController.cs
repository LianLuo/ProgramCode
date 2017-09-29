using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW.MusicStore.Models;

namespace HW.MusicStore.UI.Controllers
{
    public class StoreManagerController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Album> list = new List<Album>();

            return View(list);
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View("Index");
        }

        public ActionResult Modify()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Modify(Album album)
        {
            if (ModelState.IsValid)
            {
                return View("Index");
            }
            return View(album);
        }

        public ActionResult Details(int id)
        {
            return View();
        }
    }
}