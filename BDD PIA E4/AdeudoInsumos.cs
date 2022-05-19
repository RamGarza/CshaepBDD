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
using BDD_PIA_E4;

namespace FaltanteInventarios
{
    public partial class AdeudoInsumos : Form
    {
        public AdeudoInsumos()
        {
            InitializeComponent();
        }

        private void AdeudoInsumos_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            dataGridViewAdIns.DataSource = llenar_Grid();
        }

        public DataTable llenar_Grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select * from Adeudo_Insumos";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void dataGridViewAdIns_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAdeudo.Text = dataGridViewAdIns.CurrentRow.Cells[0].Value.ToString();
            txtLote.Text = dataGridViewAdIns.CurrentRow.Cells[1].Value.ToString();
            txtCantidad.Text = dataGridViewAdIns.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "Insert into Adeudo_Insumos(Adeudo_id, Lote_id, Cantidad) values(@Adeudo_id, @Lote_id, @Cantidad)";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Adeudo_id", txtAdeudo.Text);
            cmdl.Parameters.AddWithValue("@Lote_id", txtLote.Text);
            cmdl.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron agregados exitosamente");
                dataGridViewAdIns.DataSource = llenar_Grid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
            
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "UPDATE Adeudo_Insumos SET Adeudo_id = @Adeudo_id, Lote_id = @Lote_id, Cantidad = @Cantidad WHERE Adeudo_id = @Adeudo_id AND Lote_id = @Lote_id";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Adeudo_id", txtAdeudo.Text);
            cmdl.Parameters.AddWithValue("@Lote_id", txtLote.Text);
            cmdl.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
            cmdl.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron actualizados exitosamente");
            dataGridViewAdIns.DataSource = llenar_Grid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "DELETE Adeudo_Insumos WHERE Adeudo_id = @Adeudo_id AND Lote_id = @Lote_id";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Adeudo_id", txtAdeudo.Text);
            cmdl.Parameters.AddWithValue("@Lote_id", txtLote.Text);
            cmdl.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron eliminados exitosamente");
            dataGridViewAdIns.DataSource = llenar_Grid();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
