using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BDD_PIA_E4;

namespace CshaepBDD
{
    public partial class MenuPacientes : Form
    {
        public MenuPacientes()
        {
            InitializeComponent();

            dataGridView1.DataSource = llenar_Grid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
        }
        public DataTable llenar_Grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select * from Pacientes";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "Insert into Pacientes(CURP,Nombre,Apellidos,Telefono,FechaNacimiento) values(@Curp,@Nombre,@Apellidos,@Telefono,@FechaNacimiento)";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Curp", textBox1.Text);
            cmdl.Parameters.AddWithValue("@Nombre", textBox2.Text);
            cmdl.Parameters.AddWithValue("@Apellidos", textBox3.Text);
            cmdl.Parameters.AddWithValue("@Telefono", textBox4.Text);
            cmdl.Parameters.AddWithValue("@FechaNacimiento", textBox5.Text);

            cmdl.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron agregados exitosamente");
            dataGridView1.DataSource = llenar_Grid();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = ((DateTime)dataGridView1.CurrentRow.Cells[4].Value).ToString("yyyy-MM-dd");
            }
            catch
            {

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "update Pacientes " +
                "set CURP = @Curp ,Nombre = @Nombre , Apellidos = @Apellidos ,Telefono = @Telefono , FechaNacimiento = @FechaNacimiento " +
                "where CURP = @CurpAnterior";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Curp", textBox1.Text);
            cmdl.Parameters.AddWithValue("@CurpAnterior", textBox1.Text);
            cmdl.Parameters.AddWithValue("@Nombre", textBox2.Text);
            cmdl.Parameters.AddWithValue("@Apellidos", textBox3.Text);
            cmdl.Parameters.AddWithValue("@Telefono", textBox4.Text);
            cmdl.Parameters.AddWithValue("@FechaNacimiento", textBox5.Text);

            cmdl.ExecuteNonQuery();

            MessageBox.Show(" El paciente fue editado");
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminar = "delete from  Pacientes " +
                "where CURP = @Curp";
            SqlCommand cmdl = new SqlCommand(eliminar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Curp", textBox1.Text);
            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show(" El paciente fue eliminado");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
