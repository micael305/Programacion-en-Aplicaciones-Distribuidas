using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Tarea_2___WebApplication.Pages
{
    public partial class Producto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //    var conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Micae\source\repos\PAD\Tarea 2 - WebApplication\Tarea 2 - WebApplication\App_Data\Database1.mdf"";Integrated Security=True");
            //    var comando = new SqlCommand("select * from Producto", conexion);
            //    conexion.Open();
            //    var res = comando.ExecuteReader(); //ya que nos devolverá filas

            //    while (res.Read())
            //    {
            //        Response.Write("<br>" + res["Nombre"]);
            //    }
            //    conexion.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlDataSource1.SelectParameters.Clear();
            if (!string.IsNullOrEmpty(TextBox1.Text))
            {
                SqlDataSource1.SelectCommand = "SELECT * FROM Producto WHERE Nombre LIKE @Nombre";
                SqlDataSource1.SelectParameters.Add("Nombre", "%" + TextBox1.Text + "%");
            }
            else
            {
                SqlDataSource1.SelectCommand = "SELECT * FROM Producto";
            }
            GridView1.DataBind(); //Enlazar datos al GrindView
        }
    }
}
