<%@ Page Title="Agregar o Modificar Turno" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarTurno.aspx.cs" Inherits="Clinica.AgregarTurno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% if (Session["Turno"] == null)
        {%>
    <h1>Agregar nuevo Turno</h1>
    <% }
        else
        {%>
    <h1>Modificar Turno</h1>
    <% } %>



</asp:Content>
