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
    public partial class MenuOrdenCompra : Form
    {
        public MenuOrdenCompra()
        {
            InitializeComponent();
            dataGridView1.DataSource = llenar_Grid();
        }

        private void MenuOrdenCompra_Load(object sender, EventArgs e)
        {
            Class1.Conectar();
        }

        public DataTable llenar_Grid()
        {
            Class1.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select * from OrdenCompra";
            SqlCommand cmd = new SqlCommand(consulta, Class1.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

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
    }
}
