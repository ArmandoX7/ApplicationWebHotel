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
    public class facturasController : Controller
    {
        private hotel5Entities db = new hotel5Entities();

        // GET: facturas
        public ActionResult Index()
        {
            var factura = db.factura.Include(f => f.consumo).Include(f => f.huesped).Include(f => f.registro);
            return View(factura.ToList());
        }

        // GET: facturas/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura factura = db.factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // GET: facturas/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.idConsumo = new SelectList(db.consumo, "idConsumo", "idConsumo");
            ViewBag.idHuesped = new SelectList(db.huesped, "idHuesped", "nombres");
            ViewBag.idRegistro = new SelectList(db.registro, "idRegistro", "idHabitacion");
            return View();
        }

        // POST: facturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numFactura,nombreEmisor,telEmisor,fecha,hora,idHuesped,idRegistro,idConsumo,total")] factura factura)
        {
            if (ModelState.IsValid)
            {
                db.factura.Add(factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idConsumo = new SelectList(db.consumo, "idConsumo", "idConsumo", factura.idConsumo);
            ViewBag.idHuesped = new SelectList(db.huesped, "idHuesped", "nombres", factura.idHuesped);
            ViewBag.idRegistro = new SelectList(db.registro, "idRegistro", "idHabitacion", factura.idRegistro);
            return View(factura);
        }

        // GET: facturas/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura factura = db.factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.idConsumo = new SelectList(db.consumo, "idConsumo", "idConsumo", factura.idConsumo);
            ViewBag.idHuesped = new SelectList(db.huesped, "idHuesped", "nombres", factura.idHuesped);
            ViewBag.idRegistro = new SelectList(db.registro, "idRegistro", "idHabitacion", factura.idRegistro);
            return View(factura);
        }

        // POST: facturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numFactura,nombreEmisor,telEmisor,fecha,hora,idHuesped,idRegistro,idConsumo,total")] factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idConsumo = new SelectList(db.consumo, "idConsumo", "idConsumo", factura.idConsumo);
            ViewBag.idHuesped = new SelectList(db.huesped, "idHuesped", "nombres", factura.idHuesped);
            ViewBag.idRegistro = new SelectList(db.registro, "idRegistro", "idHabitacion", factura.idRegistro);
            return View(factura);
        }

        // GET: facturas/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura factura = db.factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            factura factura = db.factura.Find(id);
            db.factura.Remove(factura);
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
