using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaDatos;
using System.Transactions;
using System.Web.Script.Serialization;

namespace ClinicaAppWeb.Controllers
{
    public class PacienteController : Controller
    {
        // GET: Paciente
        public ActionResult Paciente()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetListadoClientes()
        {
            List<Cliente> clientes = CD_Cliente.Instancia.listadoClientes();
            return Json(new { data = clientes }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult registrarCliente(String cliente)
        {
            
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    var datos = new JavaScriptSerializer().Deserialize<Cliente>(cliente);
                    CD_Cliente.Instancia.registrarCliente(datos);
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
        public JsonResult eliminarCliente(String cliente)
        {

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    var datos = new JavaScriptSerializer().Deserialize<Cliente>(cliente);
                    CD_Cliente.Instancia.eliminarCliente(datos);
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
        public JsonResult actualizarCliente(String cliente)
        {

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    var datos = new JavaScriptSerializer().Deserialize<Cliente>(cliente);
                    CD_Cliente.Instancia.actualizarCliente(datos);
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