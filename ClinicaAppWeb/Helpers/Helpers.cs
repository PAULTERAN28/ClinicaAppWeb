using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ClinicaAppWeb.Helpers
{
    public static class Helpers
    {
        public static MvcHtmlString ActionLinkAllow(this HtmlHelper helper)
        {
            StringBuilder sb = new StringBuilder();
            if (HttpContext.Current.Session["Usuario"] != null)
            {


                String valorInicial = "Primero";
                String opcion = "Gestion";
                String primerSubOpcion = "CitaMedica";
                String segundaSubOpcion = "Paciente";
                string terceraSubOpcion = "Trabajador";
                string cuartaSubOpcion = "Usuario";
                sb.AppendLine("<li class='accordion'>");
                sb.AppendLine("<a href = '/" + primerSubOpcion + "/" + primerSubOpcion + " ' data-bs-toggle='collapse' data-bs-target='#collapse" + valorInicial + "' aria-expanded='false' aria-controls='collapse" + valorInicial + "' class='collapsible'>");
                sb.AppendLine("<span class='icon-home mr-3'></span>" + opcion + "  " + primerSubOpcion + " ");
                sb.AppendLine("</a>");
                sb.AppendLine("</li>");

                sb.AppendLine("<li class='accordion'>");
                sb.AppendLine("<a href = '/" + segundaSubOpcion + "/" + segundaSubOpcion + " ' data-bs-toggle='collapse' data-bs-target='#collapse" + valorInicial + "' aria-expanded='false' aria-controls='collapse" + valorInicial + "' class='collapsible'>");
                sb.AppendLine("<span class='icon-home mr-3'></span>" + opcion + "  " + segundaSubOpcion + " ");
                sb.AppendLine("</a>");
                sb.AppendLine("</li>");

                sb.AppendLine("<li class='accordion'>");
                sb.AppendLine("<a href = '/" + terceraSubOpcion + "/" + terceraSubOpcion + " ' data-bs-toggle='collapse' data-bs-target='#collapse" + valorInicial + "' aria-expanded='false' aria-controls='collapse" + valorInicial + "' class='collapsible'>");
                sb.AppendLine("<span class='icon-home mr-3'></span>" + opcion + "  " + terceraSubOpcion + " ");
                sb.AppendLine("</a>");
                sb.AppendLine("</li>");

                sb.AppendLine("<li class='accordion'>");
                sb.AppendLine("<a href = '/" + cuartaSubOpcion + "/" + cuartaSubOpcion + " ' data-bs-toggle='collapse' data-bs-target='#collapse" + valorInicial + "' aria-expanded='false' aria-controls='collapse" + valorInicial + "' class='collapsible'>");
                sb.AppendLine("<span class='icon-home mr-3'></span>" + opcion + "  " + cuartaSubOpcion + " ");
                sb.AppendLine("</a>");
                sb.AppendLine("</li>");



            }
            return new MvcHtmlString(sb.ToString());

        }


    }
}