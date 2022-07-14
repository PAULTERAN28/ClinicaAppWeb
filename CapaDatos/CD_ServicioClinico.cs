using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_ServicioClinico
    {
        public static CD_ServicioClinico cd_servicioClinico = null;
        private CD_ServicioClinico()
        {

        }
        public static CD_ServicioClinico Instancia
        {
            get
            {
                if (cd_servicioClinico == null)
                {
                    cd_servicioClinico = new CD_ServicioClinico();
                }
                return cd_servicioClinico;
            }
        }

        public List<Tipo_Servicio_clinico> GetTipo_Servicio_Clinicos()
        {
            List<Tipo_Servicio_clinico> listaTipoServiciosClinicos = new List<Tipo_Servicio_clinico>();
            using (SqlConnection con = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("[sp_ListarTipoServicioClinico]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        listaTipoServiciosClinicos.Add(new Tipo_Servicio_clinico()
                        {
                            id_tipo_servicio = Convert.ToInt32(dr["id_tipo_servicio"].ToString()),
                            nombre_servicio = dr["nombre_servicio"].ToString()

                        });
                    }
                    dr.Close();
                    return listaTipoServiciosClinicos;

                }
                catch (Exception)
                {
                    listaTipoServiciosClinicos = null;
                    return listaTipoServiciosClinicos;
                    throw;
                }

            }
        }



    }
}
