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

namespace DS1.Mantenimientos.OcupacionMantenimiento
{
    public partial class OcupacionForm : Form
    {
        CedulaEntities db = new CedulaEntities();
        List<string> msg = new List<string>();

        public OcupacionForm()
        {
            InitializeComponent();
            LoadOcupacion();
        }

        public void LoadOcupacion()
        {
            var ocupacion = db.Ocupacions.ToList();

            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                ocupacion = ocupacion.Where(x => x.Descripcion.Contains(txtFilter.Text)).ToList();
            }

            dataGridLugar.DataSource = ocupacion.ToList();
        }


        void Save()
        {

            try
            {
                var ocupacion = new Ocupacion
                {
                    Descripcion = txtDesc.Text,
                    Estado = (int)EstadosEnum.Activo,
                    FechaCreacion = DateTime.UtcNow.AddMinutes(-240),
                };

                db.Ocupacions.Add(ocupacion);
                bool result = db.SaveChanges() > 0;

                if (result)
                {
                    LoadOcupacion();

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
            LoadOcupacion();
        }
    }
}
