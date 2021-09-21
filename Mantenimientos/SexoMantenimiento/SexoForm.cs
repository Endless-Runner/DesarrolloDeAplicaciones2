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

namespace DS1.Mantenimientos.SexoMantenimiento
{
    public partial class SexoForm : Form
    {
        CedulaEntities db = new CedulaEntities();
        List<string> msg = new List<string>();

        public SexoForm()
        {
            InitializeComponent();
            LoadSexo();
        }

        public void LoadSexo()
        {
            var sexo = db.Sexoes.ToList();

            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                sexo = sexo.Where(x => x.Descripcion.Contains(txtFilter.Text)).ToList();
            }

            dataGridLugar.DataSource = sexo.ToList();
        }


        void Save()
        {

            try
            {
                var sexo = new Sexo
                {
                    Descripcion = txtDesc.Text,
                    Estado = (int)EstadosEnum.Activo,
                    FechaCreacion = DateTime.UtcNow.AddMinutes(-240),
                };

                db.Sexoes.Add(sexo);
                bool result = db.SaveChanges() > 0;

                if (result)
                {
                    LoadSexo();

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
            LoadSexo();
        }
    }
}
