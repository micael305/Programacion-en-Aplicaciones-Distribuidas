<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calculadora.aspx.cs" Inherits="Tarea6___WebApplication.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section id="calculadora">
        <h2>Calculadora de Divisas</h2>
        <div class="converter-container">
            <div class="comprar-divisas">
                <h3>Comprar Divisas</h3>
                <div class="converter-form">
                    <div class="input-group">
                        <label for="amount-ars">Monto en Pesos (ARS)</label>
                        <asp:TextBox ID="txtMontoARS" runat="server" type="number" placeholder="Ej: 50000"></asp:TextBox>
                </div>

                <div class="input-group">
                    <label for="currency-select">Convertir a</label>
                    <asp:DropDownList ID="ddlMonedaDestino" runat="server">
                        <asp:ListItem Text="Dólar Estadounidense (USD)" Value="USD"></asp:ListItem>
                            <asp:ListItem Text="Libra Esterlina (GBP)" Value="GBP"></asp:ListItem>
                            <asp:ListItem Text="Euro (EUR)" Value="EUR"></asp:ListItem>
                            <asp:ListItem Text="Real Brasileño (BRL)" Value="BRL"></asp:ListItem>
                            <asp:ListItem Text="Peso Chileno (CLP)" Value="CLP"></asp:ListItem>
                            <asp:ListItem Text="Peso Uruguayo (UYU)" Value="UYU"></asp:ListItem>
                        </asp:DropDownList>
                        </div>
                        <asp:Button ID="btnConvertir" runat="server" Text="Convertir" OnClick="btnConvertir_Click" />
                    </div>
                    <div id="result-container" class="result-container">
                        <p>
                    <asp:Label ID="lblResultado" runat="server" Text="El resultado aparecerá aquí."></asp:Label>
                </p>
                    </div>
                </div>
                       <div class="vender-divisas">
                           <h3>Vender Divisas</h3>
                           <div class="converter-form">
                               <div class="input-group">
                                   <label for="currency-select">Seleccione una Divisa</label>
                                   <asp:DropDownList ID="DropDownList1" runat="server">
                                       <asp:ListItem Text="Dólar Estadounidense (USD)" Value="USD"></asp:ListItem>
                                       <asp:ListItem Text="Libra Esterlina (GBP)" Value="GBP"></asp:ListItem>
                                       <asp:ListItem Text="Euro (EUR)" Value="EUR"></asp:ListItem>
                                       <asp:ListItem Text="Real Brasileño (BRL)" Value="BRL"></asp:ListItem>
                                       <asp:ListItem Text="Peso Chileno (CLP)" Value="CLP"></asp:ListItem>
                                       <asp:ListItem Text="Peso Uruguayo (UYU)" Value="UYU"></asp:ListItem>
                                   </asp:DropDownList>
                               </div>

                               <div class="input-group">
                                   <label for="amount-ars">Ingrese un Monto</label>
                                   <asp:TextBox ID="TextBox1" runat="server" type="number" placeholder="Ej: 50000"></asp:TextBox>
                               </div>
                               <asp:Button ID="Button1" runat="server" Text="Convertir" OnClick="btnConvertir_Click" />
                           </div>
                           <div id="result-container" class="result-container">
                               <p>
                                   <asp:Label ID="Label1" runat="server" Text="El resultado aparecerá aquí."></asp:Label>
                               </p>
                           </div>
                       </div>
                </div>
            </section>
</asp:Content>
