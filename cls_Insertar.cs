using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ImagenesnBD
{
    public class cls_Insertar
    {
        public bool InsertarUsuarios(cls_LogicaInsertar objl, PictureBox imagen)
        {
            SqlConnection cn = cls_Conexion.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("insertardatos", cn);
            cmd.CommandType = CommandType.StoredProcedure;
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
