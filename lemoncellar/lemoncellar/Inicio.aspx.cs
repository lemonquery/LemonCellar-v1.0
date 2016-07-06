using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using lemoncellar.controlador;
using lemoncellar.modelo;

namespace lemoncellar
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        controlbuscar con = new controlbuscar();
        controlvistas cov = new controlvistas();
        lemoncellarEntities contexto = new lemoncellarEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvherramientas.DataSource = cov.listaherramienta();
                gvherramientas.DataBind();
            }
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
                txtvalorma.Visible = false;
                txtcantidadma.Visible = false;
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
                txtvalorma.Visible = true;
                txtcantidadma.Visible = true;
            }
        }

        protected void btnagregarh_Click(object sender, EventArgs e)
        {
            string nombre = "";
            string detalle = "";
            int valor = 0;
            string estado = "";
            DateTime fecha = DateTime.Today;

            nombre = txthnombre.Text;
            detalle = txthdetalle.Text;
            valor = Convert.ToInt32(txthvalor.Text);
            estado = ddhestado.SelectedValue;

            if (nombre.Equals("") || detalle.Equals("") ||  valor == 0)
            {
                lbagregado.Text = "rellene campos";
            }
            else {
                
                HERRAMIENTA nuevo = new HERRAMIENTA
                {
                    NOMBRE = nombre,
                    DETALLE = detalle,
                    VALOR = valor,
                    FECHA = fecha,
                    ESTADO = estado,

                };

                if (con.agregarherramienta(nuevo))
                {
                    lbagregado.Text = "agregado";
                    gvherramientas.DataBind();
                    txthnombre.Text = "";
                    txthdetalle.Text = "";
                    txthvalor.Text = "";
                }
            }
             

        }

        protected void gvmaterial_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            if (txtvalorma.Text.Equals("") || txtcantidadma.Text.Equals(""))
            {
                lbmaterial.Text = "rellene campos";
                mm1.Show();
            }
            else {
                Label mnombre = (Label)gvmaterial.Rows[e.NewSelectedIndex].FindControl("Label1");
                Label mtipo = (Label)gvmaterial.Rows[e.NewSelectedIndex].FindControl("Label2");
                Label mmedida = (Label)gvmaterial.Rows[e.NewSelectedIndex].FindControl("Label3");
                Label mcantidad = (Label)gvmaterial.Rows[e.NewSelectedIndex].FindControl("Label4");
                int cantidadantigua = 0;
                cantidadantigua = Convert.ToInt32(txtcantidadma.Text);
                int cantidadnueva = 0;
                cantidadnueva = Convert.ToInt32(mcantidad.Text);
                int s = 0;
                s = cantidadantigua + cantidadnueva;

                txtcantidadma.Visible = false;
                txtvalorma.Visible = false;
                gvmaterial.Visible = false;

                txtcmn.Visible = true;
                txtcmt.Visible = true;
                txtcmm.Visible = true;
                txtcmc.Visible = true;
                btnconfirmarmaterial.Visible = true;

                txtcmn.Text = mnombre.Text;
                txtcmt.Text = mtipo.Text;
                txtcmm.Text = mmedida.Text;
                txtcmc.Text = s.ToString();
                mm1.Show();
            }
            
            
        }

        protected void btnconfirmarmaterial_Click(object sender, EventArgs e)
        {

            
                MATERIAL nuevo = new MATERIAL
                {
                    NOMBRE= txtcmn.Text,
                    TIPO= txtcmt.Text,
                    MEDIDA= txtcmm.Text,
                    CANTIDAD= Convert.ToInt32(txtcmc.Text)

                };
                if (con.Actualizarmaterial(nuevo))
                {
                    txtvalorma.Text = "";
                    txtcantidadma.Text = "";
                    gvmaterial.DataSource = null;
                    gvmaterial.DataBind();
                    mm1.Show();
                }


                txtcmn.Visible = false;
                txtcmt.Visible = false;
                txtcmm.Visible = false;
                txtcmc.Visible = false;
                btnconfirmarmaterial.Visible = false;
                gvmaterial.Visible = true;
                
        }

        

      
       

       

        

    }
}