<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cotizacion.aspx.cs" Inherits="Tarea6___WebApplication.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section id="cotizaciones">
                <h2>Cotizaciones</h2>
                <table class="currency-table">
                    <thead>
                        <tr>
                            <th>Moneda</th>
                            <th>Compra</th>
                            <th>Venta</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr> <td>Dólar Estadounidense (USD)</td> <td class="buy-price">$890.50</td> <td class="sell-price">$930.50</td> </tr>
                        <tr> <td>Euro (EUR)</td> <td class="buy-price">$960.00</td> <td class="sell-price">$1020.00</td> </tr>
                        <tr> <td>Real Brasileño (BRL)</td> <td class="buy-price">$170.00</td> <td class="sell-price">$185.00</td> </tr>
                        <tr> <td>Peso Chileno (CLP)</td> <td class="buy-price">$0.95</td> <td class="sell-price">$1.15</td> </tr>
                        <tr> <td>Libra Esterlina (GBP)</td> <td class="buy-price">$1100.00</td> <td class="sell-price">$1180.00</td> </tr>
                    </tbody>
                </table>
                <div class="table-footer">
                    Última actualización: 17/10/2025 10:14 AM
                </div>
            </section>  
</asp:Content>
