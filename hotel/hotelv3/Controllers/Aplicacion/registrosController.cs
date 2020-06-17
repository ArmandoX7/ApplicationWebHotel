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
    public class registrosController : Controller
    {
        private hotel5Entities4 db = new hotel5Entities4();

        // GET: registros
        public ActionResult Index()
        {
            var registro = db.registro.Include(r => r.habitacion).Include(r => r.huesped);
            return View(registro.ToList());
        }

        // GET: registros/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro registro = db.registro.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            return View(registro);
        }

        // GET: registros/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.idHabitacion = new SelectList(db.habitacion, "idHabitacion", "idHabitacion");
            ViewBag.idHuesped = new SelectList(db.huesped, "idHuesped", "nombres");
            return View();
        }

        // POST: registros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRegistro,idHuesped,idHabitacion,fecha,hora,dias,descuento")] registro registro)
        {
            if (ModelState.IsValid)
            {
                db.registro.Add(registro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idHabitacion = new SelectList(db.habitacion, "idHabitacion", "tipo", registro.idHabitacion);
            ViewBag.idHuesped = new SelectList(db.huesped, "idHuesped", "nombres", registro.idHuesped);
            return View(registro);
        }

        // GET: registros/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro registro = db.registro.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            ViewBag.idHabitacion = new SelectList(db.habitacion, "idHabitacion", "tipo", registro.idHabitacion);
            ViewBag.idHuesped = new SelectList(db.huesped, "idHuesped", "nombres", registro.idHuesped);
            return View(registro);
        }

        // POST: registros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRegistro,idHuesped,idHabitacion,fecha,hora,dias,descuento")] registro registro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idHabitacion = new SelectList(db.habitacion, "idHabitacion", "tipo", registro.idHabitacion);
            ViewBag.idHuesped = new SelectList(db.huesped, "idHuesped", "nombres", registro.idHuesped);
            return View(registro);
        }

        // GET: registros/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro registro = db.registro.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            return View(registro);
        }

        // POST: registros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            registro registro = db.registro.Find(id);
            db.registro.Remove(registro);
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
