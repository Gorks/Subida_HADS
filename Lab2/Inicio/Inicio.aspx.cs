using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inicio
{
    public partial class Inicio : System.Web.UI.Page
    {
        public accesoDatosSQL acceso = new accesoDatosSQL();
        protected void Page_Load(object sender, EventArgs e)
        {
          
            string resultado = acceso.conectar();
            Label2.Text = resultado;

    }

        protected void Button1_Click(object sender, EventArgs e)
        {
           if( acceso.login(TextBox1.Text.ToString(), TextBox2.Text.ToString()) != "ERROR"){
                Label3.Text = "Login correcto";
                Label3.Visible = true;
                Session.Contents.Add("email", TextBox1.Text.ToString());
                Session.Contents.Add("tipo", acceso.login(TextBox1.Text.ToString(), TextBox2.Text.ToString()));
                Label3.Text = (String)Session.Contents["tipo"];
                if ((String)Session.Contents["tipo"] == "Alumno")
                {
                    
                    Response.Redirect("ALUMNOS/Alumnos.aspx");
                    
                }
                else if ((String)Session.Contents["tipo"] == "Profesor")
                {
                    Response.Redirect("Profesor/Profesor.aspx");
                }

            }
            else
            {
                Label3.Text = "Login incorrecto";
                Label3.Visible = true;
            }
        }
        protected void Page_Unload(object sender, EventArgs e)
        {
            acceso.cerrar();
        }
    }
}