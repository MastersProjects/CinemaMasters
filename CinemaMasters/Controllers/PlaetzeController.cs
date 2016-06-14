using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CinemaMasters.Models;

namespace CinemaMasters.Controllers
{
    public class PlaetzeController : Controller
    {
        private CinemaMastersEntities db = new CinemaMastersEntities();

        // GET: Plaetze
        public ActionResult Index()
        {
            var platz = db.Platz.Include(p => p.Reihe);
            return View(platz.ToList());
        }

        // GET: Plaetze/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Platz platz = db.Platz.Find(id);
            if (platz == null)
            {
                return HttpNotFound();
            }
            return View(platz);
        }

        // GET: Plaetze/Create
        public ActionResult Create()
        {
            ViewBag.ReiheId = new SelectList(db.Reihe, "Id", "Id");
            return View();
        }

        // POST: Plaetze/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ReiheId")] Platz platz)
        {
            if (ModelState.IsValid)
            {
                db.Platz.Add(platz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReiheId = new SelectList(db.Reihe, "Id", "Id", platz.ReiheId);
            return View(platz);
        }

        // GET: Plaetze/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Platz platz = db.Platz.Find(id);
            if (platz == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReiheId = new SelectList(db.Reihe, "Id", "Id", platz.ReiheId);
            return View(platz);
        }

        // POST: Plaetze/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ReiheId")] Platz platz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(platz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReiheId = new SelectList(db.Reihe, "Id", "Id", platz.ReiheId);
            return View(platz);
        }

        // GET: Plaetze/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Platz platz = db.Platz.Find(id);
            if (platz == null)
            {
                return HttpNotFound();
            }
            return View(platz);
        }

        // POST: Plaetze/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Platz platz = db.Platz.Find(id);
            db.Platz.Remove(platz);
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
