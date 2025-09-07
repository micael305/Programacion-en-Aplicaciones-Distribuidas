using System;

namespace Tarea_2___WebApplication.Pages
{
    public partial class Producto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
