<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="MisPedidos.aspx.cs" Inherits="Tarea_2___WebApplication.Pages.MisPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <form id="form1" runat="server">
    <asp:Label ID="LabelDNI" runat="server" Text="Ingresa tu DNI"></asp:Label>
&nbsp;<asp:TextBox ID="TextBoxDNI" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="ButtonBuscar" runat="server" OnClick="ButtonBuscar_Click" Text="Buscar pedidos" />
        <br />
        <br />
        <asp:GridView ID="GridViewPedidos" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="false" OnRowCommand="GridViewPedidos_RowCommand">
             <Columns>
            <asp:BoundField DataField="IDPedido" HeaderText="ID Pedido" SortExpression="IDPedido" />
            <asp:BoundField DataField="FechaPedido" HeaderText="Fecha" DataFormatString="{0:d}" SortExpression="FechaPedido" />
            <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:C}" SortExpression="Total" />
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButtonVerDetalle" runat="server" Text="Ver Detalle" CommandName="VerDetalle" CommandArgument='<%# Eval("IDPedido") %>' CssClass="btn btn-sm btn-info" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
        <div class="mt-4">
    <h4>Productos del Pedido</h4>
    <asp:GridView ID="GridViewDetallePedido" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="true">
    </asp:GridView>
</div>
</form>
</asp:Content>
