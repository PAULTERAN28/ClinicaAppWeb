using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Persona
    {
        public int id_persona { get; set; }
        public string nombre { get; set; }
       

        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }

        public DateTime fecha_nacimiento { get; set; }
        public int dni { get; set; }
        public int celular { get; set; }
        public string correo { get; set; }
        public Boolean sexo { get; set; }
        public string direccion { get; set; }
    }
}
