using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Collections;
namespace Inicio
{
    public class Global : System.Web.HttpApplication
    {
        ArrayList profesores = new ArrayList();
        ArrayList alumnos = new ArrayList();
        protected void Application_Start(object sender, EventArgs e)
        {
            Application.Contents["numeroProfesores"] = 0;
            Application.Contents["numeroAlumnos"] = 0;
            Application.Contents["profesores"] = new ArrayList();
            Application.Contents["alumnos"] = new ArrayList();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            String tipo = (String)Session.Contents["tipo"];
            String email = (String)Session.Contents["email"];
            
            if (tipo == "Alumno")
            {
                ArrayList alumnos = (ArrayList)Application.Contents["alumnos"];
                alumnos.Remove(email);
                Application.Contents["alumnos"] = alumnos;
                Application.Contents["numeroAlumnos"] = (int)Application.Contents["numeroAlumnos"] - 1;

            }
            else if (tipo == "Profesor")
            {
                ArrayList profesores = (ArrayList)Application.Contents["profesores"];
                profesores.Remove(email);
                Application.Contents["profesores"] = profesores;
                Application.Contents["numeroProfesores"] = (int)Application.Contents["numeroProfesores"] - 1;

            }
            
            
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}