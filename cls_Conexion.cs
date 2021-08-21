using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ImagenesnBD
{
    public class cls_Conexion
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
            cn.Open();
            return cn;

        }
    }
}
