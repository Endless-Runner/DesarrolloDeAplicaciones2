using DS1.Mantenimientos.ColegioElectoralMantenimiento;
using DS1.Mantenimientos;
using DS1.Mantenimientos.EstadoCivilMantenimiento;
using DS1.Mantenimientos.LugarNacimientoMant;
using DS1.Mantenimientos.NacionalidadMantenimiento;
using DS1.Mantenimientos.OcupacionMantenimiento;
using DS1.Mantenimientos.SectorMantenimiento;
using DS1.Mantenimientos.SexoMantenimiento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DS1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            System.Security.Principal.WindowsIdentity wi = System.Security.Principal.WindowsIdentity.GetCurrent();

            lblMsg.Text = $"Autenticado como: { wi.Name.ToString()}";
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var roleForm = new RoleForm() { MdiParent = this };
            roleForm.Show();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var userForm = new UserForm() { MdiParent = this };
            userForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea Salir del Sistema?", "DS1 INTEC", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void cascadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void iconosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var CedulaForm = new CedulaForm() { MdiParent = this };
            CedulaForm.Show();
        }

        private void lugarDeNacimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lugarNacimientoForm = new LugarNacimientoForm() { MdiParent = this };
            lugarNacimientoForm.Show();
        }

        private void ocupacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ocupacionForm = new OcupacionForm() { MdiParent = this };
            ocupacionForm.Show();
        }

        private void sexoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sexoForm = new SexoForm() { MdiParent = this };
            sexoForm.Show();
        }

        private void estadoCivilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var estadocForm = new EstadoCivilForm() { MdiParent = this };
            estadocForm.Show();
        }

        private void nacionalidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nacionForm = new NacionalidadForm() { MdiParent = this };
            nacionForm.Show();
        }

        private void sectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sectorForm = new SectorForm() { MdiParent = this };
            sectorForm.Show();
        }

        private void colegioElectoralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var colegioForm = new ColegioElectoralForm() { MdiParent = this };
            colegioForm.Show();
        }
        private void tipoSangreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Bloodform = new Bloodtype() { MdiParent = this };
            Bloodform.Show();
        }

        private void municipioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Municipioform = new MunicipioForm() { MdiParent = this };
            Municipioform.Show();

            
        }
    }
}
