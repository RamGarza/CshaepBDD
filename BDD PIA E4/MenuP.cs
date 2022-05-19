using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDD_PIA_E4
{
    public partial class MenuP : Form
    {
        int Acceso;
        long Empleado;
        public MenuP(int NivelAcceso, long UsuarioID)
        {
            Acceso = NivelAcceso;
            Empleado = UsuarioID;
            InitializeComponent();
        }

        private void Diseno()
        {
            panelCitasSub.Visible = false;
            panelEmpleadosSub.Visible = false;
            panelInventariosSub.Visible = false;
            panelPacientesSub.Visible = false;
            panelReporteSub.Visible = false;

        }

        private void OcultarSubMenu()
        {
            if (panelCitasSub.Visible == true)
                panelCitasSub.Visible = false;

            if (panelEmpleadosSub.Visible == true)
                panelEmpleadosSub.Visible = false;

            if (panelInventariosSub.Visible == true)
                panelInventariosSub.Visible = false;

            if (panelPacientesSub.Visible == true)
                panelPacientesSub.Visible = false;

            if (panelReporteSub.Visible == true)
                panelReporteSub.Visible = false;

        }

        private void MostrarSubMenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                OcultarSubMenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }

        private void MenuP_Load(object sender, EventArgs e)
        {
            OcultarSubMenu();
        }

        #region Desplegar sub menus
        private void btnCitas_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPac_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(panelPacientesSub);
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(panelReporteSub);
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(panelEmpleadosSub);
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(panelInventariosSub);
        }
        #endregion

        #region Mostrar forms

        private Form FormActivo = null;
        private void Mostrarform(Form FormMostrado)
        {
            if(FormActivo != null)
                FormActivo.Close();
            FormActivo = FormMostrado;
            FormMostrado.TopLevel = false;
            FormMostrado.FormBorderStyle = FormBorderStyle.None;
            FormMostrado.Dock = DockStyle.Fill;
            panelForms.Controls.Add(FormMostrado);
            panelForms.Tag = FormMostrado;
            FormMostrado.BringToFront();
            FormMostrado.Show();
        }
        #endregion

        private void btnAgregarC_Click(object sender, EventArgs e)
        {
            Mostrarform(new PruebaDiseno());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Mostrarform(new InventariosCatalogo());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Mostrarform(new Proveedores());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Mostrarform(new OrdenCompra());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Mostrarform(new Inventario());
        }
    }
}
