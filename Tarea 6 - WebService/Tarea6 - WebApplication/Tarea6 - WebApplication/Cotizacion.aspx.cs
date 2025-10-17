using System;
using System.Web.UI;

namespace Tarea6___WebApplication
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCotizaciones();
            }
        }

        private void CargarCotizaciones()
        {
            try
            {
                var proxy = new ServiceReference1.BancoOficial_WebServiceSoapClient();

                var tabla = proxy.ObtenerTodasLasCotizaciones();

                gvCotizaciones.DataSource = tabla;
                gvCotizaciones.DataBind();

                lblUltimaActualizacion.Text = "Última actualización: 17 / 10 / 2025 10:14 AM";
            }
            catch (Exception ex)
            {
                lblUltimaActualizacion.Text = "Error al cargar las cotizaciones: " + ex.Message;
            }
        }
    }
}