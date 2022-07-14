using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;

namespace ClinicaAppWeb.Controllers
{
    public class HomeController : Controller
    {
        private static Usuario sesionUsuario;
        public ActionResult Home()
        {
            if (Session["Home"] != null)
                sesionUsuario = (Usuario)Session["Usuario"];
            else
            {
                sesionUsuario = new Usuario();
            }



            return View();
        }


        public ActionResult Salir()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Login", "Login");
        }

    }
}