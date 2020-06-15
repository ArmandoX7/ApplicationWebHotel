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
    public class consumosController : Controller
    {
        private hotel5Entities db = new hotel5Entities();

        // GET: consumos
        public ActionResult Index()
        {
            var consumo = db.consumo.Include(c => c.huesped).Include(c => c.servicio);
            return View(consumo.ToList());
        }

        // GET: consumos/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consumo consumo = db.consumo.Find(id);
            if (consumo == null)
            {
                return HttpNotFound();
            }
            return View(consumo);
        }

        // GET: consumos/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.idHuesped = new SelectList(db.huesped, "idHuesped", "nombres");
            ViewBag.idServicio = new SelectList(db.servicio, "idServicio", "tipo");
            return View();
        }

        // POST: consumos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idConsumo,idHuesped,idServicio,cantidad,fecha,hora")] consumo consumo)
        {
            if (ModelState.IsValid)
            {
                db.consumo.Add(consumo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idHuesped = new SelectList(db.huesped, "idHuesped", "nombres", consumo.idHuesped);
            ViewBag.idServicio = new SelectList(db.servicio, "idServicio", "tipo", consumo.idServicio);
            return View(consumo);
        }

        // GET: consumos/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consumo consumo = db.consumo.Find(id);
            if (consumo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idHuesped = new SelectList(db.huesped, "idHuesped", "nombres", consumo.idHuesped);
            ViewBag.idServicio = new SelectList(db.servicio, "idServicio", "tipo", consumo.idServicio);
            return View(consumo);
        }

        // POST: consumos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idConsumo,idHuesped,idServicio,cantidad,fecha,hora")] consumo consumo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consumo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idHuesped = new SelectList(db.huesped, "idHuesped", "nombres", consumo.idHuesped);
            ViewBag.idServicio = new SelectList(db.servicio, "idServicio", "tipo", consumo.idServicio);
            return View(consumo);
        }

        // GET: consumos/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consumo consumo = db.consumo.Find(id);
            if (consumo == null)
            {
                return HttpNotFound();
            }
            return View(consumo);
        }

        // POST: consumos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            consumo consumo = db.consumo.Find(id);
            db.consumo.Remove(consumo);
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
