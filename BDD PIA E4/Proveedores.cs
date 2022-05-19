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
    public partial class Proveedores : Form
    {
        public Proveedores()
        {
            InitializeComponent();
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            dataGridViewProv.DataSource = llenar_Grid();
        }
        public DataTable llenar_Grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select * from Proveedores";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "Insert into Proveedores(Nombre, Telefono, Correo, Direccion) values(@Nombre, @Telefono, @Correo, @Direccion)";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Nombre", txtNom.Text);
            cmdl.Parameters.AddWithValue("@Telefono", txtTel.Text);
            cmdl.Parameters.AddWithValue("@Correo", txtCor.Text);
            cmdl.Parameters.AddWithValue("@Direccion", txtDir.Text);
            cmdl.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron agregados exitosamente");
            dataGridViewProv.DataSource = llenar_Grid();
        }

        private void dataGridViewProv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProvID.Text = dataGridViewProv.CurrentRow.Cells[0].Value.ToString();
            txtNom.Text = dataGridViewProv.CurrentRow.Cells[1].Value.ToString();
            txtTel.Text = dataGridViewProv.CurrentRow.Cells[2].Value.ToString();
            txtCor.Text = dataGridViewProv.CurrentRow.Cells[3].Value.ToString();
            txtDir.Text = dataGridViewProv.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "UPDATE Proveedores SET Nombre = @Nombre, Telefono = @Telefono, Correo = @Correo, Direccion = @Direccion WHERE Proveedor_id = @ProveedorID";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@ProveedorID", txtProvID.Text);
            cmdl.Parameters.AddWithValue("@Nombre", txtNom.Text);
            cmdl.Parameters.AddWithValue("@Telefono", txtTel.Text);
            cmdl.Parameters.AddWithValue("@Correo", txtCor.Text);
            cmdl.Parameters.AddWithValue("@Direccion", txtDir.Text);
            cmdl.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron modificados exitosamente");
            dataGridViewProv.DataSource = llenar_Grid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string insertar = "DELETE Proveedores WHERE Proveedor_id = @ProveedorID";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@ProveedorID", txtProvID.Text);
            cmdl.Parameters.AddWithValue("@Nombre", txtNom.Text);
            cmdl.Parameters.AddWithValue("@Telefono", txtTel.Text);
            cmdl.Parameters.AddWithValue("@Correo", txtCor.Text);
            cmdl.Parameters.AddWithValue("@Direccion", txtDir.Text);
            cmdl.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron eliminados exitosamente");
            dataGridViewProv.DataSource = llenar_Grid();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
