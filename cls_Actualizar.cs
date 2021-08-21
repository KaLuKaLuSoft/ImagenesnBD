using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ImagenesnBD
{
    public class cls_Actualizar
    {
        public bool ActualizarUsuario(cls_LogicaInsertar objl, PictureBox imagen)
        {
            SqlConnection cn = cls_Conexion.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("actualizardatos", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", objl.id);
            cmd.Parameters.AddWithValue("@nombre", objl.nombre);
            cmd.Parameters.AddWithValue("@direccion", objl.direccion);
            cmd.Parameters.AddWithValue("@telefono", objl.telefono);
            cmd.Parameters.AddWithValue("@fechaCumple", objl.fechaCumple);
            MemoryStream ms = new MemoryStream();
            imagen.Image.Save(ms, ImageFormat.Bmp);
            cmd.Parameters.AddWithValue("@imagen", ms.GetBuffer());
            if (cmd.ExecuteNonQuery() == 1)
            {
                cn.Close();
                return true;
            }
            else
            {
                cn.Close();
                return false;
            }
        }
    }
}
