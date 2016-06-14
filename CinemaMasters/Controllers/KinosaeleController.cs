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
    public class KinosaeleController : Controller
    {
        private CinemaMastersEntities db = new CinemaMastersEntities();

        // GET: Kinosaele
        public ActionResult Index()
        {
            return View(db.Kinosaal.ToList());
        }

        // GET: Kinosaele/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kinosaal kinosaal = db.Kinosaal.Find(id);
            if (kinosaal == null)
            {
                return HttpNotFound();
            }
            return View(kinosaal);
        }

        // GET: Kinosaele/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kinosaele/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,AnzahlReihe,AnzahlPlaetze")] Kinosaal kinosaal)
        {
            if (ModelState.IsValid)
            {
                db.Kinosaal.Add(kinosaal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kinosaal);
        }

        // GET: Kinosaele/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kinosaal kinosaal = db.Kinosaal.Find(id);
            if (kinosaal == null)
            {
                return HttpNotFound();
            }
            return View(kinosaal);
        }

        // POST: Kinosaele/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,AnzahlReihe,AnzahlPlaetze")] Kinosaal kinosaal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kinosaal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kinosaal);
        }

        // GET: Kinosaele/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kinosaal kinosaal = db.Kinosaal.Find(id);
            if (kinosaal == null)
            {
                return HttpNotFound();
            }
            return View(kinosaal);
        }

        // POST: Kinosaele/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kinosaal kinosaal = db.Kinosaal.Find(id);
            db.Kinosaal.Remove(kinosaal);
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
