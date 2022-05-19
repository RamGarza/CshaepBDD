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

namespace BDD_PIA_E4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();

            // int existe;

            SqlCommand cmd = new SqlCommand("Select NivelAcceso from Acceso_Empleado Where Usuario = @Usuario AND Pass = @Password", Conexion.Conectar());
            cmd.Parameters.AddWithValue("@Usuario", txtUsr.Text);
            cmd.Parameters.AddWithValue("@Password", txtPass.Text);

            int Acceso = (int)cmd.ExecuteScalar();

            MessageBox.Show("El valor de la variable existe es: " + Acceso);

            if (Acceso == 5 || Acceso == 1)
            {
                MessageBox.Show("Se ha iniciado sesion correctamente");
                MenuP Men = new MenuP(Acceso);
                this.Hide();
                Men.Show();
            }
            else
                MessageBox.Show("No se pudo iniciar sesion correctamente");
        }
    }
}
