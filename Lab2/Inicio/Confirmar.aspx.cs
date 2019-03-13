using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inicio
{
    public partial class Confirmar : System.Web.UI.Page
    {
        public accesoDatosSQL acceso = new accesoDatosSQL();
        protected void Page_Load(object sender, EventArgs e)
        {
            string resultado = acceso.conectar();
            String link = HttpContext.Current.Request.Url.AbsoluteUri;
            Uri uri = new Uri(link);
            string email = HttpUtility.ParseQueryString(uri.Query).Get("mbr");
            int cod = int.Parse(HttpUtility.ParseQueryString(uri.Query).Get("est"));

            if(acceso.confirmar(email, cod))
            {
                Label1.Visible = false;
            }
            else
            {
                Label2.Visible = false;

            }

        }
        protected void Page_Unload(object sender, EventArgs e)
        {
            acceso.cerrar();
        }
    }
}