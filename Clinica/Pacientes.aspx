<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="Clinica.Pacientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Pacientes</h1>
    <asp:GridView ID="dgvPacientes" runat="server"></asp:GridView>
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" class="btn btn-primary"/>
</asp:Content>
