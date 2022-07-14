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
    public  class CD_TipoEmpleado
    {
        public static CD_TipoEmpleado cd_tipoEmpleado = null;
        private CD_TipoEmpleado()
        {

        }
        public static CD_TipoEmpleado Instancia
        {
            get
            {
                if (cd_tipoEmpleado == null)
                {
                    cd_tipoEmpleado = new CD_TipoEmpleado();
                }
                return cd_tipoEmpleado;
            }
        }

        public List<TipoEmpleado> getTipoEmpleados()
        {
            List<TipoEmpleado> listaTipoEmpleado = new List<TipoEmpleado>();
            using (SqlConnection con = new SqlConnection(Conexion.CN))
            {

                SqlCommand cmd = new SqlCommand("[sp_ListarATipoEmpleados]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        listaTipoEmpleado.Add(new TipoEmpleado()
                        {
                            id_tipo_empleado = Convert.ToInt32(dr["id_tipo_empleado"].ToString()),
                            nombre_tipo_empleado = dr["nombre_tipo_empleado"].ToString()

                        });

                    }
                    dr.Close();
                    return listaTipoEmpleado;

                }
                catch (Exception)
                {
                    listaTipoEmpleado = null;
                    return listaTipoEmpleado;
                    throw;
                }


            }
        }
    }
}
