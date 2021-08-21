using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ImagenesnBD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int id;
        cls_LogicaInsertar objL = new cls_LogicaInsertar();
        cls_Insertar objI = new cls_Insertar();
        cls_Actualizar objA = new cls_Actualizar();
        cls_Conexion cn = new cls_Conexion();
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'db_InsertarImagenDataSet1.sp_listarDatos' Puede moverla o quitarla según sea necesario.
            this.sp_listarDatosTableAdapter1.Fill(this.db_InsertarImagenDataSet1.sp_listarDatos);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                //Muesta la fecha guardada en la base de datos en un dateTimePicker 
                dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[4].Value;
                //Muesta la imagen guardada en la base de datos en un PicktureBox 
                byte[] image = Encoding.ASCII.GetBytes(dataGridView1.CurrentRow.Cells[5].Value.ToString());
                if (image == null)
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    var data = (Byte[])(dataGridView1.CurrentRow.Cells[5].Value);
                    var stream = new MemoryStream(data);
                    pictureBox1.Image = Image.FromStream(stream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_Insertar_Click(object sender, EventArgs e)
        {
            try
            {
                objL.nombre = textBox1.Text;
                objL.direccion = textBox2.Text;
                objL.telefono = Convert.ToInt32(textBox3.Text);
                objL.fechaCumple = Convert.ToDateTime(dateTimePicker1.Text);

                if (objI.InsertarUsuarios(objL, pictureBox1) == true)
                {
                    MessageBox.Show("Guardado Correctamente");
                    //listar.ListarUsuarios();
                    //VaciarTextBoxes();
                    //ListarUsuarios();
                }
                else
                {
                    MessageBox.Show("Se produjo un error: No guardado");
                    //VaciarTextBoxes();
                    //ListarUsuarios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe llenar los campos", "Atención!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Abrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.pictureBox1.Image = Image.FromFile(this.openFileDialog1.FileName);
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            try
            {
                objL.id = id;
                objL.nombre = textBox1.Text;
                objL.direccion = textBox2.Text;
                objL.telefono = Convert.ToInt32(textBox3.Text);
                objL.fechaCumple = Convert.ToDateTime(dateTimePicker1.Text);
                if (objA.ActualizarUsuario(objL, pictureBox1) == true)
                {
                    MessageBox.Show("Actualizado Correctamente");
                    //VaciarTextBoxes();
                    //ListarUsuarios();
                }
                else
                {
                    MessageBox.Show("Se produjo un error: No actualizado");
                    //VaciarTextBoxes();
                    //ListarUsuarios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay datos para actualzar", "Atención!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
