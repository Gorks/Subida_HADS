using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inicio
{
    public partial class Alumnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelProfesores.Text = Convert.ToString(Application.Contents["numeroProfesores"]);
            LabelAlumnos.Text = Convert.ToString(Application.Contents["numeroAlumnos"]);
            ArrayList profesores = (ArrayList)Application.Contents["profesores"];
            ListBoxProfesores.Items.Clear();
            ListBoxProfesores.DataSource = profesores;
            ListBoxProfesores.DataBind();

            ArrayList alumnos = (ArrayList)Application.Contents["alumnos"];
            ListBoxAlumnos.Items.Clear();
            ListBoxAlumnos.DataSource = alumnos;
            ListBoxAlumnos.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("../Inicio.aspx");
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}