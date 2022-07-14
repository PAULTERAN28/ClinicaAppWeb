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
    public class CD_Empleado
    {
        public static CD_Empleado cd_empleado = null;
        private CD_Empleado()
        {

        }
        public static CD_Empleado Instancia
        {
            get
            {
                if (cd_empleado == null)
                {
                    cd_empleado = new CD_Empleado();
                }
                return cd_empleado;
            }
        }

        public bool eliminarEmpleado(Empleado empleado)
        {
            bool resp = true;
            
            using (SqlConnection con = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[eliminarEmpleado]", con);
                    cmd.Parameters.AddWithValue("@id_empleado", empleado.id_empleado);
                    cmd.Parameters.AddWithValue("@id_persona", empleado.id_persona);
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
       

        public bool actualizarEmpleado(Empleado empleado)
        {
            bool resp = true;

            using (SqlConnection con = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[sp_actualizarEmpleado]", con);
                    cmd.Parameters.AddWithValue("@id_persona", empleado.id_persona);
                    cmd.Parameters.AddWithValue("@id_empleado", empleado.id_empleado);
                    cmd.Parameters.AddWithValue("@id_area", empleado.id_tipo_area);
                    cmd.Parameters.AddWithValue("@detalle", empleado.detalle);
                    cmd.Parameters.AddWithValue("@id_tipo_empleado", empleado.id_tipo_empleado);
                    cmd.Parameters.AddWithValue("@nombre", empleado.nombre);
                    cmd.Parameters.AddWithValue("@apellido_paterno", empleado.apellido_paterno);
                    cmd.Parameters.AddWithValue("@apellido_materno", empleado.apellido_materno);
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", empleado.fecha_nacimiento);
                    cmd.Parameters.AddWithValue("@dni", empleado.dni);
                    cmd.Parameters.AddWithValue("@celular", empleado.celular);
                    cmd.Parameters.AddWithValue("@correo", empleado.correo);
                    cmd.Parameters.AddWithValue("@sexo", empleado.sexo);
                    cmd.Parameters.AddWithValue("@direccion", empleado.direccion);
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
        public bool registrarEmpleado(Empleado empleado)
        {
            bool resp = true;
            
            using (SqlConnection con = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[sp_registrarEmpleadoWeb]", con);
                    cmd.Parameters.AddWithValue("@id_area", empleado.id_tipo_area);
                    cmd.Parameters.AddWithValue("@detalle", empleado.detalle);
                    cmd.Parameters.AddWithValue("@id_tipo_empleado", empleado.id_tipo_empleado);
                    cmd.Parameters.AddWithValue("@nombre", empleado.nombre);
                    cmd.Parameters.AddWithValue("@apellido_paterno", empleado.apellido_paterno);
                    cmd.Parameters.AddWithValue("@apellido_materno", empleado.apellido_materno);
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", empleado.fecha_nacimiento);
                    cmd.Parameters.AddWithValue("@dni", empleado.dni);
                    cmd.Parameters.AddWithValue("@celular", empleado.celular);
                    cmd.Parameters.AddWithValue("@correo", empleado.correo);
                    cmd.Parameters.AddWithValue("@sexo", empleado.sexo);
                    cmd.Parameters.AddWithValue("@direccion", empleado.direccion);
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
        
        public List<Empleado> listadoEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>();
            using (SqlConnection con = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("[sp_listarEmpleados]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        empleados.Add(new Empleado()
                        {
                            id_persona = Convert.ToInt32(dr["id_persona"].ToString()),
                            id_empleado = Convert.ToInt32(dr["id_empleado"].ToString()),
                            nombre = dr["nombre"].ToString(),
                            apellido_paterno = dr["apellido_paterno"].ToString(),
                            apellido_materno = dr["apellido_materno"].ToString(),
                            fecha_nacimiento = Convert.ToDateTime(dr["fecha_nacimiento"].ToString()),
                            dni = Convert.ToInt32(dr["dni"].ToString()),
                            celular = Convert.ToInt32(dr["celular"].ToString()),
                            correo = dr["correo"].ToString(),
                            sexo = Convert.ToBoolean(dr["sexo"].ToString()),
                            direccion = dr["direcccion"].ToString(),
                            detalle = dr["detalle"].ToString(),
                            id_tipo_area = Convert.ToInt32(dr["id_tipo_area"].ToString()),
                            nombre_tipo_area = dr["nombre_tipo_area"].ToString(),
                            id_tipo_empleado = Convert.ToInt32(dr["id_tipo_empleado"].ToString()),
                            nombre_tipo_empleado = dr["nombre_tipo_empleado"].ToString()
                        }) ;
                    }
                    dr.Close();
                    return empleados;
                }
                catch (Exception)
                {
                    empleados = null;
                    return empleados;
                    throw;
                }
            }
        }

        public Empleado buscarEmpleadoPorDNI(int dni)
        {
            Empleado empleado = null;
            using (SqlConnection con = new SqlConnection(Conexion.CN))
            {


                try
                {
                    SqlCommand cmd = new SqlCommand("[sp_buscarEmpleadoPorDNI]", con);
                    cmd.Parameters.AddWithValue("@dniEmpleado", dni);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        empleado = new Empleado()
                        {
                            id_persona = Convert.ToInt32(dr["id_persona"].ToString()),
                            nombre = dr["nombre"].ToString(),
                            apellido_paterno = dr["apellido_paterno"].ToString(),
                            apellido_materno = dr["apellido_materno"].ToString(),
                            //fecha_nacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]),
                            id_empleado = Convert.ToInt32(dr["id_empleado"].ToString())
                        };

                        Console.WriteLine("DATOS DE EMPLEADO"+empleado.ToString());
                        

                    }
                    dr.Close();
                    return empleado;
                }
                catch (Exception)
                {
                    empleado = null;
                    return empleado;
                    throw;

                }
            }

        }


    }
}
