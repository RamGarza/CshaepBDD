using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace CshaepBDD
{
    public partial class EliminarDoctor : Form
    {
        private string nempID;
        private string ncedula;
        private string nespID;
        public EliminarDoctor(string empleadoID, string cedula, string especialidadID)
        {
            this.nempID = empleadoID;
            this.ncedula = cedula;
            this.nespID = especialidadID;
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void EliminarDoctor_Load(object sender, EventArgs e)
        {
            label2.Text = this.nempID;
            label3.Text = this.ncedula;
            label5.Text = this.nespID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Conectar();
            string eliminar = "delete from  Doctores " +
                "where Empleado_Id= @Empleado_Id";
            SqlCommand cmdl = new SqlCommand(eliminar, Class1.Conectar());
            cmdl.Parameters.AddWithValue("@Empleado_Id", this.nempID);
            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show(" El doctor fue eliminado");
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
