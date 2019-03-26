using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Inicio.PROFESOR
{
    public partial class Exportar : System.Web.UI.Page
    {
        DataTable tabla_tareas;
        public accesoDatosSQL acceso;
        protected void Page_Load(object sender, EventArgs e)
        {
            acceso = new accesoDatosSQL();
            acceso.conectar();
            Button1.Enabled = false;
            Label3.Visible = false;
            



        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet tareas = acceso.tareas_asignatura(DropDownList1.SelectedValue);
                tabla_tareas = tareas.Tables["tarea"];


                GridView1.DataSource = tabla_tareas;
                GridView1.DataBind();
                Button1.Enabled = true;
            }
               catch(Exception ex)
            {
                Label3.Text = ex.Message;
                Label3.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           

            DataSet tareas = acceso.tareas_asignatura(DropDownList1.SelectedValue);
            tabla_tareas = tareas.Tables["tarea"];
            XmlDocument documento = new XmlDocument();




            //Que la columna codigo sea de tipo attribute
            DataColumn datacolumn = tabla_tareas.Columns[0];
            datacolumn.ColumnMapping = MappingType.Attribute;

            

            tabla_tareas.Columns[0].ColumnName = "codigo";
            tabla_tareas.Columns[1].ColumnName = "descripcion";
            tabla_tareas.Columns[2].ColumnName = "hestimadas";
            tabla_tareas.Columns[3].ColumnName = "explotacion";
            tabla_tareas.Columns[4].ColumnName = "tipotarea";



            tabla_tareas.WriteXml(Server.MapPath("../App_Data/" +DropDownList1.SelectedValue + ".xml"));
            
            documento.Load(Server.MapPath("../App_Data/" + DropDownList1.SelectedValue + ".xml"));



            documento.DocumentElement.SetAttribute("xmlns:has", "htt://ji.ehu.es/has");

            //guardar documento
            documento.Save(Server.MapPath("../App_Data/" + DropDownList1.SelectedValue + ".xml"));

            Button1.Enabled = false;

            Label3.Text = "Se ha exportado " + DropDownList1.SelectedValue + ".xml";
            Label3.Visible = true;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../Inicio.aspx");
        }
    }
}