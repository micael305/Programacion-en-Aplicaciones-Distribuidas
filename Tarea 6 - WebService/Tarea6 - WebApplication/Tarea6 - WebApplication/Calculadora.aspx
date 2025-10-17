<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calculadora.aspx.cs" Inherits="Tarea6___WebApplication.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section id="calculadora">
                <div class="converter-container">
                    <h2>Calculadora de Divisas</h2>
                    <div class="converter-form">
                        <div class="input-group">
                            <label for="amount-ars">Monto en Pesos (ARS)</label>
                            <input type="number" id="amount-ars" placeholder="Ej: 50000">
                        </div>
                        <div class="input-group">
                            <label for="currency-select">Convertir a</label>
                            <select id="currency-select">
                                <option value="930.50">Dólar Estadounidense (USD)</option>
                                <option value="1020.00">Euro (EUR)</option>
                                <option value="185.00">Real Brasileño (BRL)</option>
                                <option value="1.15">Peso Chileno (CLP)</option>
                                <option value="1180.00">Libra Esterlina (GBP)</option>
                            </select>
                        </div>
                        <button id="convert-btn">Convertir</button>
                    </div>
                    <div id="result-container" class="result-container">
                        <p id="conversion-result">El resultado aparecerá aquí.</p>
                    </div>
                </div>
            </section>
</asp:Content>
