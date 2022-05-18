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
    public partial class MenuEmpleados : Form
    {
        public MenuEmpleados()
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
            string consulta = "select * from Empleados";
            SqlCommand cmd = new SqlCommand(consulta, Class1.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox13.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox12.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox11.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox10.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                textBox9.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                textBox17.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                textBox16.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                textBox15.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                textBox14.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                textBox8.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
            }
            catch
            {

            }
        }
    }
}
