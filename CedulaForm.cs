using DS1.Mantenimientos.CedulaMantenimiento;
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
    public partial class CedulaForm : Form
    {
        CedulaEntities Entities = new CedulaEntities();
        public CedulaForm()
        {
            InitializeComponent();
            LoadCedulas();
        }

        void LoadCedulas()
        {
            var cedulas = Entities.Cedulas.Select(c=>new {
            c.Id,
            c.Codigo,
            c.Nombre,
            c.Apellido,
            c.FechaNacimiento,
            c.FechaExpiracion,
            Direccion = c.DireccionResidencia,
            Colegio =c.Colegio.Nombre,
            Nacionalidad=c.Nacionalidad.Descripcion,
            Nacimiento=c.LugarNacimiento.Descripcion,
            Sexo = c.Sexo.Descripcion,
            TipoSangre = c.TipoSangre.Descripcion,
            Ocupacion = c.Ocupacion.Descripcion,
            EstadoCivil = c.EstadoCivil.Descripcion,
            Municipio = c.Municipio.Descripcion,
            Sector=c.Sector.Descripcion,
            Estado = (c.Estado==1)?"Activo":"Inactivo",
            }).ToList();
            dtgCedulas.DataSource = cedulas;
        }

        private void addButtom_Click(object sender, EventArgs e)
        {
            var AddCedulaForm = new AddCedula();
            AddCedulaForm.Show();
        }
    }
}
