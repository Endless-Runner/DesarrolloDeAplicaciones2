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

namespace DS1.Mantenimientos.CedulaMantenimiento
{
    public partial class GestionCedula : Form
    {
        CedulaEntities Entities = new CedulaEntities();
        CedulaForm cdform = new CedulaForm();
        public int? cedulaToEditId;
        public GestionCedula()
        {
            InitializeComponent();
            LoadComboBox();
        }

        void LoadComboBox()
        {
            var cbNacionalidadData = Entities.Nacionalidads.Where(n => n.Estado == (int)EstadosEnum.Activo).Select(n => new { id = n.Id, text = n.Descripcion }).ToList();
            var cbLugarNacimientoData = Entities.LugarNacimientoes.Where(n => n.Estado == (int)EstadosEnum.Activo).Select(n => new { id = n.Id, text = n.Descripcion }).ToList();
            var cbSexoData = Entities.Sexoes.Where(n => n.Estado == (int)EstadosEnum.Activo).Select(n => new { id = n.Id, text = n.Descripcion }).ToList();
            var cbTipoSangreData = Entities.TipoSangres.Where(n => n.Estado == (int)EstadosEnum.Activo).Select(n => new { id = n.Id, text = n.Descripcion }).ToList();
            var cbOcupacionData = Entities.Ocupacions.Where(n => n.Estado == (int)EstadosEnum.Activo).Select(n => new { id = n.Id, text = n.Descripcion }).ToList();
            var cbEstadoCivilData = Entities.EstadoCivils.Where(n => n.Estado == (int)EstadosEnum.Activo).Select(n => new { id = n.Id, text = n.Descripcion }).ToList();
            var cbMunicipioData = Entities.Municipios.Where(n => n.Estado == (int)EstadosEnum.Activo).Select(n => new { id = n.Id, text = n.Descripcion }).ToList();
            var cbSectorData = Entities.Sectors.Where(n => n.Estado == (int)EstadosEnum.Activo).Select(n => new { id = n.Id, text = n.Descripcion }).ToList();
            var cbColegioData = Entities.Colegios.Where(n => n.Estado == (int)EstadosEnum.Activo).Select(n => new { id = n.Id, text = n.Nombre }).ToList();

            cbNacionalidadData.ForEach(data =>
            cbNacionalidad.Items.Insert(data.id, data.text)
            );
            cbLugarNacimientoData.ForEach(data =>
            cbLugarNacimiento.Items.Insert(data.id, data.text)
            );
            cbSexoData.ForEach(data =>
            cbSexo.Items.Insert(data.id, data.text)
            );
            cbTipoSangreData.ForEach(data =>
            cbTipoSangre.Items.Insert(data.id, data.text)
            );
            cbOcupacionData.ForEach(data =>
            cbOcupacion.Items.Insert(data.id, data.text)
            );
            cbEstadoCivilData.ForEach(data =>
            cbEstadoCivil.Items.Insert(data.id, data.text)
            );
            cbMunicipioData.ForEach(data =>
            cbMunicipio.Items.Insert(data.id, data.text)
            );
            cbSectorData.ForEach(data =>
            cbSector.Items.Insert(data.id, data.text)
            );
            cbColegioData.ForEach(data =>
            cbColegio.Items.Insert(data.id, data.text)
            );
        }
        public void LoadData()
        {
            var Cedula = Entities.Cedulas.Find(cedulaToEditId);
            tbNombre.Text = Cedula.Nombre;
            tbApellido.Text = Cedula.Apellido;
            dtFechaNacimiento.Value = Cedula.FechaNacimiento;
            tbDireccionResidencia.Text = Cedula.DireccionResidencia;
            cbColegio.SelectedIndex = Cedula.IdColegioElectoral;
            cbNacionalidad.SelectedIndex = Cedula.IdNacional;
            cbEstadoCivil.SelectedIndex = Cedula.IdEstadoCivil;
            cbLugarNacimiento.SelectedIndex = Cedula.IdLugarNacimiento;
            cbSexo.SelectedIndex = Cedula.IdSexo;
            cbTipoSangre.SelectedIndex = Cedula.IdTipoSangre;
            cbOcupacion.SelectedIndex = Cedula.IdOcupacion;
            cbOcupacion.SelectedIndex = Cedula.IdOcupacion;
            cbMunicipio.SelectedIndex = Cedula.IdMunicipio;
            cbSector.SelectedIndex = Cedula.IdSector;

        }

        Cedula GetObject()
        {
            var rnd = new Random();
            var diaMesNacimiento = dtFechaNacimiento.Value.ToString("dd-MM");
            var anoVencimiento = DateTime.UtcNow.AddYears(8).ToString("-yyyy");
            DateTime FechaExpiracion = Convert.ToDateTime(diaMesNacimiento + anoVencimiento);
            return new Cedula
            {
                Codigo = Entities.LugarNacimientoes.FirstOrDefault(l => l.Id == cbLugarNacimiento.SelectedIndex).Codigo + "-" + rnd.Next(1000000, 9999999),
                Nombre = tbNombre.Text,
                Apellido = tbApellido.Text,
                FechaNacimiento = dtFechaNacimiento.Value,
                FechaExpiracion = FechaExpiracion,
                DireccionResidencia = tbDireccionResidencia.Text,
                IdColegioElectoral = cbColegio.SelectedIndex,
                IdNacional = cbNacionalidad.SelectedIndex,
                IdLugarNacimiento = cbLugarNacimiento.SelectedIndex,
                IdSexo = cbSexo.SelectedIndex,
                IdTipoSangre = cbTipoSangre.SelectedIndex,
                IdOcupacion = cbOcupacion.SelectedIndex,
                IdEstadoCivil = cbOcupacion.SelectedIndex,
                IdMunicipio = cbMunicipio.SelectedIndex,
                IdSector = cbSector.SelectedIndex,
                Estado = (int)EstadosEnum.Activo,
                FechaCreacion = DateTime.UtcNow.AddMinutes(-240)
            };
        }

        void update()
        {
            var cedulaToUpdate = Entities.Cedulas.Find(cedulaToEditId);
            var cedulaChange = GetObject();
            cedulaToUpdate.IdColegioElectoral = cedulaChange.IdColegioElectoral;
            cedulaToUpdate.Nombre = cedulaChange.Nombre;
            cedulaToUpdate.Apellido = cedulaChange.Apellido;
            cedulaToUpdate.DireccionResidencia = cedulaChange.DireccionResidencia;
            cedulaToUpdate.IdEstadoCivil = cedulaChange.IdEstadoCivil;
            cedulaToUpdate.FechaNacimiento = cedulaChange.FechaNacimiento;
            cedulaToUpdate.FechaExpiracion = cedulaChange.FechaExpiracion;
            cedulaToUpdate.IdLugarNacimiento = cedulaChange.IdLugarNacimiento;
            cedulaToUpdate.IdMunicipio = cedulaChange.IdMunicipio;
            cedulaToUpdate.IdOcupacion = cedulaChange.IdOcupacion;
            cedulaToUpdate.IdSector = cedulaChange.IdSector;
            cedulaToUpdate.FechaModificacion = DateTime.UtcNow.AddMinutes(-240);

            bool result = Entities.SaveChanges() > 0;

            if (result)
            {
                this.Close();
            }
        }
        void Save()
        {
            var NewCedula = GetObject();
            Entities.Cedulas.Add(NewCedula);
            bool result = Entities.SaveChanges() > 0;

            if (result)
            {
                this.Close();
            }
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            var rnd = new Random();
            try
            {
                if (cedulaToEditId!=null)
                {
                    update();
                }
                else
                {
                    Save();
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
