using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Cita
    {
        public int id_cita { get; set; }

        public int id_empleado { get; set; }

        public string NombreEmpleado { get; set; }
        public int id_cliente { get; set; }

        public string NombreCliente { get; set; }
        public int id_tipo_area { get; set; }

        public string nombre_tipo_area { get; set; }


        public DateTime fecha_atencion { get; set; }

        public DateTime fecha_servicio { get; set; }

        public string detalle_cita { get; set; }

        public int id_tipo_servicio { get; set; }

        public string nombre_servicio { get; set; }
        public int id_servicio_clinico { get; set; }

        public double precio { get; set; }
    }
}
