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
    public partial class EditarPaciente : Form
    {
        private string ncurp;
        private string nnombre;
        private string napellidos;
        private string ntelefono;
        private string nfechaNac;
        public EditarPaciente(string curp, string nombre, string apellidos, string telefono, string fechaNac)
        {
            this.ncurp = curp; 
            this.nnombre = nombre;
            this.napellidos = apellidos;
            this.ntelefono = telefono;
            this.nfechaNac = fechaNac;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = this.ncurp;
            textBox2.Text = this.nnombre;
            textBox3.Text = this.napellidos;
            textBox4.Text = this.ntelefono;
            textBox5.Text = this.nfechaNac;
            Class1.Conectar();
        }
         
        private void button1_Click_1(object sender, EventArgs e)
        {
            Class1.Conectar();
            string insertar = "update Pacientes " +
                "set CURP = @Curp ,Nombre = @Nombre , Apellidos = @Apellidos ,Telefono = @Telefono , FechaNacimiento = @FechaNacimiento " +
                "where CURP = @CurpAnterior";
            SqlCommand cmdl = new SqlCommand(insertar, Class1.Conectar());
            cmdl.Parameters.AddWithValue("@Curp", textBox1.Text);
            cmdl.Parameters.AddWithValue("@CurpAnterior", this.ncurp);
            cmdl.Parameters.AddWithValue("@Nombre", textBox2.Text);
            cmdl.Parameters.AddWithValue("@Apellidos", textBox3.Text);
            cmdl.Parameters.AddWithValue("@Telefono", textBox4.Text);
            cmdl.Parameters.AddWithValue("@FechaNacimiento", textBox5.Text);

                cmdl.ExecuteNonQuery();
            
            MessageBox.Show(" El paciente fue editado");
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
