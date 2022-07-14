using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaDatos;

namespace ClinicaAppWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string user, string pass)
        {
            Usuario usuario = CD_Usuario.Instancia.Login(user, pass);

            if (usuario == null)
            {
                ViewBag.Error = "Usuario o contraseña no correcta";
                return View();
            }
            Session["Usuario"] = usuario;
            return RedirectToAction("Home", "Home");
        }
    }
}