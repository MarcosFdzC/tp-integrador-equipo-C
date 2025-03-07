<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="Clinica.Turnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Turnos</h1>
<asp:GridView ID="dgvPacientes" runat="server" class="table table-dark table-bordered" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvPacientes_SelectedIndexChanged" DataKeyNames="Id"> 
    <Columns>
        <%--//Id, Nombre, Apellido, Dni, FechaNacimiento, Telefono, Email, Turnos--%>
        <%-- Asi ocultamos un elemento de manera visual, pero sigue estando en html si necesitamos su lectura --%>
        <%--<asp:BoundField HeaderText="Id" DataField="Id" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto"/>--%>
        <asp:BoundField HeaderText="Nombre Paciente" DataField="Turno.Paciente.Nombre" /> 
        <asp:BoundField HeaderText="Nombre Medico" DataField="Apellido" /> 
        <asp:BoundField HeaderText="Especialidad" DataField="Dni" /> 
        <asp:BoundField HeaderText="Fecha " DataField="FechaNacimiento" /> 
        <asp:BoundField HeaderText="Observaciones" DataField="Email" /> 
        <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Turnos.aspx? Id={0}" HeaderText="Turnos" Text="Ver turnos" />
        <asp:CommandField ShowSelectButton="true" SelectText="Editar" HeaderText="Editar Datos" />
    </Columns>
</asp:GridView>
</asp:Content>
