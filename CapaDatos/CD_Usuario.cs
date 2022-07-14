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
    public class CD_Usuario
    {
        public static CD_Usuario cd_usuario_instancia = null;

        private CD_Usuario()
        {

        }
        public static CD_Usuario Instancia
        {
            get
            {
                if (cd_usuario_instancia == null)
                {
                    cd_usuario_instancia = new CD_Usuario();
                }
                return cd_usuario_instancia;
            }
        }
        public bool eliminarUsuario(Usuario usuario)
        {
            bool resp = true;
            using (SqlConnection con = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[sp_eliminarUsuario]", con);
                    cmd.Parameters.AddWithValue("@id_usuario", usuario.id_usuario);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    resp = true;
                }
                catch (Exception)
                {
                    resp = false;
                    throw;
                }
            }
            return resp;
        }
        public bool actualizarUsuario(Usuario usuario)
        {
            bool resp = true;

            using (SqlConnection con = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[sp_actualizarUsuario]", con);
                    cmd.Parameters.AddWithValue("@id_usuario", usuario.id_usuario);
                    cmd.Parameters.AddWithValue("@id_persona", usuario.id_persona);
                    cmd.Parameters.AddWithValue("@id_tipo_usuario", usuario.id_tipo_usuario);
                    cmd.Parameters.AddWithValue("@usuario", usuario.usuario);
                    cmd.Parameters.AddWithValue("@contraseña", usuario.password);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    resp = true;
                }
                catch (Exception)
                {
                    resp = false;
                    throw;
                }
            }
            return resp;
        }
        public bool registrarUsuario(Usuario usuario)
        {
            bool resp = true;

            using (SqlConnection con = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[sp_RegistrarUsuario]", con);
                    cmd.Parameters.AddWithValue("@id_persona", usuario.id_persona);
                    cmd.Parameters.AddWithValue("@id_tipo_usuario", usuario.id_tipo_usuario);
                    cmd.Parameters.AddWithValue("@usuario", usuario.usuario);
                    cmd.Parameters.AddWithValue("@contraseña", usuario.password);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    resp = true;

                }
                catch (Exception)
                {
                    resp = false;
                    throw;

                }
            }
            return resp;
        }

        public List<Usuario> getListarUsuariosPersonas()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (SqlConnection con = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("[sp_listarUsuariosPersonas]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        usuarios.Add(new Usuario()
                        {
                            id_persona = Convert.ToInt32(dr["id_persona"].ToString()),
                            id_usuario = Convert.ToInt32(dr["id_usuario"].ToString()),
                            usuario = dr["usuario"].ToString(),
                            nombre = dr["nombre"].ToString(),
                            apellido_paterno = dr["apellido_paterno"].ToString(),
                            apellido_materno = dr["apellido_materno"].ToString(),
                            dni = Convert.ToInt32(dr["dni"].ToString()),
                            celular = Convert.ToInt32(dr["celular"].ToString()),
                            correo = dr["correo"].ToString(),
                            id_tipo_usuario = Convert.ToInt32(dr["id_tipo_usuario"].ToString()),
                            nombre_tipo_usuario = dr["nombre_tipo_usuario"].ToString()
                        });
                    }
                    dr.Close();
                    return usuarios;
                }
                catch (Exception)
                {
                    usuarios = null;
                    return usuarios;
                    throw;
                }
            }

        }

        public Usuario Login(string user, string pass)
        {
            Usuario usuario = null;
            using (SqlConnection conexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[SP_Logearse]", conexion);
                    cmd.Parameters.AddWithValue("@usuario", user);
                    cmd.Parameters.AddWithValue("@password", pass);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        usuario = new Usuario() {
                            id_usuario = Convert.ToInt32(dr["id_usuario"].ToString()),
                            usuario = dr["usuario"].ToString(),
                            password = dr["contraseña"].ToString(),
                            id_tipo_usuario = Convert.ToInt32(dr["id_tipo_usuario"].ToString()),
                            nombre_tipo_usuario = dr["nombre_tipo_usuario"].ToString(),
                            id_persona = Convert.ToInt32(dr["id_persona"].ToString()),
                            descripcion_tipo_usuario = dr["descripcion_tipo_usuario"].ToString()
                        };
                        
                    }
                    dr.Close();
                    return usuario;
                   
                }
                catch (Exception)
                {
                    usuario = null;
                    return usuario;
                    throw;
                    
                }

            }
        }
    }
}
