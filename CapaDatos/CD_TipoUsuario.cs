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
    public class CD_TipoUsuario
    {
        public static CD_TipoUsuario cd_tipo_usuario = null;

        private CD_TipoUsuario()
        {

        }
        public static CD_TipoUsuario Instancia
        {
            get
            {
                if (cd_tipo_usuario == null)
                {
                    cd_tipo_usuario = new CD_TipoUsuario();
                }
                return cd_tipo_usuario;
            }
        }

        public List<TipoUsuario> getTipoUsuario()
        {
            List<TipoUsuario> tipoUsuarios = new List<TipoUsuario>();
            using (SqlConnection con = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("[sp_listarTipoUsuario]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        tipoUsuarios.Add(new TipoUsuario()
                        {
                            id_tipo_usuario = Convert.ToInt32(dr["id_tipo_usuario"].ToString()),
                            nombre_tipo_usuario = dr["nombre_tipo_usuario"].ToString()
                        });
                    }
                    dr.Close();
                    return tipoUsuarios;

                }
                catch (Exception)
                {
                    tipoUsuarios = null;
                    return tipoUsuarios;
                    throw;

                }
            }
        }


    }
}
