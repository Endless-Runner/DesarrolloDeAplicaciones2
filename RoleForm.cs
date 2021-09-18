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
    public partial class RoleForm : Form
    {
        DS1Entities db = new DS1Entities();
        List<string> msg = new List<string>();
        public RoleForm()
        {
            InitializeComponent();

            LoadRoles();
        }

        void LoadRoles()
        {
            var roles = db.Role.ToList();

            if (!string.IsNullOrEmpty(txtTitleFilter.Text))
            {
                roles = roles.Where(x => x.Title.Contains(txtTitleFilter.Text)).ToList();
            }

            if (!string.IsNullOrEmpty(txtDescFilter.Text))
            {
                roles = roles.Where(x => x.Description.Contains(txtDescFilter.Text)).ToList();
            }

            dgvRoles.DataSource = roles.ToList();
        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
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

            if (string.IsNullOrEmpty(txtTituloRol.Text))
            {
                msg.Add("El Rol es Requerido.");
                result = false;
            }

            //Validations in DB
            if (CheckTitle(txtTituloRol.Text))
            {
                msg.Add($"El Rol de Usuario ({txtTituloRol.Text.ToUpper()}) ya esta registrado");
                result = false;
            }

            return result;
        }
        bool CheckTitle(string titulo)
        {
            return db.Role.Count(x => x.Title == titulo) > 0;
        }

        void Save()
        {
            try
            {
                var rol = new Role
                {
                    Title = txtTituloRol.Text,
                    Description = txtDescRol.Text,
                    Enabled = rbEnabled.Checked,
                    CreatedDate = DateTime.Now
                };

                db.Role.Add(rol);
                bool result = db.SaveChanges() > 0;

                if (result)
                {
                    LoadRoles();

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
            txtTituloRol.Text = string.Empty;
            txtDescRol.Text = string.Empty;
            rbEnabled.Checked = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtTitleFilter.Text = string.Empty;
            txtDescFilter.Text = string.Empty;
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadRoles();
        }
    }
}
