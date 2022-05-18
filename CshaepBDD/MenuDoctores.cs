using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CshaepBDD
{
    public partial class MenuDoctores : Form
    {
        public MenuDoctores()
        {
            
            InitializeComponent();
            dataGridView1.DataSource = llenar_Grid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Class1.Conectar();
        }

        public DataTable llenar_Grid()
        {
            Class1.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select * from Doctores";
            SqlCommand cmd = new SqlCommand(consulta, Class1.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Conectar();
            string insertar = "Insert into Doctores(Empleado_Id,Cedula,Especialidad_id) values(@EmpleadoID,@Cedula,@EspecialidadID)";
            SqlCommand cmdl = new SqlCommand(insertar, Class1.Conectar());
            cmdl.Parameters.AddWithValue("@EmpleadoID", textBox1.Text);
            cmdl.Parameters.AddWithValue("@Cedula", textBox2.Text);
            cmdl.Parameters.AddWithValue("@EspecialidadID", textBox3.Text);

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
            }
            catch
            {

            }
        }
        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditarDoctores frm2 = new EditarDoctores(textBox1.Text, textBox2.Text, textBox3.Text);
            frm2.ShowDialog();
            dataGridView1.DataSource = llenar_Grid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EliminarDoctor fmr3 = new EliminarDoctor(textBox1.Text, textBox2.Text, textBox3.Text);
            fmr3.ShowDialog();
            dataGridView1.DataSource = llenar_Grid();
        }
    }
}
