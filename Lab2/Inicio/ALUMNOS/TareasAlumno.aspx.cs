using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inicio
{
    public partial class TareasAlumno : System.Web.UI.Page
    {

        public accesoDatosSQL acceso;
        
        
        protected void Page_Load(object sender, EventArgs e)

        {
            acceso = new accesoDatosSQL();
            acceso.conectar();
            if (!Page.IsPostBack)
            {

                DataSet ds = acceso.asignaturasAlumno((String)Session.Contents["email"]);
                DropDownList1.DataSource = ds.Tables[0];
                DropDownList1.DataTextField = "codigoasig";

                DropDownList1.DataBind();



                    DataView view_tareas = acceso.genericasAlumno((String)Session.Contents["email"]);
                 
                    
                    view_tareas.RowFilter = "codAsig=" + "'" + DropDownList1.SelectedValue + "'";
                    GridView1.DataSource = view_tareas;
                    GridView1.DataBind();

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Clickoooooo");
            Response.Redirect("InstanciarTarea.aspx?cod="+ GridView1.SelectedRow.Cells[1].Text + "&est="+ GridView1.SelectedRow.Cells[3].Text);

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                System.Diagnostics.Debug.WriteLine("CAMBIOOOO");
                DataView view_tareas = acceso.genericasAlumno((String)Session.Contents["email"]);
                view_tareas.RowFilter = "codAsig=" + "'" + DropDownList1.SelectedValue + "'";
                GridView1.DataSource = view_tareas;
                GridView1.DataBind();
            }

        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            acceso.cerrar();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../Inicio.aspx");
        }
    }
}