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
    public class quejasController : Controller
    {
        private hotel5Entities4 db = new hotel5Entities4();

        // GET: quejas
        public ActionResult Index()
        {
            return View(db.queja.ToList());
        }

        // GET: quejas/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            queja queja = db.queja.Find(id);
            if (queja == null)
            {
                return HttpNotFound();
            }
            return View(queja);
        }

        // GET: quejas/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: quejas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idQueja,descripcion,fecha,hora")] queja queja)
        {
            if (ModelState.IsValid)
            {
                db.queja.Add(queja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(queja);
        }

        // GET: quejas/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            queja queja = db.queja.Find(id);
            if (queja == null)
            {
                return HttpNotFound();
            }
            return View(queja);
        }

        // POST: quejas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idQueja,descripcion,fecha,hora")] queja queja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(queja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(queja);
        }

        // GET: quejas/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            queja queja = db.queja.Find(id);
            if (queja == null)
            {
                return HttpNotFound();
            }
            return View(queja);
        }

        // POST: quejas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            queja queja = db.queja.Find(id);
            db.queja.Remove(queja);
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
