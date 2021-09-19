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
        List<string> msg = new List<string>();
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

            var cbSectorData = Entities.Sectors.Where(n => n.Estado == (int)EstadosEnum.Activo && n.IdMunicipio == cbMunicipio.SelectedIndex).Select(n => new { id = n.Id, text = n.Descripcion }).ToList();
            //necesita sacarlo de municipio 
            cbSectorData.ForEach(data =>
            cbSector.Items.Insert(data.id, data.text)
            );

            var cbColegioData = Entities.Colegios.Where(n => n.Estado == (int)EstadosEnum.Activo && n.IdMunicipio == cbMunicipio.SelectedIndex && n.IdSector == cbSector.SelectedIndex).Select(n => new { id = n.Id, text = n.Nombre }).ToList();
            //necesita sacarlo de municipio y sector
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
            var Existe = Entities.Cedulas.Any(c => c.Nombre == NewCedula.Nombre && c.Apellido == NewCedula.Apellido);
            if (!Existe) Entities.Cedulas.Add(NewCedula);
            else
            {
                
            }
            bool result = Entities.SaveChanges() > 0;

            if (result)
            {
                this.Close();
            }
        }
        bool ValidandoDatos()
        {
            msg = new List<string>();
            bool result = true;

            if (string.IsNullOrEmpty(tbNombre.Text))
            {
                msg.Add("El campo Nombre es Requerido.");
                result = false;
            }
            if (string.IsNullOrEmpty(tbApellido.Text))
            {
                msg.Add("El campo Apellido es Requerido.");
                result = false;
            }
            if (string.IsNullOrEmpty(tbApellido.Text))
            {
                msg.Add("El campo Apellido es Requerido.");
                result = false;
            }
            if (string.IsNullOrEmpty(tbDireccionResidencia.Text))
            {
                msg.Add("El campo Direccion Residencia es Requerido.");
                result = false;
            }
            if (string.IsNullOrEmpty(cbNacionalidad.Text))
            {
                msg.Add("El campo Nacionalidad es Requerido.");
                result = false;
            }
            if (string.IsNullOrEmpty(cbLugarNacimiento.Text))
            {
                msg.Add("El campo Lugar Nacimiento es Requerido.");
                result = false;
            }
            if (string.IsNullOrEmpty(cbSexo.Text))
            {
                msg.Add("El campo Sexo es Requerido.");
                result = false;
            }
            if (string.IsNullOrEmpty(cbTipoSangre.Text))
            {
                msg.Add("El campo Tipo de Sangre es Requerido.");
                result = false;
            }
            if (string.IsNullOrEmpty(cbOcupacion.Text))
            {
                msg.Add("El campo Ocupacion es Requerido.");
                result = false;
            }
            if (string.IsNullOrEmpty(cbEstadoCivil.Text))
            {
                msg.Add("El campo Estado Civil es Requerido.");
                result = false;
            }
            if (string.IsNullOrEmpty(cbMunicipio.Text))
            {
                msg.Add("El campo Municipio es Requerido.");
                result = false;
            }
            if (string.IsNullOrEmpty(cbSector.Text))
            {
                msg.Add("El campo Sector es Requerido.");
                result = false;
            }
            if (string.IsNullOrEmpty(cbColegio.Text))
            {
                msg.Add("El campo Colegio es Requerido.");
                result = false;
            }

            return result;
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            var rnd = new Random();
            try
            {
                if (ValidandoDatos())
                {
                    if (cedulaToEditId != null)
                    {
                        update();
                    }
                    else
                    {
                        Save();
                    }
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
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbMunicipio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadComboBox();
        }

        private void cbSector_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadComboBox();
        }
    }
}
