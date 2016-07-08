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
        //material
        protected void bbuscarmaterial_Click(object sender, EventArgs e)
        {
            string buscar = "";
            buscar = txtbuscarm.Text;
            int aux = con.buscarmaterial(buscar).Count;
            if (aux == 0)
            {
                txtcmv.Visible = false;
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
                gvmaterial.Visible = true;
                txtcmn.Visible = false;
                txtcmn.Enabled = false;
                txtcmt.Visible = false;
                txtcmt.Enabled = false;
                txtcmm.Visible = false;
                txtcmm.Enabled = false;
                txtcmc.Visible = false;
                txtcmv.Visible = false;
                txtcmr.Visible = false;
                txtcmd.Visible = false;
                btnmaterialn.Visible = false;
                btnconfirmarmaterial.Visible = false;
                btnconfirmarmaterialp.Visible = false;
                lbmaterial.Text = "";
                gvmaterial.DataSource = con.buscarmaterial(buscar);
                gvmaterial.DataBind();
                mm1.Show();
                
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
        protected void gvmaterial_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvmaterial.PageIndex = e.NewPageIndex;
            string buscar = "";
            buscar = txtbuscarm.Text;
            int aux = con.buscarmaterial(buscar).Count;
            if (aux == 0)
            {

            }
            else {
                gvmaterial.DataSource = con.buscarmaterial(buscar);
                gvmaterial.DataBind();
               
            }
            mm1.Show();
        }        
        protected void gvmaterial_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            Label mnombre = (Label)gvmaterial.Rows[e.RowIndex].FindControl("Label1");
            Label mtipo = (Label)gvmaterial.Rows[e.RowIndex].FindControl("Label2");
            Label mmedida = (Label)gvmaterial.Rows[e.RowIndex].FindControl("Label3");
            Label mcantidad = (Label)gvmaterial.Rows[e.RowIndex].FindControl("Label4");
            Label mid = (Label)gvmaterial.Rows[e.RowIndex].FindControl("Label5");
            lbmaterial.Text = "el siguiente material asignado";
            txtcmv.Visible = false;
            txtcmn.Visible = true;
            txtcmn.Text = mnombre.Text;
            txtcmt.Visible = true;
            txtcmt.Text = mtipo.Text;
            txtcmm.Visible = true;
            txtcmm.Text = mmedida.Text;
            txtcmc.Visible = true;
            txtcmr.Visible = true;
            txtcmd.Visible = true;
            lbid2.Text = mid.Text;
            lbcantidadp.Text = mcantidad.Text;
            btnconfirmarmaterialp.Visible = true;
            gvmaterial.Visible = false;
            mm1.Show();
        }
        protected void gvmaterial_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            Label mnombre = (Label)gvmaterial.Rows[e.NewSelectedIndex].FindControl("Label1");
            Label mtipo = (Label)gvmaterial.Rows[e.NewSelectedIndex].FindControl("Label2");
            Label mmedida = (Label)gvmaterial.Rows[e.NewSelectedIndex].FindControl("Label3");
            Label mcantidad = (Label)gvmaterial.Rows[e.NewSelectedIndex].FindControl("Label4");
            Label mid = (Label)gvmaterial.Rows[e.NewSelectedIndex].FindControl("Label5");


            gvmaterial.Visible = false;

            txtcmn.Visible = true;
            txtcmt.Visible = true;
            txtcmm.Visible = true;
            txtcmc.Visible = true;
            txtcmv.Visible = true;
            btnconfirmarmaterial.Visible = true;

            txtcmn.Text = mnombre.Text;
            txtcmt.Text = mtipo.Text;
            txtcmm.Text = mmedida.Text;
            lbcantidad.Text = mcantidad.Text;
            lbid.Text = mid.Text;
            mm1.Show();
            lbmaterial.Text = "se registrara la sigueinte compra";



        }              
        protected void btnconfirmarmaterial_Click(object sender, EventArgs e)
        {

            if (txtcmc.Text.Equals("") || txtcmv.Text.Equals(""))
            {
                lbmaterial.Text = "rellene campos";
                mm1.Show();
            }
            else
            {
                int canta = Convert.ToInt32(lbcantidad.Text);
                int cantn = Convert.ToInt32(txtcmc.Text);
                int valor = Convert.ToInt32(txtcmv.Text);
                int s = canta + cantn;
                DateTime fecha = DateTime.Now;
                MATERIAL nuevo = new MATERIAL
                {
                    ID_MATERIAL = Convert.ToInt32(lbid.Text),
                    NOMBRE = txtcmn.Text,
                    TIPO = txtcmt.Text,
                    MEDIDA = txtcmm.Text,
                    CANTIDAD = s

                };
                if (con.Actualizarmaterial(nuevo))
                {

                    MATERIAL_I nuevoi = new MATERIAL_I
                    {
                        ID_MATERIAL = Convert.ToInt32(lbid.Text),
                        FECHA = fecha,
                        VALOR = valor,
                        CANTIDAD_IM = cantn

                    };

                    if (con.agregarmaterialI(nuevoi))
                    {

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
                txtcmv.Visible = false;
                txtcmv.Text = "";
                btnconfirmarmaterial.Visible = false;
                gvmaterial.Visible = true;
            }

        }
        protected void btnconfirmarmaterialp_Click(object sender, EventArgs e)
        {
            if (txtcmr.Text.Equals("") || txtcmd.Text.Equals(""))
            {
                lbmaterial.Text = "rellene los campos";
                mm1.Show();
            }
            else {
                string mnombre = txtcmn.Text;
                string mtipo = txtcmt.Text;
                string mmedida = txtcmm.Text;
                int mid = Convert.ToInt32(lbid2.Text);
                int mcana = Convert.ToInt32(lbcantidadp.Text);
                DateTime fecha = DateTime.Now;
                int mcann = Convert.ToInt32(txtcmc.Text);
                string mrespons = txtcmr.Text;
                string mdetalle = txtcmd.Text;
                int ns = mcana - mcann;
                if (ns >= 0)
                {
                    MATERIAL nuevo = new MATERIAL
                    {
                        ID_MATERIAL = mid,
                        NOMBRE = mnombre,
                        TIPO = mtipo,
                        MEDIDA = mmedida,
                        CANTIDAD = ns
                    };
                    if (con.Actualizarmaterial(nuevo))
                    {
                        MATERIAL_S nuevos = new MATERIAL_S
                        {
                            ID_MATERIAL=mid,
                            FECHA = fecha,
                            OPERADOR = mrespons,
                            CANTIDAD_SM = mcann,
                            DETALLE = mdetalle
                        };
                        if (con.agregarmaterialS(nuevos))
                        {
                            lbmaterial.Text = "material prestado correctamente";
                            txtcmn.Visible = false;
                            txtcmt.Visible = false;
                            txtcmm.Visible = false;
                            txtcmc.Visible = false;
                            txtcmr.Visible = false;
                            txtcmd.Visible = false;
                            txtcmn.Text = "";
                            txtcmt.Text = "";
                            txtcmm.Text = "";
                            txtcmc.Text = "";
                            txtcmr.Text = "";
                            txtcmd.Text = "";
                            btnconfirmarmaterialp.Visible = false;
                            gvmaterial.Visible = true;
                            gvmaterial.DataBind();
                            mm1.Show();
                        }
                    }

                }
                else {
                    lbmaterial.Text = "no dispone de tanto material";
                }
                
            }

        }        
        //consumible
        protected void btnbuscarc_Click(object sender, EventArgs e)
        {
            if (txtconsumible.Text.Equals(""))
            {
                lbconsumible.Text = "nuevo";
                mc1.Show();
            }
            else {
                string buscar = "";
                buscar = txtconsumible.Text;
                int aux = con.buscarconsumible(buscar).Count;
                if (aux == 0)
                {

                }
                else {
                    gvconsumible.DataSource = con.buscarconsumible(buscar);
                    gvconsumible.DataBind();
                    mc1.Show();
                }
            }
        }
        
        
        

       

       
        

        
      
        

      
       

       

        

    }
}