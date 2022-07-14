using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CapaDatos;
using CapaEntidad;

namespace ClinicaAppWeb.Controllers
{
    public class TrabajadorController : Controller
    {
        // GET: Trabajador
        public ActionResult Trabajador()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetListadoEmpleados()
        {
            List<Empleado> empleados = CD_Empleado.Instancia.listadoEmpleados();
            return Json(new { data = empleados }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetListadoAreas()
        {
            List<Area> areas = CD_Area.Instancia.getAreas();
            return Json(new { data = areas }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetListadoTipoEmpleados()
        {
            List<TipoEmpleado> tipoEmpleados = CD_TipoEmpleado.Instancia.getTipoEmpleados();
            return Json(new { data = tipoEmpleados }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult eliminarEmpleado(String empleado)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    var datos = new JavaScriptSerializer().Deserialize<Empleado>(empleado);
                    CD_Empleado.Instancia.eliminarEmpleado(datos);
                    scope.Complete();
                    return Json(new { resultado = true }, JsonRequestBehavior.AllowGet);

                }

            }
            catch (Exception)
            {
                return Json(new { resultado = false }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult actualizarEmpleado(String empleado)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    var datos = new JavaScriptSerializer().Deserialize<Empleado>(empleado);
                    CD_Empleado.Instancia.actualizarEmpleado(datos);
                    scope.Complete();
                    return Json(new { resultado = true }, JsonRequestBehavior.AllowGet);

                }

            }
            catch (Exception)
            {
                return Json(new { resultado = false }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult registrarEmpleado(String empleado)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    var datos = new JavaScriptSerializer().Deserialize<Empleado>(empleado);
                    CD_Empleado.Instancia.registrarEmpleado(datos);
                    scope.Complete();
                    return Json(new { resultado = true }, JsonRequestBehavior.AllowGet);

                }

            }
            catch (Exception)
            {
                return Json(new { resultado = false }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}