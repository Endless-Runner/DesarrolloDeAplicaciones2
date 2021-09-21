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

namespace DS1.Mantenimientos.EstadoCivilMantenimiento
{
    public partial class EstadoCivilForm : Form
    {
        CedulaEntities db = new CedulaEntities();
        List<string> msg = new List<string>();

        public EstadoCivilForm()
        {
            InitializeComponent();
            LoadEstadoC();
        }

        public void LoadEstadoC()
        {
            var estadoc = db.EstadoCivils.ToList();

            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                estadoc = estadoc.Where(x => x.Descripcion.Contains(txtFilter.Text)).ToList();
            }

            dataGridLugar.DataSource = estadoc.ToList();
        }


        void Save()
        {

            try
            {
                var estadoc = new EstadoCivil
                {
                    Descripcion = txtDesc.Text,
                    Estado = (int)EstadosEnum.Activo,
                    FechaCreacion = DateTime.UtcNow.AddMinutes(-240),
                };

                db.EstadoCivils.Add(estadoc);
                bool result = db.SaveChanges() > 0;

                if (result)
                {
                    LoadEstadoC();

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
            LoadEstadoC();
        }
    }
}
