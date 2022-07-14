using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ServicioClinico
    {
        public int id_servicio_clinico { get; set; }
        public string id_tipo_servicio { get; set; }

        public DateTime fecha_servicio { get; set; }

        public int estado_pago_servicio { get; set; }

        public int estado_servicio { get; set; }

        public double precio { get; set; }
    }
}
