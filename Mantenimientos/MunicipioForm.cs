using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DS1.Mantenimientos
{
    public partial class MunicipioForm : Form
    {
        CedulaEntities Entities = new CedulaEntities();
        List<string> msg = new List<string>();
        public MunicipioForm()
        {
            InitializeComponent();
            LoadMunicipio();
        }

        private void MunicipioForm_Load(object sender, EventArgs e)
        {

        }
        public void LoadMunicipio()
        {
            var municipio = Entities.Municipios.Select(c => new
            {
                c.Id,
                c.Descripcion,
                c.Estado,
                c.FechaCreacion,
                c.FechaModificacion,

            }).ToList();
            dtgmunicipio.DataSource = municipio;
        }

        private void btnSaveRole_Click(object sender, EventArgs e)
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
        void Save()
        {
            try
            {
                var municipio = new Municipio
                {

                    Descripcion = txtMunicipio.Text,
                    Estado = (rbEnabled.Enabled) ? 1 : 0,
                    FechaCreacion = DateTime.UtcNow.AddMinutes(-240)
                };

                Entities.Municipios.Add(municipio);
                bool result = Entities.SaveChanges() > 0;

                if (result)
                {
                    LoadMunicipio();

                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: Saving Role");
                Console.WriteLine(ex);
            }
        }
        bool ValidateSaving()
        {
            msg = new List<string>();
            bool result = true;

            if (string.IsNullOrEmpty(txtMunicipio.Text))
            {
                msg.Add("El municipio es Requerido.");
                result = false;
            }

            //Validations in DB
            if (CheckTitle(txtMunicipio.Text))
            {
                msg.Add($"El municipio ({txtMunicipio.Text.ToUpper()}) ya esta registrado");
                result = false;
            }

            return result;
        }
        bool CheckTitle(string titulo)
        {
            //   return Entities.TipoSangres.Count(x => x.Title == titulo) > 0;
            return false;
        }
        void ClearForm()
        {
            txtMunicipio.Text = string.Empty;
            txtMunicipio.Text = string.Empty;
            rbEnabled.Checked = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var search = txtsearch.Text;
            var sangre = Entities.Municipios.Where(c =>
               c.Descripcion.Contains(search)).
               Select(c => new {
                   c.Id,
                   c.Descripcion,
                   c.Estado,
                   c.FechaCreacion,
                   c.FechaModificacion,

               }).ToList();
            dtgmunicipio.DataSource = sangre;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            ClearForm();
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            txtTitleFilter.Text = string.Empty;
            txtDescFilter.Text = string.Empty;
        }
    }
}
