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

namespace DS1.Mantenimientos.NacionalidadMantenimiento
{
        public partial class NacionalidadForm : Form
        {
            CedulaEntities db = new CedulaEntities();
            List<string> msg = new List<string>();

            public NacionalidadForm()
            {
                InitializeComponent();
                LoadNacionalidad();
            }

            public void LoadNacionalidad()
            {
                var nacion = db.Nacionalidads.ToList();

                if (!string.IsNullOrEmpty(txtFilter.Text))
                {
                nacion = nacion.Where(x => x.Descripcion.Contains(txtFilter.Text)).ToList();
                }

                dataGridLugar.DataSource = nacion.ToList();
            }


            void Save()
            {

                try
                {
                    var nacion = new Nacionalidad
                    {
                        Descripcion = txtDesc.Text,
                        Estado = (int)EstadosEnum.Activo,
                        FechaCreacion = DateTime.UtcNow.AddMinutes(-240),
                    };

                    db.Nacionalidads.Add(nacion);
                    bool result = db.SaveChanges() > 0;

                    if (result)
                    {
                        LoadNacionalidad();

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
            LoadNacionalidad();
        }
    }
}
