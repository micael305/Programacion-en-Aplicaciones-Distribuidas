using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var proxy = new ServiceReference1.WebService1SoapClient();
            String respuesta = proxy.HelloWorld();
            double importe = proxy.pesosADolares(Convert.ToDouble(textBox1.Text));
            MessageBox.Show("Dolares: " + importe);
        }
    }
}

//engloc
//Cliente
//Gridview1.Datasource = proxy.getPrecios();
