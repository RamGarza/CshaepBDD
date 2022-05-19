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
    public partial class OrdenCompra : Form
    {
        
        public OrdenCompra()
        {
            
            InitializeComponent();
        }
        public DataTable llenar_Grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select * from OrdenCompra";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "Insert into OrdenCompra(Proveedor_id, Fecha) values(@Proveedor_id, @Fecha)";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Proveedor_id", txtProvID.Text);
            cmdl.Parameters.AddWithValue("@Fecha", dateTimePickerFecha.Value);

            cmdl.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron agregados exitosamente");
            dataGridViewOrd.DataSource = llenar_Grid();
        }

        private void OrdenCompra_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            dataGridViewOrd.DataSource = llenar_Grid();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string Actualizar = "UPDATE OrdenCompra SET Proveedor_id = @Proveedor_id, Fecha = @Fecha WHERE Orden_id = @OrdenID";
            SqlCommand cmdl = new SqlCommand(Actualizar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@OrdenID", txtOrdID);
            cmdl.Parameters.AddWithValue("@Proveedor_id", txtProvID.Text);
            cmdl.Parameters.AddWithValue("@Fecha", dateTimePickerFecha.Text);

            cmdl.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron modificados exitosamente");
            dataGridViewOrd.DataSource = llenar_Grid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string Actualizar = "DELETE OrdenCompra WHERE Orden_id = @OrdenID";
            SqlCommand cmdl = new SqlCommand(Actualizar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@OrdenID", txtOrdID);

            cmdl.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron eliminados exitosamente");
            dataGridViewOrd.DataSource = llenar_Grid();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewOrd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtOrdID.Text = dataGridViewOrd.CurrentRow.Cells[0].Value.ToString();
            txtProvID.Text = dataGridViewOrd.CurrentRow.Cells[1].Value.ToString();
            dateTimePickerFecha.Value = (DateTime)dataGridViewOrd.CurrentRow.Cells[2].Value;
            
        }

        Form Prueba = new PruebaDiseno();
        
    }
}
