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
    public class CitaMedicaController : Controller
    {
        // GET: CitaMedica
        public ActionResult CitaMedica()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetListadoAreas()
        {
            List<Area> areas = CD_Area.Instancia.getAreas();
            return Json(new { data = areas }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult getListadoTipoServicioClinico()
        {
            List<Tipo_Servicio_clinico> tipoServiciosClinicos = CD_ServicioClinico.Instancia.GetTipo_Servicio_Clinicos();
            return Json(new { data = tipoServiciosClinicos }, JsonRequestBehavior.AllowGet);
        }
        //buscarEmpleadoPorDNII

        [HttpGet]
        public JsonResult buscarEmpleadoPorDNI(int dni)
        {
            Empleado empleado = CD_Empleado.Instancia.buscarEmpleadoPorDNI(dni);
            return Json(new { data = empleado }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult listadoCitaMedicas()
        {
            List<Cita> list = CD_CItaMedica.Instancia.listadoCitaMedicas();
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult registrarCitaMedica(String cita)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    var datos = new JavaScriptSerializer().Deserialize<Cita>(cita);

                    CD_CItaMedica.Instancia.registrarCitaMedica(datos);
                    scope.Complete();
                    return Json(new { resultado = true }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json(new { resultado = false }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult buscarClientePorDNI(int dni)
        {
            Cliente cliente = CD_Cliente.Instancia.buscarClientePorDNI(dni);
            return Json(new { data = cliente }, JsonRequestBehavior.AllowGet);
        }

    }
        
}