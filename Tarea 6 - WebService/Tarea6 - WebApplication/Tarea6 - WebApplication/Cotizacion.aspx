<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cotizacion.aspx.cs" Inherits="Tarea6___WebApplication.About" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section id="cotizaciones">
        <h2>Cotizaciones</h2>

        <asp:GridView ID="gvCotizaciones" runat="server"
            CssClass="currency-table"
            AutoGenerateColumns="False"
            GridLines="None">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Moneda" />
                <asp:BoundField DataField="Compra" HeaderText="Compra" DataFormatString="{0:C2}" ItemStyle-CssClass="buy-price" />
                <asp:BoundField DataField="Venta" HeaderText="Venta" DataFormatString="{0:C2}" ItemStyle-CssClass="sell-price" />
            </Columns>
        </asp:GridView>

        <div class="table-footer">
            <asp:Label ID="lblUltimaActualizacion" runat="server"></asp:Label>
        </div>
    </section>
</asp:Content>