using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inicio
{
    public partial class CambiarContrasena : System.Web.UI.Page
    {
        public accesoDatosSQL acceso = new accesoDatosSQL();
        protected void Page_Load(object sender, EventArgs e)
        {
            string resultado = acceso.conectar();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            
            try
            {
                
                Correos Cr = new Correos();
                MailMessage mnsj = new MailMessage();
                Random rnd = new Random();
                int cod = rnd.Next(1, 9999);

                if(acceso.solicitud_cambio(TextBox1.Text.ToString(), cod))
                {
                    mnsj.Subject = "Código cambio contraseña";

                    mnsj.To.Add(new MailAddress(TextBox1.Text.ToString()));

                    mnsj.From = new MailAddress("YO@MiDominio.com", "Proyecto Hads");



                    mnsj.Body = "  Su código es el siguiente " + cod.ToString();

                    /* Enviar */
                    Cr.MandarCorreo(mnsj);
                    Label5.Text = "Se le ha enviado un mail con su codigo para cambiar";
                    Label5.Visible = true;
                    segunda_parte.Visible = true;
                    Button1.Enabled = false;
                    TextBox1.Enabled = false;

                }
                else
                {
                    Label5.Visible = true;
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (acceso.realizar_cambio(TextBox1.Text.ToString(), int.Parse( TextBox4.Text.ToString()), TextBox2.Text.ToString()))
            {
                Label6.Visible = true;
                Button2.Enabled = false;
            }
            else
            {
                Label6.Text = "ERROR";
                Label6.Visible = true;
            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            acceso.cerrar();
        }
    }
}