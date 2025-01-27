<%@ Page Title="Pacientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarPaciente.aspx.cs" Inherits="Clinica.AgregarPaciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% if (Session["Turno"] == null)
        {%>
    <h1>Agregar nuevo Turno</h1>
    <% }
        else
        {%>
    <h1>Modificar Turno</h1>
    <% } %>

    <div class="col-4"></div>


    <%--Id, Nombre, Apellido, Dni, FechaNacimiento, Telefono, Email--%>
    <div class="row mb-3">
        <label for="txtNombre" class="col-sm-2 col-form-label">Nombre:</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row mb-3">
        <label for="txtApellido" class="col-sm-2 col-form-label">Apellido:</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtApellido" runat="server" class="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row mb-3">
        <label for="txtDni" class="col-sm-2 col-form-label">Dni:</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtDni" runat="server" class="form-control"></asp:TextBox> 
        </div>
    </div>
    <div class="row mb-3">
        <label for="txtFechaNacimiento" class="col-sm-2 col-form-label">Fecha de nacimiento:</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtFechaNacimiento" runat="server" class="form-control" TextMode="Date"></asp:TextBox>
        </div>
    </div>
    <div class="row mb-3">
        <label for="txtTelefono" class="col-sm-2 col-form-label">Teléfono:</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtTelefono" runat="server" class="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row mb-3">
        <label for="txtEmail" class="col-sm-2 col-form-label">Email:</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
        </div>
    </div>
    <asp:Button ID="btnAgregar" runat="server" Text="" class="btn btn-primary"/>
    <div class="col-2"></div>


</asp:Content>
