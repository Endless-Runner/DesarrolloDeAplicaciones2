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

namespace DS1.Mantenimientos.SectorMantenimiento
{
        public partial class SectorForm : Form
        {
            CedulaEntities db = new CedulaEntities();
            List<string> msg = new List<string>();

            public SectorForm()
            {
                InitializeComponent();
                LoadSector();
                GetMunicipio();
            }

        void GetMunicipio()
        {
            var municipio = db.Municipios.ToList();

            cbMunicipio.ValueMember = "Id";
            cbMunicipio.DisplayMember = "Descripcion";
            cbMunicipio.DataSource = municipio;
        }
        public void LoadSector()
            {
                var sector = db.Sectors.ToList();

                if (!string.IsNullOrEmpty(txtFilter.Text))
                {
                    sector = sector.Where(x => x.Descripcion.Contains(txtFilter.Text)).ToList();
                }

                dataGridLugar.DataSource = sector.ToList();
            }


            void Save()
            {

                try
                {
                    var sector = new Sector
                    {
                        Descripcion = txtDesc.Text,
                        Estado = (int)EstadosEnum.Activo,
                        FechaCreacion = DateTime.UtcNow.AddMinutes(-240),
                        IdMunicipio = Convert.ToInt32(cbMunicipio.SelectedValue)
                    };

                    db.Sectors.Add(sector);
                    bool result = db.SaveChanges() > 0;

                    if (result)
                    {
                        LoadSector();

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
                txtDesc.Text = string.Empty;
                cbMunicipio.SelectedIndex = 0;
        }

            bool ValidateSaving()
            {
                msg = new List<string>();
                bool result = true;

                if (string.IsNullOrEmpty(txtDesc.Text))
                {
                    msg.Add("La descripcion es Requerida.");
                    result = false;
                }

                return result;
            }

        private void btnAgregar_Click_1(object sender, EventArgs e)
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

        private void btnFilter_Click_1(object sender, EventArgs e)
        {
            LoadSector();
        }
    }
    }

