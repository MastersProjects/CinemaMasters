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
    public class ReservationsController : Controller
    {
        private CinemaMastersEntities db = new CinemaMastersEntities();

        // GET: Reservations
        public ActionResult Index()
        {
            var reservierung = db.Reservierung.Include(r => r.Kinobesucher).Include(r => r.Vorstellung);
            return View(reservierung.ToList());
        }

        // GET: Reservations/Details/5
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

        // GET: Reservations/Create
        public ActionResult Create(int? Id)
        {
            if(Id != null)
            {
                ViewBag.SelectedVorstellung = db.Vorstellung.Find(Id);
            }
            ViewBag.KinobesucherId = new SelectList(db.Kinobesucher, "Id", "Name");
            ViewBag.VorstellungId = new SelectList(db.Vorstellung, "Id", "Id");
            return View();
        }

        // POST: Reservations/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,KinobesucherId,VorstellungId")] Reservierung reservierung)
        {
            if (ModelState.IsValid)
            {
                db.Reservierung.Add(reservierung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KinobesucherId = new SelectList(db.Kinobesucher, "Id", "Name", reservierung.KinobesucherId);
            ViewBag.VorstellungId = new SelectList(db.Vorstellung, "Id", "Id", reservierung.VorstellungId);
            return View(reservierung);
        }

        // GET: Reservations/Edit/5
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
            ViewBag.KinobesucherId = new SelectList(db.Kinobesucher, "Id", "Name", reservierung.KinobesucherId);
            ViewBag.VorstellungId = new SelectList(db.Vorstellung, "Id", "Id", reservierung.VorstellungId);
            return View(reservierung);
        }

        // POST: Reservations/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KinobesucherId,VorstellungId")] Reservierung reservierung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservierung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KinobesucherId = new SelectList(db.Kinobesucher, "Id", "Name", reservierung.KinobesucherId);
            ViewBag.VorstellungId = new SelectList(db.Vorstellung, "Id", "Id", reservierung.VorstellungId);
            return View(reservierung);
        }

        // GET: Reservations/Delete/5
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

        // POST: Reservations/Delete/5
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
