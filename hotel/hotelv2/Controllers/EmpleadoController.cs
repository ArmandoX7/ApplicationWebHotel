using hotelv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hotelv2.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            List<EmpleadoCLS> listaEmpleado = null;
            using (var bd=new hotel5Entities1())
            {
                listaEmpleado = (from empleado in bd.empleado
                                 select new EmpleadoCLS 
                                 { 
                                 idEmpleado=empleado.idEmpleado,
                                 nombre=empleado.nombre,
                                 apellido_pat=empleado.apellido_pat,
                                 apellido_mat=empleado.apellido_mat,
                                 sexo=empleado.sexo,
                                 telefono=empleado.telefono,
                                 correo=empleado.correo,
                                 rfc=empleado.rfc
                                 }).ToList();
            }

                return View(listaEmpleado);
        }
    }
}