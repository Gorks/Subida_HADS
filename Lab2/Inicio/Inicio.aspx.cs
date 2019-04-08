using System;
using System.Collections;
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


            if ( acceso.login(TextBox1.Text.ToString(), TextBox2.Text.ToString()) != "ERROR"){
                Label3.Text = "Login correcto";
                Label3.Visible = true;
                Session.Contents.Add("email", TextBox1.Text.ToString());
                Session.Contents.Add("tipo", acceso.login(TextBox1.Text.ToString(), TextBox2.Text.ToString()));
                Label3.Text = (String)Session.Contents["tipo"];
                if ((String)Session.Contents["tipo"] == "Alumno")
                {
                    ((ArrayList)Application.Contents["alumnos"]).Add(TextBox1.Text.ToString());
                    System.Web.Security.FormsAuthentication.SetAuthCookie("alumno", false);
                    Application.Contents["numeroAlumnos"] = (int)Application.Contents["numeroAlumnos"] + 1;
                    Response.Redirect("ALUMNOS/Alumnos.aspx");

                    
                }
                else if ((String)Session.Contents["tipo"] == "Profesor") 

                {
                    if(TextBox1.Text.ToString() == "vadillo@ehu.es")
                    {
                        System.Web.Security.FormsAuthentication.SetAuthCookie("especial", false);
                    }
                    else
                    {
                        System.Web.Security.FormsAuthentication.SetAuthCookie("profesor", false);
                    }
                    ((ArrayList)Application.Contents["profesores"]).Add(TextBox1.Text.ToString());
                    Application.Contents["numeroProfesores"] = (int)Application.Contents["numeroProfesores"] + 1;
                    Response.Redirect("Profesor/Profesor.aspx");
                }

                else if ((String)Session.Contents["tipo"] == "Admin")
                {
                    System.Web.Security.FormsAuthentication.SetAuthCookie("admin", false);
                    Response.Redirect("ADMIN/Admin.aspx");
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