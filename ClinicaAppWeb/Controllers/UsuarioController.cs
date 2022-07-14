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
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Usuario()
        {
            return View();
        }
        [HttpGet]

        public JsonResult GetListadoUsuariosPersonas()
        {
            List<Usuario> usuarios = CD_Usuario.Instancia.getListarUsuariosPersonas();
            return Json(new { data = usuarios }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetPersonas()
        {
            List<Persona> personas = CD_Persona.Instancia.getPersonas();
            return Json(new { data = personas }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetTipoUsuarios()
        {
            List<TipoUsuario> tipoUsuarios = CD_TipoUsuario.Instancia.getTipoUsuario();
            return Json(new { data = tipoUsuarios }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult eliminarUsuario(String usuario)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    var datos = new JavaScriptSerializer().Deserialize<Usuario>(usuario);
                    CD_Usuario.Instancia.eliminarUsuario(datos);
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
        public JsonResult actualizarUsuario(String usuario)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    var datos = new JavaScriptSerializer().Deserialize<Usuario>(usuario);
                    CD_Usuario.Instancia.actualizarUsuario(datos);
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
        public JsonResult registrarUsuario(String usuario)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    var datos = new JavaScriptSerializer().Deserialize<Usuario>(usuario);
                    CD_Usuario.Instancia.registrarUsuario(datos);
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