using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CinemaMasters.Models;

namespace CinemaMasters.Controllers
{
    public class ReservierungHasPlaetzeController : Controller
    {
        private CinemaMastersEntities db = new CinemaMastersEntities();

        // GET: ReservierungHasPlaetze
        public ActionResult Index()
        {
            var reservierungHasPlatz = db.ReservierungHasPlatz.Include(r => r.Platz).Include(r => r.Reservierung);
            return View(reservierungHasPlatz.ToList());
        }

        // GET: ReservierungHasPlaetze/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservierungHasPlatz reservierungHasPlatz = db.ReservierungHasPlatz.Find(id);
            if (reservierungHasPlatz == null)
            {
                return HttpNotFound();
            }
            return View(reservierungHasPlatz);
        }

        // GET: ReservierungHasPlaetze/Create
        public ActionResult Create()
        {
            ViewBag.PlatzId = new SelectList(db.Platz, "Id", "Id");
            ViewBag.ReservierungId = new SelectList(db.Reservierung, "Id", "Id");
            return View();
        }

        // POST: ReservierungHasPlaetze/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ReservierungId,PlatzId")] ReservierungHasPlatz reservierungHasPlatz)
        {
            if (ModelState.IsValid)
            {
                db.ReservierungHasPlatz.Add(reservierungHasPlatz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlatzId = new SelectList(db.Platz, "Id", "Id", reservierungHasPlatz.PlatzId);
            ViewBag.ReservierungId = new SelectList(db.Reservierung, "Id", "Id", reservierungHasPlatz.ReservierungId);
            return View(reservierungHasPlatz);
        }

        // GET: ReservierungHasPlaetze/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservierungHasPlatz reservierungHasPlatz = db.ReservierungHasPlatz.Find(id);
            if (reservierungHasPlatz == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlatzId = new SelectList(db.Platz, "Id", "Id", reservierungHasPlatz.PlatzId);
            ViewBag.ReservierungId = new SelectList(db.Reservierung, "Id", "Id", reservierungHasPlatz.ReservierungId);
            return View(reservierungHasPlatz);
        }

        // POST: ReservierungHasPlaetze/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ReservierungId,PlatzId")] ReservierungHasPlatz reservierungHasPlatz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservierungHasPlatz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlatzId = new SelectList(db.Platz, "Id", "Id", reservierungHasPlatz.PlatzId);
            ViewBag.ReservierungId = new SelectList(db.Reservierung, "Id", "Id", reservierungHasPlatz.ReservierungId);
            return View(reservierungHasPlatz);
        }

        // GET: ReservierungHasPlaetze/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservierungHasPlatz reservierungHasPlatz = db.ReservierungHasPlatz.Find(id);
            if (reservierungHasPlatz == null)
            {
                return HttpNotFound();
            }
            return View(reservierungHasPlatz);
        }

        // POST: ReservierungHasPlaetze/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReservierungHasPlatz reservierungHasPlatz = db.ReservierungHasPlatz.Find(id);
            db.ReservierungHasPlatz.Remove(reservierungHasPlatz);
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
