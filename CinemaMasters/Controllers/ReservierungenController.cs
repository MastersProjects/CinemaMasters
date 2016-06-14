using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CinemaMasters.Models;

namespace CinemaMasters.Controllers
{
    public class ReservierungenController : Controller
    {
        private CinemaMastersEntities db = new CinemaMastersEntities();

        // GET: Reservierungen
        public ActionResult Index()
        {
            var reservierung = db.Reservierung.Include(r => r.Reihe);
            return View(reservierung.ToList());
        }

        // GET: Reservierungen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservierung reservierung = db.Reservierung.Find(id);
            if (reservierung == null)
            {
                return HttpNotFound();
            }
            return View(reservierung);
        }

        // GET: Reservierungen/Create
        public ActionResult Create()
        {
            ViewBag.ReiheId = new SelectList(db.Reihe, "Id", "Id");
            return View();
        }

        // POST: Reservierungen/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ReiheId")] Reservierung reservierung)
        {
            if (ModelState.IsValid)
            {
                db.Reservierung.Add(reservierung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReiheId = new SelectList(db.Reihe, "Id", "Id", reservierung.ReiheId);
            return View(reservierung);
        }

        // GET: Reservierungen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservierung reservierung = db.Reservierung.Find(id);
            if (reservierung == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReiheId = new SelectList(db.Reihe, "Id", "Id", reservierung.ReiheId);
            return View(reservierung);
        }

        // POST: Reservierungen/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ReiheId")] Reservierung reservierung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservierung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReiheId = new SelectList(db.Reihe, "Id", "Id", reservierung.ReiheId);
            return View(reservierung);
        }

        // GET: Reservierungen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservierung reservierung = db.Reservierung.Find(id);
            if (reservierung == null)
            {
                return HttpNotFound();
            }
            return View(reservierung);
        }

        // POST: Reservierungen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservierung reservierung = db.Reservierung.Find(id);
            db.Reservierung.Remove(reservierung);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
