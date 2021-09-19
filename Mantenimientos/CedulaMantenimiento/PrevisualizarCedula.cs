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
    public partial class PrevisualizarCedula : Form
    {
        CedulaEntities Entities = new CedulaEntities();
        CedulaForm cdform = new CedulaForm();
        public int cedulaToEditId;
        public PrevisualizarCedula()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            var Cedula = Entities.Cedulas.Find(cedulaToEditId);
            lNombre.Text = Cedula.Nombre;
            lPrueba.Text = Cedula.Apellido;
            lCodigo.Text = Cedula.Codigo;
            lFechaNacimiento.Text = Cedula.FechaNacimiento.ToString("dd MMMM yyyy");
            lNacionalidad.Text = Cedula.Nacionalidad.Descripcion;
            lEstadoCivil.Text = Cedula.EstadoCivil.Descripcion;
            lLugarNacimiento.Text = Cedula.LugarNacimiento.Descripcion;
            lSexo.Text = Cedula.Sexo.Descripcion;
            lTipoSangre.Text = Cedula.TipoSangre.Descripcion;
            lOcupacion.Text = Cedula.Ocupacion.Descripcion;
            lFechaExpiracion.Text = Cedula.FechaNacimiento.ToString("dd MMMM yyyy");
        }
    }
}
