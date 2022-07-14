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
    public class CD_Persona
    {
        public static CD_Persona cd_persona = null;
        private CD_Persona()
        {

        }
        public static CD_Persona Instancia
        {
            get
            {
                if (cd_persona == null)
                {
                    cd_persona = new CD_Persona();
                }
                return cd_persona;
            }
        }

        public List<Persona> getPersonas()
        {
            List<Persona> personas = new List<Persona>();
            using (SqlConnection con = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("[sp_listarPersonas]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        personas.Add(new Persona()
                        {
                            id_persona = Convert.ToInt32(dr["id_persona"].ToString()),
                            nombre = dr["nombre"].ToString(),
                            apellido_paterno = dr["apellido_paterno"].ToString(),
                            apellido_materno = dr["apellido_materno"].ToString(),
                            fecha_nacimiento = Convert.ToDateTime(dr["fecha_nacimiento"].ToString()),
                            dni = Convert.ToInt32(dr["dni"].ToString()),
                            celular = Convert.ToInt32(dr["celular"].ToString()),
                            correo = dr["correo"].ToString(),
                            sexo = Convert.ToBoolean(dr["sexo"].ToString()),
                            direccion = dr["direcccion"].ToString(),
                            
                        }); 

                    }
                    dr.Close();
                    return personas;

                }
                catch (Exception)
                {
                    personas = null;
                    return personas;
                    throw;
                }
            }
        }
    }
}
