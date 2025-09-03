using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Tarea_2___WebApplication.Pages
{
    public partial class Pedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonBuscarDNI_Click(object sender, EventArgs e)
        {
            var dni = TextBoxDNI.Text;
            if (string.IsNullOrEmpty(dni))
            {
                MessageBox.Show("Por favor, ingrese un DNI.");
                return;
            }
            var conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Micae\source\repos\PAD\Tarea 2 - WebApplication\Tarea 2 - WebApplication\App_Data\Database1.mdf"";Integrated Security=True");
            var comando = new SqlCommand("select * from Cliente where DNI = @DNI", conexion);

            comando.Parameters.AddWithValue("@DNI", dni);

            conexion.Open();
            var res = comando.ExecuteReader();

            if (res.Read())
            {
                TextBoxNombre.Text = res["Nombre"].ToString();
                TextBoxApellido.Text = res["Apellido"].ToString();
                TextBoxEmail.Text = res["Email"].ToString();
                TextBoxTelefono.Text = res["Telefono"].ToString();
                TextBoxDireccion.Text = res["Direccion"].ToString();
                MessageBox.Show("Usuario encontrado.");
            }
            else
            {
                MessageBox.Show("No se encontraron clientes con ese DNI.");
            }
            conexion.Close();

        }
    }
}