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
    public class CD_Cliente
    {
        public static CD_Cliente cd_cliente = null;
        private CD_Cliente()
        {

        }
        public static CD_Cliente Instancia
        {
            get
            {
                if (cd_cliente == null)
                {
                    cd_cliente = new CD_Cliente();
                }
                return cd_cliente;
            }
        }
        public List<Cliente> listadoClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            using (SqlConnection con = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("[sp_listarClientes]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        clientes.Add(new Cliente()
                        {
                            id_persona = Convert.ToInt32(dr["id_persona"].ToString()),
                            id_cliente = Convert.ToInt32(dr["id_cliente"].ToString()),
                            nombre = dr["nombre"].ToString(),
                            apellido_paterno = dr["apellido_paterno"].ToString(),
                            apellido_materno = dr["apellido_materno"].ToString(),
                            fecha_nacimiento = Convert.ToDateTime(dr["fecha_nacimiento"].ToString()),
                            dni = Convert.ToInt32(dr["dni"].ToString()),
                            celular = Convert.ToInt32(dr["celular"].ToString()),
                            correo = dr["correo"].ToString(),
                            sexo = Convert.ToBoolean(dr["sexo"].ToString()),
                            direccion = dr["direcccion"].ToString(),
                            detalle = dr["detalle"].ToString()
                        }) ;
                    }
                    dr.Close();
                    return clientes;

                }
                catch (Exception)
                {
                    clientes = null;
                    return clientes;
                    throw;
                }
            }
        }
        public bool eliminarCliente(Cliente cliente)
        {
            bool resp = true;
            using (SqlConnection con = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[sp_eliminarCliente]", con);
                    cmd.Parameters.AddWithValue("@id_cliente", cliente.id_cliente);
                    cmd.Parameters.AddWithValue("@id_persona", cliente.id_persona);
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


        public bool actualizarCliente(Cliente cliente)
        {
            bool resp = true;
            
            using (SqlConnection con = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[sp_actualizarCliente]", con);
                    cmd.Parameters.AddWithValue("@id_persona", cliente.id_persona);
                    cmd.Parameters.AddWithValue("@id_cliente", cliente.id_cliente);
                    cmd.Parameters.AddWithValue("@detalle", cliente.detalle);
                    cmd.Parameters.AddWithValue("@nombre", cliente.nombre);
                    cmd.Parameters.AddWithValue("@apellido_paterno", cliente.apellido_paterno);
                    cmd.Parameters.AddWithValue("@apellido_materno", cliente.apellido_materno);
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", cliente.fecha_nacimiento);
                    cmd.Parameters.AddWithValue("@dni", cliente.dni);
                    cmd.Parameters.AddWithValue("@celular", cliente.celular);
                    cmd.Parameters.AddWithValue("@correo", cliente.correo);
                    cmd.Parameters.AddWithValue("@sexo", cliente.sexo);
                    cmd.Parameters.AddWithValue("@direccion", cliente.direccion);
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
        public bool registrarCliente(Cliente cliente)
        {
            bool resp = true;
            
            using (SqlConnection con = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[sp_registrarCliente]", con);
                    cmd.Parameters.AddWithValue("@detalle", cliente.detalle);
                    cmd.Parameters.AddWithValue("@nombre", cliente.nombre);
                    cmd.Parameters.AddWithValue("@apellido_paterno", cliente.apellido_paterno);
                    cmd.Parameters.AddWithValue("@apellido_materno", cliente.apellido_materno);
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", cliente.fecha_nacimiento);
                    cmd.Parameters.AddWithValue("@dni", cliente.dni);
                    cmd.Parameters.AddWithValue("@celular", cliente.celular);
                    cmd.Parameters.AddWithValue("@correo", cliente.correo);
                    cmd.Parameters.AddWithValue("@sexo", cliente.sexo);
                    cmd.Parameters.AddWithValue("@direccion", cliente.direccion);
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

        public Cliente buscarClientePorDNI(int dni)
        {
            Cliente cliente = null;
            using (SqlConnection con = new SqlConnection(Conexion.CN))
            {


                try
                {
                    SqlCommand cmd = new SqlCommand("[sp_buscarClientePorDNI]", con);
                    cmd.Parameters.AddWithValue("@dniCliente", dni);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        cliente = new Cliente()
                        {
                            id_persona = Convert.ToInt32(dr["id_persona"].ToString()),
                            nombre = dr["nombre"].ToString(),
                            apellido_paterno = dr["apellido_paterno"].ToString(),
                            apellido_materno = dr["apellido_materno"].ToString(),
                            id_cliente = Convert.ToInt32(dr["id_cliente"].ToString())

                        };


                    }
                    dr.Close();
                    return cliente;
                }
                catch (Exception)
                {
                    cliente = null;
                    return cliente;
                    throw;

                }
            }

        }

    }
}
