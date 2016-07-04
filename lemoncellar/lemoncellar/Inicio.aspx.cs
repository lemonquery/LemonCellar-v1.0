using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using lemoncellar.controlador;

namespace lemoncellar
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        controlbuscar con = new controlbuscar();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btncerrar_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
        }

        protected void bbuscarmaterial_Click(object sender, EventArgs e)
        {
            string buscar = "";
            buscar = txtbuscarm.Text;
            int aux = con.buscarmaterial(buscar).Count;
            if (aux == 0)
            {
                lbmaterial.Text = "no se encontro nada";
                txtbuscarm.Text = "";
                gvmaterial.DataSource = null;
                gvmaterial.DataBind();
                mm1.Show();
            }
            else {
                lbmaterial.Text = "";
                txtbuscarm.Text = "";
                gvmaterial.DataSource = con.buscarmaterial(buscar);
                gvmaterial.DataBind();
                txtbuscarm.Text = "";
                mm1.Show();
            }
        }

        protected void gvmaterial_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Label lbnom = (Label)gvmaterial.Rows[e.NewSelectedIndex].FindControl("Label1");
            Label lbti = (Label)gvmaterial.Rows[e.NewSelectedIndex].FindControl("Label2");
            Label lbme = (Label)gvmaterial.Rows[e.NewSelectedIndex].FindControl("Label3");
            Label lbca = (Label)gvmaterial.Rows[e.NewSelectedIndex].FindControl("Label4");

            lbmanombre.Text = lbnom.Text;
            lbmatipo.Text = lbti.Text;
            lbmamedida.Text = lbme.Text;
            lbmacantidad.Text = lbca.Text;


            mpam.Show();
        }

    }
}