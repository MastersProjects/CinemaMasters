using CinemaMasters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaMasters.Controllers
{
    public class HomeController : Controller
    {
        private CinemaMastersEntities db = new CinemaMastersEntities();

        public ActionResult Index()
        {
            DateTime dateTime = DateTime.Now;

            var futureVorstellung = db.Vorstellung.Where(x => x.Zeit > dateTime).Take(10).OrderBy(x => x.Zeit).ToList();

            return View(futureVorstellung);
        }
    }
}