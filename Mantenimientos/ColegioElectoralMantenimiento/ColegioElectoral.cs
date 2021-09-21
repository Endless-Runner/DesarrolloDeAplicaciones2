using DS1.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DS1.Mantenimientos.ColegioElectoralMantenimiento
{
    public partial class ColegioElectoralForm : Form
    {
        CedulaEntities db = new CedulaEntities();
        List<string> msg = new List<string>();

        public ColegioElectoralForm()
        {
            InitializeComponent();
            LoadColegio();
            GetMunsec();
        }

        void GetMunsec()
        {
            var municipio = db.Municipios.ToList();
            var sector = db.Sectors.ToList();

            cbSector.ValueMember = "Id";
            cbSector.DisplayMember = "Descripcion";
            cbSector.DataSource = sector;

            cbMunicipio.ValueMember = "Id";
            cbMunicipio.DisplayMember = "Descripcion";
            cbMunicipio.DataSource = municipio;
        }
        public void LoadColegio()
        {
            var colegio = db.Colegios.ToList();

            if (!string.IsNullOrEmpty(txtNomFilter.Text))
            {
                colegio = colegio.Where(x => x.Nombre.Contains(txtNomFilter.Text)).ToList();
            }
            if (!string.IsNullOrEmpty(txtDirFilter.Text))
            {
                colegio = colegio.Where(x => x.Direccion.Contains(txtDirFilter.Text)).ToList();
            }

            dataGridLugar.DataSource = colegio.ToList();
        }


        void Save()
        {

            try
            {
                var colegio = new Colegio
                {
                    Nombre = txtNom.Text,
                    Direccion = txtDir.Text,
                    Estado = (int)EstadosEnum.Activo,
                    FechaCreacion = DateTime.UtcNow.AddMinutes(-240),
                    IdMunicipio = Convert.ToInt32(cbMunicipio.SelectedValue),
                    IdSector = Convert.ToInt32(cbSector.SelectedValue)
                };

                db.Colegios.Add(colegio);
                bool result = db.SaveChanges() > 0;

                if (result)
                {
                    LoadColegio();

                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: Saving Place");
                Console.WriteLine(ex);
            }
        }
        void ClearForm()
        {
            txtNom.Text = string.Empty;
            txtDir.Text = string.Empty;
            cbMunicipio.SelectedIndex = 0;
            cbSector.SelectedIndex = 0;
        }

        bool ValidateSaving()
        {
            msg = new List<string>();
            bool result = true;

            if (string.IsNullOrEmpty(txtNom.Text))
            {
                msg.Add("El Nombre es Requerido.");
                result = false;
            }
            if (string.IsNullOrEmpty(txtDir.Text))
            {
                msg.Add("La direccion es Requerida.");
                result = false;
            }

            return result;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidateSaving() == true)
            {
                Save();
            }
            else
            {
                var list = string.Empty;
                foreach (var item in msg)
                {
                    list += item + "\n";
                }

                MessageBox.Show(list, "INTEC");
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadColegio();
        }
    }
}
