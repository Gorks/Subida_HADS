using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Inicio.COORDINADOR
{
    public partial class Coordinador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("../Inicio.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //TiempoMedio.TiempoMedio media = new TiempoMedio.TiempoMedio();
                //double tiempo = media.Dedicaciones(DropDownList1.SelectedValue.ToString());
                tmedio.TiempoMedio media = new tmedio.TiempoMedio();
                double tiempo = media.Dedicaciones(DropDownList1.SelectedValue.ToString());
                System.Diagnostics.Debug.WriteLine("COORDINADOR");
                System.Diagnostics.Debug.WriteLine(tiempo.ToString());
                Label2.Text = tiempo.ToString();
            }
            catch(Exception ex)
            {
                Label2.Text=ex.ToString();
            }


        }
    }
}