using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica
{
    public partial class AgregarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnAgregar.Text = Request.QueryString["id"] != null ? "Modificiar" : "Agregar";
            if (Session["paciente"] != null && Request.QueryString["id"] != null)
            {
                Paciente paciente = (Paciente)Session["paciente"];
                txtNombre.Text = paciente.Nombre;
                txtApellido.Text = paciente.Apellido;
                txtDni.Text = paciente.Dni.ToString();
                txtFechaNacimiento.Text = paciente.FechaNacimiento.ToString();
                txtTelefono.Text = paciente.Telefono.ToString();
                txtEmail.Text = paciente.Email;

            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            PacienteNegocio pacienteNegocio = new PacienteNegocio();
            Paciente paciente = new Paciente();
            paciente.Nombre = txtNombre.Text;
            paciente.Apellido = txtApellido.Text;
            paciente.Dni = int.Parse(txtDni.Text);
            paciente.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
            paciente.Telefono = int.Parse(txtTelefono.Text);
            paciente.Email = txtEmail.Text;
            pacienteNegocio.Agregar(paciente);
        }
    }
}