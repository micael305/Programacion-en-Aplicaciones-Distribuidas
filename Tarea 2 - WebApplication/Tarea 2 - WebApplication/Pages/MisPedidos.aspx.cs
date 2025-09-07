using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Tarea_2___WebApplication.Pages
{
    public partial class MisPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            string dni = TextBoxDNI.Text;

            if (string.IsNullOrEmpty(dni))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, ingrese un DNI.');", true);
                return;
            }

            var conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Micae\source\repos\PAD\Tarea 2 - WebApplication\Tarea 2 - WebApplication\App_Data\Database1.mdf"";Integrated Security=True");
            string query = "SELECT IDPedido, FechaPedido, Total FROM Pedido WHERE DNICliente = @DNICliente";

            var comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@DNICliente", dni);

            try
            {
                conexion.Open();
                var dataAdapter = new SqlDataAdapter(comando);
                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    GridViewPedidos.DataSource = dataTable;
                    GridViewPedidos.DataBind();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se encontraron pedidos para este cliente.');", true);
                    GridViewPedidos.DataSource = null;
                    GridViewPedidos.DataBind();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error al buscar pedidos: {ex.Message}');", true);
            }
            finally
            {
                conexion.Close();
            }
        }
        protected void GridViewPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerDetalle")
            {
                int idPedido = Convert.ToInt32(e.CommandArgument);

                var conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Micae\source\repos\PAD\Tarea 2 - WebApplication\Tarea 2 - WebApplication\App_Data\Database1.mdf"";Integrated Security=True");

                string query = "SELECT pp.IDProducto, p.Nombre AS NombreProducto, pp.Cantidad, pp.PrecioUnitario " +
                               "FROM PedidoProducto pp " +
                               "INNER JOIN Producto p ON pp.IDProducto = p.IDProducto " +
                               "WHERE pp.IDPedido = @IDPedido";

                var comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@IDPedido", idPedido);

                try
                {
                    conexion.Open();
                    var dataAdapter = new SqlDataAdapter(comando);
                    var dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    GridViewDetallePedido.DataSource = dataTable;
                    GridViewDetallePedido.DataBind();
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error al ver los detalles del pedido: {ex.Message}');", true);
                }
                finally
                {
                    conexion.Close();
                }
            }

        }
    }
}