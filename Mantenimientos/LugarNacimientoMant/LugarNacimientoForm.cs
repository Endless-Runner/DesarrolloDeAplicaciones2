using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DS1.Resources;

namespace DS1.Mantenimientos.LugarNacimientoMant
{
    public partial class LugarNacimientoForm : Form
    {
        CedulaEntities db = new CedulaEntities();
        List<string> msg = new List<string>();

        public LugarNacimientoForm()
        {
            InitializeComponent();
            LoadLugar();
        }

        public void LoadLugar()
        {
            var lugares = db.LugarNacimientoes.ToList();

            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                lugares = lugares.Where(x => x.Descripcion.Contains(txtFilter.Text)).ToList();
            }
            if (!string.IsNullOrEmpty(txtCodigoFilter.Text))
            {
                lugares = lugares.Where(x => x.Codigo.Equals(Convert.ToInt32(txtCodigoFilter.Text))).ToList();
            }
            dataGridLugar.DataSource = lugares.ToList();
        }

        
        void Save()
        {
            
            try
            {
                var lugares = new LugarNacimiento
                {
                    Descripcion = txtDesc.Text,
                    Estado = (int)EstadosEnum.Activo,
                    FechaCreacion = DateTime.UtcNow.AddMinutes(-240),
                    Codigo = Convert.ToInt32(txtCodigo.Text)
                };

                db.LugarNacimientoes.Add(lugares);
                bool result = db.SaveChanges() > 0;

                if (result)
                {
                    LoadLugar();

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
            txtCodigo.Text = string.Empty;
        }
        private void button1_Click(object sender, EventArgs e)
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

            if (string.IsNullOrEmpty(txtDesc.Text))
            {
                msg.Add("La descripcion es Requerida.");
                result = false;
            }
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                msg.Add("El Codigo es Requerido.");
                result = false;
            }

            return result;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LoadLugar();
        }
    }
}
