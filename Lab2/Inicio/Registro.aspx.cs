using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace Inicio
{
    public partial class Registro : System.Web.UI.Page
    {
        public accesoDatosSQL acceso = new accesoDatosSQL();
        protected void Page_Load(object sender, EventArgs e)
        {
            string resultado = acceso.conectar();
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Correos Cr = new Correos();
                MailMessage mnsj = new MailMessage();
                Random rnd = new Random();
                int cod = rnd.Next(1, 999999999);
                System.Diagnostics.Debug.WriteLine("HA ENTRADO click");

                WebService.Matriculas m = new WebService.Matriculas();
                string respuesta = m.comprobar(TextBox1.Text);

                if(respuesta == "SI")
                {

                    if(acceso.registrar(TextBox1.Text.ToString(), TextBox2.Text.ToString(), TextBox3.Text.ToString(), cod, RadioButtonList1.SelectedValue.ToString(), TextBox4.Text.ToString()))
                    {
                        mnsj.Subject = "Confirmar cuenta";

                        mnsj.To.Add(new MailAddress(TextBox1.Text.ToString()));

                        mnsj.From = new MailAddress("YO@MiDominio.com", "Proyecto Hads");

                        string url = "http://" + HttpContext.Current.Request.Url.Authority + "/";


                        mnsj.Body = "  Confirme su registro " + url + "Confirmar.aspx?mbr=" + TextBox1.Text.ToString() + "&numconf=" + cod.ToString();

                        /* Enviar */
                        Cr.MandarCorreo(mnsj);

                        Label6.Text = "Confirme su cuenta, se le ha enviado un correo";
                        Label6.Visible = true;
                        Button1.Enabled = false;
                    }

                    else
                    {
                        Label6.Text = "El correo ya está registrado";
                        Label6.Visible = true;
                    }
                }

                else
                {
                    Label6.Text = "No es correo VIP";
                    Label6.Visible = true;
                }
                
                


            }
            catch (Exception ex)
            {
                Label6.Text = ex.ToString();
                Label6.Visible = true;
            }
        }
        protected void Page_Unload(object sender, EventArgs e)
        {
            acceso.cerrar();
        }
    }
}