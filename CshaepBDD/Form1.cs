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

namespace CshaepBDD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridView1.DataSource = llenar_Grid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Class1.Conectar();
            MessageBox.Show("Conexion exitosa");
        }
        public DataTable llenar_Grid()
        {
            Class1.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select * from Categories";
            SqlCommand cmd = new SqlCommand(consulta, Class1.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Conectar();
            string insertar = "Insert into Categories(CategoryName, Description) values(@Categoria, @Descripcion)";
            SqlCommand cmdl = new SqlCommand(insertar, Class1.Conectar());
            cmdl.Parameters.AddWithValue("@Categoria", textBox2.Text);
            cmdl.Parameters.AddWithValue("@Descripcion", textBox3.Text);
            //cmdl.Parameters.AddWithValue("@Imagen", textBox4.Text);

            cmdl.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron agregados exitosamente");
            dataGridView1.DataSource = llenar_Grid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.Conectar();
            string insertar = "Insert into Categories(CategoryName, Description, Picture) values(@Categoria, @Descripcion, @Imagen)";
            SqlCommand cmdl = new SqlCommand(insertar, Class1.Conectar());
            cmdl.Parameters.AddWithValue("@Categoria", textBox2.Text);
            cmdl.Parameters.AddWithValue("@Descripcion", textBox3.Text);
            cmdl.Parameters.AddWithValue("@Imagen", textBox4.Text);

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
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class1.Conectar();
            string Eliminar = "DELETE FROM Categories WHERE CategoryID = @CategoriaID";
            SqlCommand cmde = new SqlCommand(Eliminar, Class1.Conectar());
            cmde.Parameters.AddWithValue("@CategoriaID", textBox1.Text);

            cmde.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron eliminados exitosamente");
            dataGridView1.DataSource = llenar_Grid();
        }

    }
}
