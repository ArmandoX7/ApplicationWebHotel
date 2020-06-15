using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hotelv3.Models;

namespace hotelv3.Controllers.Aplicacion
{
    public class satisfaccionesController : Controller
    {
        private hotel5Entities db = new hotel5Entities();

        // GET: satisfacciones
        public ActionResult Index()
        {
            return View(db.satisfaccion.ToList());
        }

        // GET: satisfacciones/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            satisfaccion satisfaccion = db.satisfaccion.Find(id);
            if (satisfaccion == null)
            {
                return HttpNotFound();
            }
            return View(satisfaccion);
        }

        // GET: satisfacciones/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: satisfacciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSatisfaccion,descripcion,calificacion,fecha,hora")] satisfaccion satisfaccion)
        {
            if (ModelState.IsValid)
            {
                db.satisfaccion.Add(satisfaccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(satisfaccion);
        }

        // GET: satisfacciones/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            satisfaccion satisfaccion = db.satisfaccion.Find(id);
            if (satisfaccion == null)
            {
                return HttpNotFound();
            }
            return View(satisfaccion);
        }

        // POST: satisfacciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSatisfaccion,descripcion,calificacion,fecha,hora")] satisfaccion satisfaccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(satisfaccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(satisfaccion);
        }

        // GET: satisfacciones/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            satisfaccion satisfaccion = db.satisfaccion.Find(id);
            if (satisfaccion == null)
            {
                return HttpNotFound();
            }
            return View(satisfaccion);
        }

        // POST: satisfacciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            satisfaccion satisfaccion = db.satisfaccion.Find(id);
            db.satisfaccion.Remove(satisfaccion);
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
