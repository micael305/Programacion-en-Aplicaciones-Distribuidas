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
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod]
        public decimal pesosALibraEsterlina(decimal montoEnPesos)
        {
            var adaptador = new CotizacionTableAdapter();
            CotizacionDataTable tabla = adaptador.GetData();
            var libraRow = tabla.FirstOrDefault(row => row.Moneda.Equals("GBP"));
            if (libraRow != null)
            {
                decimal precioVentaLibra = libraRow.Venta;

                if (precioVentaLibra > 0)
                {
                    return montoEnPesos / precioVentaLibra;
                }
            }
            return 0;
        }
    }
}
