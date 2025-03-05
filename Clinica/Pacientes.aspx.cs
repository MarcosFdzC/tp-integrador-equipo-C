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
    public partial class Pacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PacienteNegocio pacienteNeg = new PacienteNegocio();
            dgvPacientes.DataSource = pacienteNeg.listar();
            dgvPacientes.DataBind();
        }

        protected void dgvPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Paciente paciente = new Paciente();
            paciente.Id = int.Parse(dgvPacientes.SelectedDataKey.Value.ToString());
            paciente.Nombre = dgvPacientes.SelectedRow.Cells[0].Text;
            paciente.Apellido = dgvPacientes.SelectedRow.Cells[1].Text;
            paciente.Dni = int.Parse(dgvPacientes.SelectedRow.Cells[2].Text);
            paciente.FechaNacimiento = DateTime.Parse(dgvPacientes.SelectedRow.Cells[3].Text);
            paciente.Telefono = int.Parse(dgvPacientes.SelectedRow.Cells[4].Text);
            paciente.Email = dgvPacientes.SelectedRow.Cells[5].Text;
            Session.Add("paciente", paciente);


            //var algo = dgvPacientes.SelectedRow.Cells[0].Text;
            var id = dgvPacientes.SelectedDataKey.Value.ToString();
            Response.Redirect("AgregarPaciente.aspx?id=" + id, false);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarPaciente.aspx", false);
        }
    }
}