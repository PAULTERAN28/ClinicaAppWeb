using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuario
    {
        public int id_persona { get; set; }
        public int id_usuario { get; set; }
        public string usuario { get; set; }
        public string nombre { get; set; }

        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public int dni { get; set; }
        public int celular { get; set; }
        public string correo { get; set; }
        public int id_tipo_usuario { get; set; }
        public string nombre_tipo_usuario { get; set; }

        public string password { get; set; }

        public string descripcion_tipo_usuario { get; set; }
    }
}
