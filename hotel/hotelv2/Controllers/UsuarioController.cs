using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using hotelv2.Models;

namespace hotelv2.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            List<UsuarioCLS> listaUsuario = null;
            using (var bd = new hotel5Entities1())
            {
                listaUsuario = (from usuario in bd.usuario
                                select new UsuarioCLS
                                {
                                    idUser = usuario.idUser,
                                    email = usuario.email,
                                    password = usuario.password
                                }).ToList();
            }
            return View(listaUsuario);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(UsuarioCLS oUsuarioCLS)
        {
            if (!ModelState.IsValid)
            {
                return View(oUsuarioCLS);
            }
            else
            {
                using (var bd = new hotel5Entities1())
                {
                    usuario oUsuario = new usuario();
                    oUsuario.email = oUsuarioCLS.email;
                    oUsuario.password = oUsuarioCLS.password;
                    bd.usuario.Add(oUsuario);
                    bd.SaveChanges();
                    MessageBox.Show("Registro Exitoso!!","Informacion");
                }
            }
            return RedirectToAction("Index");

        }
    }
}