using System.Linq;
using System.Web.Services;
using Tarea_6___WebApplication__Web_Service_.DataSet1TableAdapters;
using static Tarea_6___WebApplication__Web_Service_.DataSet1;

namespace Tarea_6___WebApplication__Web_Service_
{
    /// <summary>
    /// Descripción breve de BancoOficial_WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class BancoOficial_WebService : System.Web.Services.WebService
    {
        [WebMethod]
        public decimal convertirPesosA(decimal montoEnPesos, string monedaDestino)
        {
            if (string.IsNullOrEmpty(monedaDestino))
            {
                return 0;
            }

            var adaptador = new CotizacionTableAdapter();
            CotizacionDataTable tabla = adaptador.GetData();

            var cotizacionRow = tabla.FirstOrDefault(row => row.Moneda.Equals(monedaDestino.ToUpper()));

            if (cotizacionRow != null)
            {
                decimal precioVenta = cotizacionRow.Venta;

                if (precioVenta > 0)
                {
                    return montoEnPesos / precioVenta;
                }
            }
            return 0;
        }
        //obtener todas las filas de mi tabla cotizacion
        [WebMethod]
        public CotizacionDataTable ObtenerTodasLasCotizaciones()
        {
            var adaptador = new CotizacionTableAdapter();
            CotizacionDataTable tabla = adaptador.GetData();
            return tabla;
        }
    }
}
