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
    public partial class AddCedula : Form
    {
        CedulaEntities Entities = new CedulaEntities();
        public AddCedula()
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

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                var NewCedula = new Cedula
                {
                    Codigo = "123123123123123",
                    Nombre = tbNombre.Text,
                    Apellido = tbApellido.Text,
                    FechaNacimiento = dtFechaNacimiento.Value,
                    FechaExpiracion = DateTime.UtcNow.AddYears(8),
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
                Entities.Cedulas.Add(NewCedula);
                bool result = Entities.SaveChanges() > 0;

                if (result)
                {
                    this.Close();
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
