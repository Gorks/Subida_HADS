using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Inicio.PROFESOR
{
    public partial class Importar : System.Web.UI.Page
    {
        public accesoDatosSQL acceso;
        XmlDocument documento = new XmlDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            acceso = new accesoDatosSQL();
            acceso.conectar();
            Button1.Enabled = false;

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                documento.Load(Server.MapPath("../App_Data/" + DropDownList1.SelectedValue + ".xml"));
                Xml1.DocumentSource = Server.MapPath("../App_Data/" + DropDownList1.SelectedValue + ".xml");
                Xml1.TransformSource = Server.MapPath("../App_Data/XSLTFile.xsl");
                Button1.Enabled = true;
                

            }
            catch(Exception ex)
            {
                Label2.Visible = true;
                Label2.Text = ex.Message;
                Button1.Enabled = false;

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {



            //Cargar datos en el documento


            try
            {
                acceso.importarXML(documento, DropDownList1.SelectedValue);
                Label2.Text = "Se ha importado el documento " + DropDownList1.SelectedValue + ".xml";
                Label2.Visible = true;
            }
            catch(Exception ex)
            {
                Label2.Text = ex.Message;
                Label2.Visible = true;
            }
            


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("../Inicio.aspx");
        }
    }
}