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
    public partial class EliminarPaciente : Form
    {
        private string ncurp;
        private string nnombre;
        private string napellidos;
        private string ntelefono;
        private string nfechaNac;
        public EliminarPaciente(string curp, string nombre, string apellidos, string telefono, string fechaNac)
        {
            this.ncurp = curp;
            this.nnombre = nombre;
            this.napellidos = apellidos;
            this.ntelefono = telefono;
            this.nfechaNac = fechaNac;
            InitializeComponent();
        }

        private void EliminarPaciente_Load(object sender, EventArgs e)
        {
            label2.Text = this.ncurp;
            label3.Text = this.nnombre;
            label5.Text = this.napellidos;
            label7.Text = this.ntelefono;
            label9.Text = this.nfechaNac;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Conectar();
            string eliminar = "delete from  Pacientes " +
                "where CURP = @Curp";
            SqlCommand cmdl = new SqlCommand(eliminar, Class1.Conectar());
            cmdl.Parameters.AddWithValue("@Curp", this.ncurp);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
