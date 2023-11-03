using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AAS2237A2.Controllers
{
    public class TracksController : Controller
    {
        private Manager m = new Manager();

        // GET: Tracks
        public ActionResult Index()
        {
            return View(m.TrackGetAll());
        }

        public ActionResult BluesJazz()
        {
            return View("Index", m.TrackGetBluesJazz());

        }

        public ActionResult CantrellStaley()
        {
            return View("Index", m.TrackGetCantrellStaley());
        }

        public ActionResult Top50Longest()
        {          
            return View("Index", m.TrackGetTop50Longest());
        }

        public ActionResult Top50Smallest()
        {
            return View("Index", m.TrackGetTop50Smallest());
        }

    }
}
