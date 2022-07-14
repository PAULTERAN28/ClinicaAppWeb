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
    
    public class CD_Area
    {
        public static CD_Area cd_area = null;
        private CD_Area()
        {

        }
        public static CD_Area Instancia
        {
            get
            {
                if (cd_area == null)
                {
                    cd_area = new CD_Area();
                }
                return cd_area;
            }
        }

        public List<Area> getAreas()
        {
            List<Area> listaAreas = new List<Area>();
            using (SqlConnection con = new SqlConnection(Conexion.CN))
            {
                
                SqlCommand cmd = new SqlCommand("[sp_ListarAreas]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        listaAreas.Add(new Area() { 
                            id_tipo_area = Convert.ToInt32(dr["id_tipo_area"].ToString()),
                            nombre_tipo_area = dr["nombre_tipo_area"].ToString()
                        
                        });

                    }
                    dr.Close();
                    return listaAreas;

                }
                catch (Exception)
                {
                    listaAreas = null;
                    return listaAreas;
                    throw;
                }


            }
        }
    }
}
