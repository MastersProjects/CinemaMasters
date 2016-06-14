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
    public class KinobesucherController : Controller
    {
        private CinemaMastersEntities db = new CinemaMastersEntities();

        // GET: Kinobesucher
        public ActionResult Index()
        {
            return View(db.Kinobesucher.ToList());
        }

        // GET: Kinobesucher/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kinobesucher kinobesucher = db.Kinobesucher.Find(id);
            if (kinobesucher == null)
            {
                return HttpNotFound();
            }
            return View(kinobesucher);
        }

        // GET: Kinobesucher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kinobesucher/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Vorname,Email,Telefonnummer")] Kinobesucher kinobesucher)
        {
            if (ModelState.IsValid)
            {
                db.Kinobesucher.Add(kinobesucher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kinobesucher);
        }

        // GET: Kinobesucher/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kinobesucher kinobesucher = db.Kinobesucher.Find(id);
            if (kinobesucher == null)
            {
                return HttpNotFound();
            }
            return View(kinobesucher);
        }

        // POST: Kinobesucher/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Vorname,Email,Telefonnummer")] Kinobesucher kinobesucher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kinobesucher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kinobesucher);
        }

        // GET: Kinobesucher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kinobesucher kinobesucher = db.Kinobesucher.Find(id);
            if (kinobesucher == null)
            {
                return HttpNotFound();
            }
            return View(kinobesucher);
        }

        // POST: Kinobesucher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kinobesucher kinobesucher = db.Kinobesucher.Find(id);
            db.Kinobesucher.Remove(kinobesucher);
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
