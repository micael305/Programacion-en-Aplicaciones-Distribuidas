using System.Web.Services;
using WebApplication3.DataSet1TableAdapters;
using static WebApplication3.DataSet1;

namespace WebApplication3
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    //https://localhost:44397/WebService1.asmx?wsdl
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public double pesosADolares(double montoEnPesos)
        {
            double montoEnDolares = montoEnPesos / 1500;
            return montoEnDolares;
        }
        [WebMethod]
        public PRECIOSDataTable getPrecios()
        {
            var adaptador = new PRECIOSTableAdapter();
            //adapter.Insert(4, "nuevo", 1000);
            DataSet1.PRECIOSDataTable tabla = adaptador.GetData(); //toda la info de las filas de PRECIO
            return tabla;
            ;
        }


        //public string getPrecios()
        //{
        //    var adaptador = new PRECIOSTableAdapter();
        //    //adapter.Insert(4, "nuevo", 1000);
        //    DataSet1.PRECIOSDataTable tabla = adaptador.GetData(); //toda la info de las filas de PRECIO
        //    return tabla.Rows[0][2].ToString();

    }
}
