using System;
using System.Web.UI;

namespace Tarea6___WebApplication
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConvertir_Click(object sender, EventArgs e)
        {

            if (decimal.TryParse(txtMontoARS.Text, out decimal montoEnPesos))
            {
                try
                {
                    string monedaDestino = ddlMonedaDestino.SelectedValue;

                    //proxy seria el intermediario entre la app y el web service
                    var proxy = new ServiceReference1.BancoOficial_WebServiceSoapClient();

                    decimal resultado = proxy.convertirPesosA(montoEnPesos, monedaDestino);

                    if (resultado > 0)
                    {
                        lblResultado.Text = $"El monto es {resultado:N2} {monedaDestino}";
                    }
                    else
                    {
                        lblResultado.Text = "No se pudo realizar la conversión. Verifique la moneda.";
                    }
                }
                catch (Exception ex)
                {
                    lblResultado.Text = "Error al conectar con el servicio: " + ex.Message;
                }
            }
            else
            {
                lblResultado.Text = "Por favor, ingrese un monto válido.";
            }
        }
    }
}