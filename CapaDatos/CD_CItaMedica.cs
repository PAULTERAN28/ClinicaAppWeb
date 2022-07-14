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
    public class CD_CItaMedica


    {
        //uso del patron singleton
        //inicia
        public static CD_CItaMedica cd_citaMedica = null;
        private CD_CItaMedica()
        {

        }
        public static CD_CItaMedica Instancia
        {
            get
            {
                if (cd_citaMedica == null)
                {
                    cd_citaMedica = new CD_CItaMedica();
                }
                return cd_citaMedica;
            }
        }
        //finaliza

        public List<Cita> listadoCitaMedicas()
        {
            List<Cita> listaCitasMedicas = new List<Cita>();
            using (SqlConnection con = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("[sp_listarCitaMedicas]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        listaCitasMedicas.Add(new Cita()
                        {
                            id_cita = Convert.ToInt32(dr["id_cita"].ToString()),
                            id_empleado = Convert.ToInt32(dr["id_empleado"].ToString()),
                            NombreEmpleado = dr["NombreEmpleado"].ToString(),
                            id_cliente = Convert.ToInt32(dr["id_cliente"].ToString()),
                            NombreCliente = dr["NombreCliente"].ToString(),
                            id_tipo_area = Convert.ToInt32(dr["id_tipo_area"].ToString()),
                            nombre_tipo_area = dr["nombre_tipo_area"].ToString(),
                            fecha_atencion = Convert.ToDateTime(dr["fecha_atencion"].ToString()),
                            detalle_cita = dr["detalle_cita"].ToString(),
                            id_tipo_servicio = Convert.ToInt32(dr["id_tipo_servicio"].ToString()),
                            nombre_servicio = dr["nombre_servicio"].ToString(),
                            id_servicio_clinico = Convert.ToInt32(dr["id_servicio_clinico"].ToString()),
                            precio = Convert.ToDouble(dr["precio"].ToString())

                        });
                    }
                    dr.Close();
                    return listaCitasMedicas;

                }
                catch (Exception)
                {
                    listaCitasMedicas = null;
                    return listaCitasMedicas;
                    throw;

                }
            }
        }

        
        public bool registrarCitaMedica(Cita cita)
        {
            bool resp = true;
            using (SqlConnection con = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[sp_RegistrarCitaWeb]", con);
                    cmd.Parameters.AddWithValue("@id_empleado", cita.id_empleado);
                    cmd.Parameters.AddWithValue("@id_cliente", cita.id_cliente);
                    cmd.Parameters.AddWithValue("@id_tipo_area", cita.id_tipo_area);
                    cmd.Parameters.AddWithValue("@fecha_atencion", cita.fecha_atencion);
                    cmd.Parameters.AddWithValue("@detalle_cita", cita.detalle_cita);
                    cmd.Parameters.AddWithValue("@id_tipo_servicio", cita.id_tipo_servicio);
                    cmd.Parameters.AddWithValue("@fecha_servicio", DateTime.Now);
                    cmd.Parameters.AddWithValue("@estado_pago_servicio", 1);
                    cmd.Parameters.AddWithValue("@estado_servicio", 1);
                    cmd.Parameters.AddWithValue("@precio", cita.precio);
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


    }
}
