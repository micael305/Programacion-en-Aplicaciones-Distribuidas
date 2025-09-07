using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Tarea_2___WebApplication.Models;

namespace Tarea_2___WebApplication.Pages
{
    public partial class Pedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductos();
            }
        }

        protected void ButtonBuscarDNI_Click(object sender, EventArgs e)
        {
            var dni = TextBoxDNI.Text;
            if (string.IsNullOrEmpty(dni))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, ingrese un DNI.');", true);
                return;
            }
            var conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Micae\source\repos\PAD\Tarea 2 - WebApplication\Tarea 2 - WebApplication\App_Data\Database1.mdf"";Integrated Security=True");
            string query = "select * from Cliente where DNI = @DNI";
            var comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@DNI", dni);

            try
            {
                conexion.Open();
                var res = comando.ExecuteReader();

                if (res.Read())
                {
                    ActualizarCampos(res);
                    ActivarCargaProdctos();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Cliente no encontrado. Por favor, complete sus datos para registrarse.');", true);
                    ActivarCamposCliente();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error al buscar cliente: {ex.Message}');", true);
            }
            finally
            {
                conexion.Close();
            }
        }


        protected void ButtonRegistrar_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Cliente (DNI, Nombre, Apellido, Email, Direccion, Telefono) VALUES (@DNI, @Nombre, @Apellido, @Email, @Direccion, @Telefono)";
            var conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Micae\source\repos\PAD\Tarea 2 - WebApplication\Tarea 2 - WebApplication\App_Data\Database1.mdf"";Integrated Security=True");
            var comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@DNI", TextBoxDNI.Text);
            comando.Parameters.AddWithValue("@Nombre", TextBoxNombre.Text);
            comando.Parameters.AddWithValue("@Apellido", TextBoxApellido.Text);
            comando.Parameters.AddWithValue("@Email", TextBoxEmail.Text);
            comando.Parameters.AddWithValue("@Direccion", TextBoxDireccion.Text);
            comando.Parameters.AddWithValue("@Telefono", TextBoxTelefono.Text);

            try
            {
                conexion.Open();
                int rowsAffected = comando.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("¡Cliente registrado con éxito!");
                    ActualizarCampos();
                    ActivarCargaProdctos();
                }
                else
                {
                    MessageBox.Show("Error al registrar el cliente. Intente de nuevo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el cliente: {ex.Message}");
            }
            finally
            {
                conexion.Close();
            }
        }

        #region Metodos auxiliares 
        private void ActualizarCampos(SqlDataReader res = null)
        {
            if (res != null)
            {
                TextBoxNombre.Text = res["Nombre"].ToString();
                TextBoxApellido.Text = res["Apellido"].ToString();
                TextBoxEmail.Text = res["Email"].ToString();
                TextBoxTelefono.Text = res["Telefono"].ToString();
                TextBoxDireccion.Text = res["Direccion"].ToString();
            }
            TextBoxDNI.Enabled = false;
            TextBoxNombre.Enabled = false;
            TextBoxApellido.Enabled = false;
            TextBoxEmail.Enabled = false;
            TextBoxTelefono.Enabled = false;
            TextBoxDireccion.Enabled = false;
            ButtonRegistrar.Enabled = false;

        }
        private void ActivarCamposCliente()
        {
            TextBoxNombre.Enabled = true;
            TextBoxApellido.Enabled = true;
            TextBoxEmail.Enabled = true;
            TextBoxTelefono.Enabled = true;
            TextBoxDireccion.Enabled = true;
            ButtonRegistrar.Enabled = true;
        }
        private void ActivarCargaProdctos()
        {
            DropDownListProducto.Enabled = true;
            TextBoxCantidad.Enabled = true;
            ButtonAgregarAlCarrito.Enabled = true;
        }

        #endregion

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int IDProducto = Convert.ToInt32(DropDownListProducto.SelectedValue);

            if (ValidarProducto())
            {
                var conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Micae\source\repos\PAD\Tarea 2 - WebApplication\Tarea 2 - WebApplication\App_Data\Database1.mdf"";Integrated Security=True");
                string query = "select Precio FROM Producto where IDProducto = @IDProducto";
                var comando = new SqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@IDProducto", IDProducto);

                try
                {
                    conexion.Open();

                    var res = comando.ExecuteScalar();

                    if (res != null)
                    {
                        decimal precio = Convert.ToDecimal(res);
                        TextBoxPrecioUnitario.Text = precio.ToString("C");
                        HiddenFieldPrecioUnitario.Value = precio.ToString();
                    }
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error al obtener el precio del producto: {ex.Message}');", true);
                }
                finally
                {
                    conexion.Close();
                }
            }
            else
            {
                TextBoxPrecioUnitario.Text = string.Empty;
            }
        }

        private void CargarProductos()
        {
            var conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Micae\source\repos\PAD\Tarea 2 - WebApplication\Tarea 2 - WebApplication\App_Data\Database1.mdf"";Integrated Security=True");
            string query = "select IDProducto, Nombre from Producto";
            var comando = new SqlCommand(query, conexion);

            try
            {
                conexion.Open();
                var res = comando.ExecuteReader();

                DropDownListProducto.DataSource = res;
                DropDownListProducto.DataTextField = "Nombre";
                DropDownListProducto.DataValueField = "IDProducto";
                DropDownListProducto.DataBind();

                //Agregar un item por defecto
                DropDownListProducto.Items.Insert(0, new ListItem("Seleccione un producto", "0"));
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error al cargar productos: {ex.Message}');", true);
            }
            finally
            {
                conexion.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (!ValidarProducto() || !ValidarCantidad())
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, seleccione un producto y una cantidad (Entre 1 y 100).');", true);
                return;
            }


            //Agregar producto al carrito 
            var itemCarrito = new ItemCarrito
            {
                IDProducto = int.Parse(DropDownListProducto.SelectedValue),
                Nombre = DropDownListProducto.SelectedItem.Text,
                Cantidad = int.Parse(TextBoxCantidad.Text),
                Precio = decimal.Parse(HiddenFieldPrecioUnitario.Value),
            };


            List<ItemCarrito> carrito;
            if (Session["Carrito"] == null)
            {
                carrito = new List<ItemCarrito>();
                Session["Carrito"] = carrito;
            }
            else
            {
                carrito = (List<ItemCarrito>)Session["Carrito"];
            }

            carrito.Add(itemCarrito);

            GridViewProductos.DataSource = carrito;
            GridViewProductos.DataBind();

            LimpiarCamposProducto();
            TextBoxTotal.Text = ((List<ItemCarrito>)Session["Carrito"]).Sum(item => item.Subtotal).ToString();
            ButtonConfirmarPedido.Enabled = true;
        }

        #region metodos auxiliares de Agregar Producto al Carrito
        private bool ValidarProducto()
        {
            // Validar que se haya seleccionado un producto
            int idProducto = 0;
            if (!int.TryParse(DropDownListProducto.SelectedValue, out idProducto) || idProducto == 0)
            {
                return false;
            }

            return true;
        }
        private bool ValidarCantidad()
        {
            // Validar la cantidad ingresada
            int cantidad = 0;
            if (!int.TryParse(TextBoxCantidad.Text, out cantidad) || cantidad <= 0 || cantidad > 100)
            {
                return false;
            }
            return true;
        }
        private void LimpiarCamposProducto()
        {
            DropDownListProducto.SelectedIndex = 0;
            TextBoxCantidad.Text = string.Empty;
            TextBoxPrecioUnitario.Text = string.Empty;
        }

        #endregion

        protected void ButtonConfirmarPedido_Click(object sender, EventArgs e)
        {
            //Pedidos
            var conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Micae\source\repos\PAD\Tarea 2 - WebApplication\Tarea 2 - WebApplication\App_Data\Database1.mdf"";Integrated Security=True");
            SqlTransaction transaction = null;

            try
            {
                conexion.Open();
                transaction = conexion.BeginTransaction();

                string query = "INSERT INTO Pedido (FechaPedido, DNICliente, Total) VALUES (@Fecha, @DNICliente, @Total); SELECT SCOPE_IDENTITY();";
                var comando = new SqlCommand(query, conexion, transaction);
                comando.Parameters.AddWithValue("@Fecha", DateTime.Now);
                comando.Parameters.AddWithValue("@DNICliente", TextBoxDNI.Text);

                decimal total = ((List<ItemCarrito>)Session["Carrito"]).Sum(item => item.Subtotal);
                comando.Parameters.AddWithValue("@Total", total);

                string queryDetalle = "INSERT INTO PedidoProducto (IDPedido, IDProducto, Cantidad, PrecioUnitario) VALUES (@IDPedido, @IDProducto, @Cantidad, @PrecioUnitario)";
                var comandoDetalle = new SqlCommand(queryDetalle, conexion, transaction);

                int idPedido = Convert.ToInt32(comando.ExecuteScalar());

                List<ItemCarrito> carrito = (List<ItemCarrito>)Session["Carrito"];
                foreach (var item in carrito)
                {
                    comandoDetalle.Parameters.Clear();
                    comandoDetalle.Parameters.AddWithValue("@IDPedido", idPedido);
                    comandoDetalle.Parameters.AddWithValue("@IDProducto", item.IDProducto);
                    comandoDetalle.Parameters.AddWithValue("@Cantidad", item.Cantidad);
                    comandoDetalle.Parameters.AddWithValue("@PrecioUnitario", item.Precio);
                    comandoDetalle.ExecuteNonQuery();
                }

                transaction.Commit();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Pedido confirmado con éxito. Su número de pedido es: " + idPedido + "');", true);

                // 4. Limpiar el carrito y la GridView
                Session["Carrito"] = null;
                GridViewProductos.DataSource = null;
                GridViewProductos.DataBind();

                // 4. Limpiar el carrito y la GridView
                Session["Carrito"] = null;
                GridViewProductos.DataSource = null;
                GridViewProductos.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error al confirmar el pedido: {ex.Message}');", true);
            }
            finally
            {
                conexion.Close();
            }
        }


        protected void TextBoxPrecioUnitario_TextChanged(object sender, EventArgs e)
        {
        }


    }
}
