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
using BDD_PIA_E4;

namespace FaltanteInventarios
{
    public partial class DetalleOrdenCompra : Form
    {
        public DetalleOrdenCompra()
        {
            InitializeComponent();
        }

        private void DetalleOrdenCompra_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            dataGridViewOrdenDetalle.DataSource = llenar_Grid();
        }

        public DataTable llenar_Grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select * from OrdenCompra_Conceptos";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void dataGridViewOrdenDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtOrdenID.Text = dataGridViewOrdenDetalle.CurrentRow.Cells[0].Value.ToString();
            txtInsumo.Text = dataGridViewOrdenDetalle.CurrentRow.Cells[1].Value.ToString();
            txtCantidad.Text = dataGridViewOrdenDetalle.CurrentRow.Cells[2].Value.ToString();
            txtCosto.Text = dataGridViewOrdenDetalle.CurrentRow.Cells[3].Value.ToString();
            txtIva.Text = dataGridViewOrdenDetalle.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "Insert into OrdenCompra_Conceptos(Orden_id, Insumo_id, Cantidad, Costo, IVA) values(@Orden_id, @Insumo_id, @Cantidad, @Costo, @IVA)";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Orden_id", txtOrdenID.Text);
            cmdl.Parameters.AddWithValue("@Insumo_id", txtInsumo.Text);
            cmdl.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
            cmdl.Parameters.AddWithValue("@Costo", txtCosto.Text);
            cmdl.Parameters.AddWithValue("@IVA", txtIva.Text);
            cmdl.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron agregados exitosamente");
            dataGridViewOrdenDetalle.DataSource = llenar_Grid();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizar = "UPDATE OrdenCompra_Conceptos SET Orden_id = @Orden_id, Insumo_id = @Insumo_id, Cantidad = @Cantidad, Costo = @Costo, IVA = @IVA";
            SqlCommand cmdl = new SqlCommand(actualizar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Orden_id", txtOrdenID.Text);
            cmdl.Parameters.AddWithValue("@Insumo_id", txtInsumo.Text);
            cmdl.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
            cmdl.Parameters.AddWithValue("@Costo", txtCosto.Text);
            cmdl.Parameters.AddWithValue("@IVA", txtIva.Text);
            cmdl.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron modificados exitosamente");
            dataGridViewOrdenDetalle.DataSource = llenar_Grid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string Eliminar = "DELETE FROM OrdenCompra_Conceptos WHERE Insumo_id = @InsumoID AND Orden_id = @Orden_id";
            SqlCommand cmdl = new SqlCommand(Eliminar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@InsumoID", txtInsumo.Text);
            cmdl.Parameters.AddWithValue("@Orden_id", txtOrdenID.Text);
            cmdl.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron Eliminados exitosamente");
            dataGridViewOrdenDetalle.DataSource = llenar_Grid();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
