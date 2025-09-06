<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="MisPedidos.aspx.cs" Inherits="Tarea_2___WebApplication.Pages.MisPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <form id="form1" runat="server">
    <asp:Label ID="LabelDNI" runat="server" Text="Ingresa tu DNI"></asp:Label>
&nbsp;<asp:TextBox ID="TextBoxDNI" runat="server" Enabled="False"></asp:TextBox>
&nbsp;<asp:Button ID="ButtonBuscar" runat="server" OnClick="ButtonBuscar_Click" Text="Buscar pedidos" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Proximamente..."></asp:Label>
</form>
</asp:Content>
