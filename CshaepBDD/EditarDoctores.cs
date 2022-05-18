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
    public partial class EditarDoctores : Form
    {
        private string nempID;
        private string ncedula;
        private string nespID;
        public EditarDoctores(string Empleado_ID, string Cedula, string Especialidad_ID)
        {
            this.nempID = Empleado_ID;
            this.ncedula = Cedula;
            this.nespID = Especialidad_ID;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = this.nempID;
            textBox2.Text = this.ncedula;
            textBox3.Text = this.nespID;
            Class1.Conectar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Conectar();
            string insertar = "update Doctores " +
                "set Empleado_ID = @Empleado_ID ,Cedula = @Cedula ,Especialidad_id = @Especialidad_id " +
                "where Empleado_ID = @IDAnt";
            SqlCommand cmdl = new SqlCommand(insertar, Class1.Conectar());
            cmdl.Parameters.AddWithValue("@Empleado_ID", textBox1.Text);
            cmdl.Parameters.AddWithValue("@IDAnt", this.nempID);
            cmdl.Parameters.AddWithValue("@Cedula", textBox2.Text);
            cmdl.Parameters.AddWithValue("@Especialidad_id", textBox3.Text);

            cmdl.ExecuteNonQuery();

            MessageBox.Show("El doctor fue editado");
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
