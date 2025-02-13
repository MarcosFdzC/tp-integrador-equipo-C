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
            var algo = dgvPacientes.SelectedRow.Cells[0].Text;
            var id = dgvPacientes.SelectedDataKey.Value.ToString();
            Response.Redirect("AgregarPaciente.aspx?" + id, false);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarPaciente.aspx", false);
        }
    }
}