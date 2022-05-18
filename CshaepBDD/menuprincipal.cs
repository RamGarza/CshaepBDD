using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CshaepBDD
{
    public partial class menuprincipal : Form
    {
        public menuprincipal()
        {
            InitializeComponent();
        }

        private void menuprincipal_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPacientes frm1 = new MenuPacientes();
            frm1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuDoctores frm2 = new MenuDoctores();
            frm2.ShowDialog();  
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MenuAdeudos frm3 = new MenuAdeudos();
            frm3.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MenuCitas fmr4 = new MenuCitas();
            fmr4.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MenuEmpleados fmr5 = new MenuEmpleados();
            fmr5.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MenuInventario fmr6 = new MenuInventario();
            fmr6.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MenuMedicamentos fmr7 = new MenuMedicamentos();
            fmr7.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MenuPago fmr8 = new MenuPago();
            fmr8.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MenuProveedores fmr9 = new MenuProveedores();
            fmr9.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MenuPuestos fmr10 = new MenuPuestos();
            fmr10.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MenuReporte fmr11 = new MenuReporte();
            fmr11.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MenuOrdenCompra fmr12 = new MenuOrdenCompra();
            fmr12.ShowDialog();
        }
    }
}
