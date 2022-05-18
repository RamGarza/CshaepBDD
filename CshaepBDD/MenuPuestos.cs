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
    public partial class MenuPuestos : Form
    {
        public MenuPuestos()
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
            string consulta = "select * from Puestos";
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
            }
            catch
            {

            }
        }
    }
}
