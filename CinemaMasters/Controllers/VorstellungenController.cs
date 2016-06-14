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
    public class VorstellungenController : Controller
    {
        private CinemaMastersEntities db = new CinemaMastersEntities();

        // GET: Vorstellungen
        public ActionResult Index()
        {
            var vorstellung = db.Vorstellung.Include(v => v.Film);
            return View(vorstellung.ToList());
        }

        // GET: Vorstellungen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vorstellung vorstellung = db.Vorstellung.Find(id);
            if (vorstellung == null)
            {
                return HttpNotFound();
            }
            return View(vorstellung);
        }

        // GET: Vorstellungen/Create
        public ActionResult Create()
        {
            ViewBag.FilmId = new SelectList(db.Film, "Id", "Titel");
            return View();
        }

        // POST: Vorstellungen/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Zeit,FilmId")] Vorstellung vorstellung)
        {
            if (ModelState.IsValid)
            {
                db.Vorstellung.Add(vorstellung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FilmId = new SelectList(db.Film, "Id", "Titel", vorstellung.FilmId);
            return View(vorstellung);
        }

        // GET: Vorstellungen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vorstellung vorstellung = db.Vorstellung.Find(id);
            if (vorstellung == null)
            {
                return HttpNotFound();
            }
            ViewBag.FilmId = new SelectList(db.Film, "Id", "Titel", vorstellung.FilmId);
            return View(vorstellung);
        }

        // POST: Vorstellungen/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Zeit,FilmId")] Vorstellung vorstellung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vorstellung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FilmId = new SelectList(db.Film, "Id", "Titel", vorstellung.FilmId);
            return View(vorstellung);
        }

        // GET: Vorstellungen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vorstellung vorstellung = db.Vorstellung.Find(id);
            if (vorstellung == null)
            {
                return HttpNotFound();
            }
            return View(vorstellung);
        }

        // POST: Vorstellungen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vorstellung vorstellung = db.Vorstellung.Find(id);
            db.Vorstellung.Remove(vorstellung);
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
