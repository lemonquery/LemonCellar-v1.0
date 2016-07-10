using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using lemoncellar.controlador;
using System.Web.Security;
using System.Configuration;

namespace lemoncellar
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        controladorusuario CU = new controladorusuario();
        controlvistas CV = new controlvistas();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvmaterial.DataSource = CV.listamaterial();
                gvmaterial.DataBind();
                //gvherramientas.DataSource = CV.listaherramienta();
                //gvherramientas.DataBind();
                gvconsumible.DataSource = CV.listaconsumible();
                gvconsumible.DataBind();
            }
        }

        protected void btningrasar_Click(object sender, EventArgs e)
        {
            
            string estado_usuario = "";
            if (IsValid)
            {
                if (CU.validarusuario(txtusuario.Text, txtclave.Text, ref estado_usuario))
                {
                    string datoUsuario = txtusuario.Text;
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                        txtusuario.Text,
                        DateTime.Now,
                        DateTime.Now.AddSeconds(6000),
                        false,
                        datoUsuario,
                        FormsAuthentication.FormsCookiePath
                        );
                    string encTicket = FormsAuthentication.Encrypt(ticket);
                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                    Session["IDestado"] = estado_usuario;
                    Session["IDusuario"] = txtusuario.Text;

                    Response.Redirect("Inicio.aspx");
                }
                else {
                    btningrasar.CssClass = "btn btn-danger";
                    btningrasar.Text = "error";
                }
            }
        }

        protected void btnvolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            
        }

        protected void gvmaterial_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvmaterial.PageIndex = e.NewPageIndex;
            gvmaterial.DataSource = CV.listamaterial();
            gvmaterial.DataBind();
            mpmaterial.Show();
        }

        protected void gvherramientas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //gvherramientas.PageIndex = e.NewPageIndex;
            //gvherramientas.DataSource = CV.listaherramienta();
            //gvherramientas.DataBind();
            //mpherramienta.Show();
        }

        

        protected void gvconsumible_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvconsumible.PageIndex = e.NewPageIndex;
            gvconsumible.DataSource = CV.listaconsumible();
            gvconsumible.DataBind();
            mpconsumible.Show();
        }

       

        
    }
}