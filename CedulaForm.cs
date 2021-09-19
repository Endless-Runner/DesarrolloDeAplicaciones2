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

        public void LoadCedulas()
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

        private void buscarButton_Click(object sender, EventArgs e)
        {
            var search = tbBuscar.Text;
            var cedulas = Entities.Cedulas.Where(c =>
               c.Apellido.Contains(search)||
               c.Nombre.Contains(search)||
               c.Colegio.Nombre.Contains(search)||
               c.LugarNacimiento.Descripcion.Contains(search)||
               c.LugarNacimiento.Descripcion.Contains(search)||
               c.Sexo.Descripcion.Contains(search)||
               c.TipoSangre.Descripcion.Contains(search)||
               c.Ocupacion.Descripcion.Contains(search)||
               c.EstadoCivil.Descripcion.Contains(search)||
               c.Municipio.Descripcion.Contains(search)||
               c.Sector.Descripcion.Contains(search)||
               c.FechaCreacion.ToString().Contains(search)||
               c.FechaNacimiento.ToString().Contains(search)||
               c.FechaExpiracion.ToString().Contains(search)).
               Select(c => new {
                   c.Id,
                   c.Codigo,
                   c.Nombre,
                   c.Apellido,
                   c.FechaNacimiento,
                   c.FechaExpiracion,
                   Direccion = c.DireccionResidencia,
                   Colegio = c.Colegio.Nombre,
                   Nacionalidad = c.Nacionalidad.Descripcion,
                   Nacimiento = c.LugarNacimiento.Descripcion,
                   Sexo = c.Sexo.Descripcion,
                   TipoSangre = c.TipoSangre.Descripcion,
                   Ocupacion = c.Ocupacion.Descripcion,
                   EstadoCivil = c.EstadoCivil.Descripcion,
                   Municipio = c.Municipio.Descripcion,
                   Sector = c.Sector.Descripcion,
                   Estado = (c.Estado == 1) ? "Activo" : "Inactivo",
               }).ToList();
            dtgCedulas.DataSource = cedulas;
        }
    }
}
