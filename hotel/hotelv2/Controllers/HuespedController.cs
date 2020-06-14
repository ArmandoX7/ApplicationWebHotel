using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using hotelv2.Models;

namespace hotelv2.Controllers
{
    public class HuespedController : Controller
    {
        // GET: Huesped
        public ActionResult Index()
        {
            List<HuespedCLS> listaHuesped = null;
            using (var bd = new hotel5Entities1())
            {
                listaHuesped = (from huesped in bd.huesped
                                where huesped.numVisita > 10
                                select new HuespedCLS
                                {
                                    idHuesped = huesped.idHuesped,
                                    nombres = huesped.nombres,
                                    apellido_pat = huesped.apellido_pat,
                                    apellido_mat = huesped.apellido_mat,
                                    edad = huesped.edad,
                                    sexo = huesped.sexo,
                                    fecha_nac = huesped.fecha_nac,
                                    lugar_nac = huesped.lugar_nac,
                                    direccion = huesped.direccion,
                                    tel_casa = huesped.tel_casa,
                                    tel_celular = huesped.tel_celular,
                                    correo = huesped.correo,
                                    rfc = huesped.rfc,


                                }).ToList();
            }
            return View(listaHuesped);

        }

        [HttpPost]
        public ActionResult Agregar(HuespedCLS oHuespedCLS)
        {

            if (!ModelState.IsValid)
            {
                return View(oHuespedCLS);
            }
            else
            {
                using (var bd = new hotel5Entities1())
                {
                    huesped oHuesped = new huesped();
                    oHuesped.nombres = oHuespedCLS.nombres;
                    oHuesped.apellido_pat = oHuespedCLS.apellido_pat;
                    oHuesped.apellido_mat = oHuespedCLS.apellido_mat;
                    oHuesped.edad = oHuespedCLS.edad;
                    oHuesped.sexo = oHuespedCLS.sexo;
                    oHuesped.fecha_nac = oHuespedCLS.fecha_nac;
                    oHuesped.lugar_nac = oHuespedCLS.lugar_nac;
                    oHuesped.direccion = oHuespedCLS.direccion;
                    oHuesped.tel_casa = oHuespedCLS.tel_casa;
                    oHuesped.tel_celular = oHuespedCLS.tel_celular;
                    oHuesped.correo = oHuespedCLS.correo;
                    oHuesped.rfc = oHuespedCLS.rfc;
                    oHuesped.numVisita = oHuespedCLS.numVisita;
                    bd.huesped.Add(oHuesped);
                    bd.SaveChanges();
                    MessageBox.Show("Registro Exitoso!!", "Informacion");
                }
            }
            return RedirectToAction("Index");
        }
    }
}