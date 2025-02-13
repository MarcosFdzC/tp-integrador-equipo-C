<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="Clinica.Pacientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .oculto {
            display: none;
        }
    </style>
    <h1>Pacientes</h1>
    <asp:GridView ID="dgvPacientes" runat="server" class="table table-dark table-bordered" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvPacientes_SelectedIndexChanged" DataKeyNames="Id"> 
        <Columns>
            <%--//Id, Nombre, Apellido, Dni, FechaNacimiento, Telefono, Email, Turnos--%>
            <%-- Asi ocultamos un elemento de manera visual, pero sigue estando en html si necesitamos su lectura --%>
            <%--<asp:BoundField HeaderText="Id" DataField="Id" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto"/>--%>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" /> 
            <asp:BoundField HeaderText="Apellido" DataField="Apellido" /> 
            <asp:BoundField HeaderText="Dni" DataField="Dni" /> 
            <asp:BoundField HeaderText="Fecha de Nacimiento" DataField="FechaNacimiento" /> 
            <asp:BoundField HeaderText="Teléfono" DataField="Telefono" /> 
            <asp:BoundField HeaderText="Correo electrónico" DataField="Email" /> 
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Turnos.aspx? Id={0}" HeaderText="Turnos" Text="Ver turnos" />
            <asp:CommandField ShowSelectButton="true" SelectText="Editar" HeaderText="Editar Datos" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" class="btn btn-primary" OnClick="btnAgregar_Click"/>
</asp:Content>
