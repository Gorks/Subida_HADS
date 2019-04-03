using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inicio.ALUMNOS
{
    public partial class InstanciarTarea : System.Web.UI.Page
    {
        public accesoDatosSQL acceso;
        DataTable table;
        protected void Page_Load(object sender, EventArgs e)
        {
            acceso = new accesoDatosSQL();
            acceso.conectar();
            
            table = acceso.tareasAlumno((String)Session.Contents["email"]);
            DataView dataview = new DataView(table);
            System.Diagnostics.Debug.WriteLine(dataview);
            GridView1.DataSource = dataview;
            GridView1.DataBind();

            TextBox1.Text= (String)(Session.Contents["email"]);
            String link = HttpContext.Current.Request.Url.AbsoluteUri;
            Uri uri = new Uri(link);
            TextBox2.Text= HttpUtility.ParseQueryString(uri.Query).Get("cod");
            TextBox3.Text = HttpUtility.ParseQueryString(uri.Query).Get("est");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            table = acceso.instanciar(TextBox1.Text, TextBox2.Text, int.Parse(TextBox3.Text), int.Parse(TextBox4.Text), table);
            GridView1.DataBind();
            Button1.Enabled = false;
        }

        protected void Page_Unload(object sender, EventArgs e)
        {

            acceso.cerrar();
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("../Inicio.aspx");
        }
    }
}