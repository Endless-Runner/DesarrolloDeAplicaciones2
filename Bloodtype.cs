using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DS1.Mantenimientos.CedulaMantenimiento;

namespace DS1
{
    public partial class Bloodtype : Form
    {
        CedulaEntities Entities = new CedulaEntities();
        List<string> msg = new List<string>();
        public Bloodtype()
        {
            InitializeComponent();
            LoadSangre();
        }


        public void LoadSangre()
        {
            var sangre = Entities.TipoSangres.Select(c => new
            {
                c.Id,
                c.Descripcion,
                c.Estado,
                c.FechaCreacion,
                c.FechaModificacion,

            }).ToList();
            dtgsangre.DataSource = sangre;
        }
        private void btnSaveBlood_Click(object sender, EventArgs e)
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
        bool ValidateSaving()
        {
            msg = new List<string>();
            bool result = true;

            if (string.IsNullOrEmpty(txtSangre.Text))
            {
                msg.Add("El grupo sanguineo es Requerido.");
                result = false;
            }

            //Validations in DB
            if (CheckTitle(txtSangre.Text))
            {
                msg.Add($"El tipo de sangre ({txtSangre.Text.ToUpper()}) ya esta registrado");
                result = false;
            }

            return result;
        }
        bool CheckTitle(string titulo)
        {
            //   return Entities.TipoSangres.Count(x => x.Title == titulo) > 0;
            return false;
        }
        void Save()
        {
            try
            {
                var sangre = new TipoSangre
                {
                    
                    Descripcion = txtSangre.Text,
                    Estado = (rbEnabled.Enabled) ? 1:0,
                   FechaCreacion = DateTime.UtcNow.AddMinutes(-240)
                };

                Entities.TipoSangres.Add(sangre);
                bool result = Entities.SaveChanges() > 0;

                if (result)
                {
                    LoadSangre();

                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: Saving Role");
                Console.WriteLine(ex);
            }
        }
        void ClearForm()
        {
            txtSangre.Text = string.Empty;
            txtSangre.Text = string.Empty;
            rbEnabled.Checked = true;
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Bloodtype_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            ClearForm();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var search = txtsearch.Text;
            var sangre = Entities.TipoSangres.Where(c =>
               c.Descripcion.Contains(search)). 
               Select(c => new {
                   c.Id,
                   c.Descripcion,
                   c.Estado,
                   c.FechaCreacion,
                   c.FechaModificacion,
                 
               }).ToList();
            dtgsangre.DataSource = sangre;
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            txtTitleFilter.Text = string.Empty;
            txtDescFilter.Text = string.Empty;
        }
    }
    
}
