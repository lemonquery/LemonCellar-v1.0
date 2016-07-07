using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Configuration;
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
                lbmaterial.Text = "no se encontro registro, registre un nuevo material";
                txtbuscarm.Text = "";

                
                txtcmn.Visible = true;
                txtcmn.Enabled = true;
                txtcmt.Visible = true;
                txtcmt.Enabled = true;
                txtcmm.Visible = true;
                txtcmm.Enabled = true;
                
                btnmaterialn.Visible = true;

                gvmaterial.DataSource = null;
                gvmaterial.DataBind();
                mm1.Show();
                
            }
            else {
                txtcmn.Visible = false;
                txtcmn.Enabled = false;
                txtcmt.Visible = false;
                txtcmt.Enabled = false;
                txtcmm.Visible = false;
                txtcmm.Enabled = false;
                txtcmc.Visible = false;
                txtcmc.Enabled = false;
                btnmaterialn.Visible = false;
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
                Label mid = (Label)gvmaterial.Rows[e.NewSelectedIndex].FindControl("Label5");
                int cantidadantigua = 0;
                cantidadantigua = Convert.ToInt32(txtcantidadma.Text);
                int cantidadnueva = 0;
                cantidadnueva = Convert.ToInt32(mcantidad.Text);
                int s = 0;
                s = cantidadantigua + cantidadnueva;
                lbid.Text = mid.Text;

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
                lbmaterial.Text = "los datos seran registrados de la siquiente manera";
            }
            
            
        }

        protected void btnconfirmarmaterial_Click(object sender, EventArgs e)
        {

            DateTime fecha = DateTime.Now;
                MATERIAL nuevo = new MATERIAL
                {
                    ID_MATERIAL = Convert.ToInt32(lbid.Text),
                    NOMBRE= txtcmn.Text,
                    TIPO= txtcmt.Text,
                    MEDIDA= txtcmm.Text,
                    CANTIDAD= Convert.ToInt32(txtcmc.Text)

                };
                if (con.Actualizarmaterial(nuevo))
                {
                    
                    MATERIAL_I nuevoi = new MATERIAL_I
                   {
                       ID_MATERIAL = Convert.ToInt32(lbid.Text),
                       FECHA = fecha,
                       VALOR = Convert.ToInt32(txtvalorma.Text),
                       CANTIDAD_IM = Convert.ToInt32(txtcantidadma.Text)

                   };

                    if (con.agregarmaterialI(nuevoi))
                    {
                        txtvalorma.Text = "";
                        txtcantidadma.Text = "";
                        lbmaterial.Text = "compra agregada";
                        gvmaterial.DataBind();
                        mm1.Show();
                    }
                }


                txtcmn.Visible = false;
                txtcmn.Text = "";
                txtcmt.Visible = false;
                txtcmt.Text = "";
                txtcmm.Visible = false;
                txtcmm.Text = "";
                txtcmc.Visible = false;
                txtcmc.Text = "";
                btnconfirmarmaterial.Visible = false;
                gvmaterial.Visible = true;
                
        }

        protected void btnmaterialn_Click(object sender, EventArgs e)
        {
            if (txtcmn.Equals("") || txtcmt.Equals("") || txtcmm.Equals("") )
            {
                lbmaterial.Text = "rellene campos";
            }
            else {
                string nombre = txtcmn.Text;
                string tipo = txtcmt.Text;
                string medida = txtcmm.Text;
                int cantidad = 0;

                MATERIAL nuevo = new MATERIAL
                {
                    NOMBRE = nombre,
                    TIPO = tipo,
                    MEDIDA = medida,
                    CANTIDAD = cantidad,

                };
                if (con.agregarmaterial(nuevo))
                {
                    lbmaterial.Text = "agregado";
                    txtcmn.Visible = false;
                    txtcmn.Text = "";
                    txtcmt.Visible = false;
                    txtcmt.Text = "";
                    txtcmm.Visible = false;
                    txtcmm.Text = "";
                    btnconfirmarmaterial.Visible = false;
                    mm1.Show();
                }

            }
        }

       
        

        
      
        

      
       

       

        

    }
}