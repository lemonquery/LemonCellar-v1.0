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
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Drawing;

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
                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                scriptManager.RegisterPostBackControl(this.btnmatS);
                scriptManager.RegisterPostBackControl(this.btnmatI);
                scriptManager.RegisterPostBackControl(this.btnconI);
                scriptManager.RegisterPostBackControl(this.btnconG);
                scriptManager.RegisterPostBackControl(this.btnherL);
                //Further code goes here....
                
                gvmatI.DataSource = cov.listamaterialI();
                gvmatI.DataBind();
                gvmatS.DataSource = cov.listamaterialS();
                gvmatS.DataBind();
                gvconI.DataSource = cov.listaconsumibleI();
                gvconI.DataBind();
                gvconG.DataSource = cov.listaconsumibleG();
                gvconG.DataBind();
                gvherL.DataSource = cov.listaherramientaL();
                gvherL.DataBind();
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
            string buscart = "";
            buscar = txtbuscarm.Text;
            buscart = txtbuscart.Text;
            int aux = con.buscarmaterial(buscar,buscart).Count;
            if (aux == 0)
            {
                if (txtbuscarm.Text.Equals("") || txtbuscart.Text.Equals(""))
                {
                    lbmaterial.Text = "rellene los campos";
                    mm1.Show();
                }
                else {
                    txtcmv.Visible = false;
                    lbmaterial.Text = "no se encontro registro, registre un nuevo material";
                    agregarmat.Visible = false;
                    txtcmn.Visible = true;
                    txtcmn.Text = buscar;
                    txtcmt.Visible = true;
                    txtcmt.Text = buscart;
                    txtcmm.Visible = true;
                    txtcmm.Enabled = true;


                    txtcmc.Visible = false;
                    txtcmc.Text = "";
                    txtcmv.Visible = false;
                    txtcmv.Text = "";
                    btnconfirmarmaterial.Visible = false;
                    btnconfirmarmaterialp.Visible = false;

                    btnmaterialn.Visible = true;

                    gvmaterial.DataSource = null;
                    gvmaterial.DataBind();
                    mm1.Show();
                }
                
            }
            else {
                agregarmat.Visible = true;
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
                gvmaterial.DataSource = con.buscarmaterial(buscar,buscart);
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
            if (txtcmn.Text.Equals("") || txtcmt.Text.Equals("") || txtcmm.Text.Equals("") )
            {
                lbmaterial.Text = "rellene campos";
                mm1.Show();
            }
            else {



                string nombre = txtcmn.Text;
                string tipo = txtcmt.Text;
                string medida = txtcmm.Text+".";
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
                    agregarmat.Visible = false;
                    mm1.Show();
                }

            }
        }
        protected void gvmaterial_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvmaterial.PageIndex = e.NewPageIndex;
            string buscar = "";
            string buscart = "";
            buscar = txtbuscarm.Text;
            buscart = txtbuscart.Text;
            int aux = con.buscarmaterial(buscar,buscart).Count;
            if (aux == 0)
            {

            }
            else {
                gvmaterial.DataSource = con.buscarmaterial(buscar,buscart);
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

                if (cantn != 0)
                {
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
                            mm1.Show();
                        }
                    }
                }
                else {
                    lbmaterial.Text = "la cantidad no puede ser 0";
                    txtcmc.Text = "";
                    mm1.Show();
                }


                
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
                if (mcann != 0)
                {
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
                                ID_MATERIAL = mid,
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
                    else
                    {
                        lbmaterial.Text = "no dispone de tanto material";
                        mm1.Show();
                    }
                }
                else {
                    lbmaterial.Text = "tiene que asignar una cantidad mayor a 0";
                    txtcmc.Text = "";
                    mm1.Show();
                }
                
                
            }

        }        
        //consumible
        protected void btnbuscarc_Click(object sender, EventArgs e)
        {
            string buscar = "";
            gvconsumible.Visible = true;
            buscar = txtconsumible.Text;
            int aux = con.buscarconsumible(buscar).Count;
            if (aux == 0)
            {
                if (txtconsumible.Text.Equals(""))
                {
                    lbconsumible.Text = "rellene campos";
                    mc1.Show();
                }
                else {
                    lbconsumible.Text = "nuevo";
                    mc1.Show();
                    txtccn.Visible = true;
                    txtccn.Text = txtconsumible.Text;
                    txtccn.Enabled = false;
                    txtccd.Visible = true;
                    txtccd.Enabled = true;
                    txtccd.Text = "";
                    btnguardar.Visible = true;
                    btnconfirmarG.Visible = false;
                    btnconfirmarI.Visible = false;
                    txtccc2.Visible = false;
                    txtccd2.Visible = false;
                    txtccv.Visible = false;

                    gvconsumible.Visible = false;
                }
                
            }
            else
            {
                txtccn.Visible = false;
                txtccn.Enabled = true;
                txtccn.Text = "";
                txtccc.Visible = false;
                txtccc.Text = "";
                txtccd.Visible = false;
                txtccd.Enabled = true;
                txtccd.Text = "";
                btnconfirmarG.Visible = false;
                btnconfirmarI.Visible = false;
                lbconsumible.Text = "";
                txtccv.Visible = false;
                txtccv.Text = "";
                txtccd2.Visible = false;
                txtccd2.Text = "";
                txtccc2.Visible = false;
                txtccc2.Text = "";

                gvconsumible.DataSource = con.buscarconsumible(buscar);
                gvconsumible.DataBind();
                mc1.Show();
            }
        }
        protected void gvconsumible_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            lbconsumible.Text = "a ingresar";
            mc1.Show();
            Label id = (Label)gvconsumible.Rows[e.NewSelectedIndex].FindControl("Label1");
            Label nombre = (Label)gvconsumible.Rows[e.NewSelectedIndex].FindControl("Label2");
            Label cantidad = (Label)gvconsumible.Rows[e.NewSelectedIndex].FindControl("Label3");
            Label detalle = (Label)gvconsumible.Rows[e.NewSelectedIndex].FindControl("Label4");

            lbcid.Text = id.Text;
            txtccn.Visible = true;
            txtccn.Enabled = false;
            txtccn.Text = nombre.Text;
            txtccc.Visible = false;
            txtccc.Text = cantidad.Text;
            txtccd.Visible = true;
            txtccd.Enabled = false;
            txtccd.Text = detalle.Text;
            txtccv.Visible = true;
            txtccc2.Visible = true;

            btnconfirmarI.Visible = true;
            btnconfirmarG.Visible = false;
            gvconsumible.Visible = false;

        }
        protected void gvconsumible_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            lbconsumible.Text = "b prestar";
            mc1.Show();
            Label id = (Label)gvconsumible.Rows[e.RowIndex].FindControl("Label1");
            Label nombre = (Label)gvconsumible.Rows[e.RowIndex].FindControl("Label2");
            Label cantidad = (Label)gvconsumible.Rows[e.RowIndex].FindControl("Label3");
            Label detalle = (Label)gvconsumible.Rows[e.RowIndex].FindControl("Label4");

            lbcid.Text = id.Text;
            txtccn.Visible = true;
            txtccn.Enabled = false;
            txtccn.Text = nombre.Text;
            txtccc.Visible = false;
            txtccc.Text = cantidad.Text;
            txtccd.Visible = true;
            txtccd.Enabled = false;
            txtccd.Text = detalle.Text;
            txtccd2.Visible = true;
            txtccc2.Visible = true;

            btnconfirmarG.Visible = true;
            btnconfirmarI.Visible = false;
            gvconsumible.DataBind();
        }
        protected void btnguardar_Click(object sender, EventArgs e)
        {
            if ( txtccd.Text.Equals(""))
            {
                lbconsumible.Text = "rellene los campos";
            }else{
                string nombre = "";
                string comentario="";
                nombre = txtccn.Text;
                comentario = txtccd.Text;
                CONSUMIBLE nuevo = new CONSUMIBLE
                {
                    NOMBRE = nombre,
                    CANTIDAD = 0,
                    DETALLE = comentario
                };
                if (con.agregarconsumible(nuevo))
                {
                    txtccn.Visible = false;
                    txtccn.Text = "";
                    txtccd.Visible = false;
                    txtccd.Text = "";
                    btnguardar.Visible = false;
                    gvconsumible.Visible = true;
                    lbconsumible.Text = "agregado correctamente";
                    mc1.Show();
                    
                }
            }
        }
        protected void btnconfirmarI_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lbcid.Text);
            string nombre = txtccn.Text;
            int cantidada = Convert.ToInt32(txtccc.Text);
            string medida = txtccd.Text;

            

            if (txtccv.Text.Equals("") || txtccc2.Text.Equals(""))
            {
                lbconsumible.Text = "rellene los campos";
                mc1.Show();
            }
            else {
                int valor = Convert.ToInt32(txtccv.Text);
                int cantidadn = Convert.ToInt32(txtccc2.Text);
                DateTime fecha = DateTime.Now;
                int s = cantidada + cantidadn;
                if (cantidadn == 0)
                {
                    lbconsumible.Text = "debe ingresar una cantidad mayor a 0";
                    mc1.Show();
                }
                else {
                    CONSUMIBLE nuevo = new CONSUMIBLE
                    {
                        ID_CONSUMIBLE = id,
                        NOMBRE = nombre,
                        CANTIDAD = s,
                        DETALLE = medida
                    };
                    if (con.Actualizarconsumible(nuevo))
                    {
                        CONSUMIBLE_I nuevoI = new CONSUMIBLE_I
                        {
                            ID_CONSUMIBLE = id,
                            VALOR = valor,
                            FECHA= fecha,
                            CANTIDAD_IC = cantidadn
                        };
                        if (con.agregarconsumibleI(nuevoI))
                        {
                            lbconsumible.Text = "compra agregada";
                            mc1.Show();
                            lbid.Text = "";
                            txtccn.Visible = false;
                            txtccn.Text = "";
                            txtccc.Text = "";
                            txtccd.Visible = false;
                            txtccd.Enabled = true;
                            txtccd.Text = "";
                            txtccv.Visible = false;
                            txtccv.Text = "";
                            txtccc2.Visible = false;
                            txtccc2.Text = "";
                            btnconfirmarI.Visible = false;
                            gvconsumible.Visible = true;
                            gvconsumible.DataBind();

                        }
                    }
                }
            }
        }
        protected void btnconfirmarG_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lbcid.Text);
            string nombre = txtccn.Text;
            int cantidada = Convert.ToInt32(txtccc.Text);
            string medida = txtccd.Text;

            

            if (txtccd2.Text.Equals("") || txtccc2.Text.Equals(""))
            {
                lbconsumible.Text = "rellene los campos";
                mc1.Show();
            }
            else {
                string comentario = txtccd2.Text;
                int cantidadn = Convert.ToInt32(txtccc2.Text);
                DateTime fecha = DateTime.Now;
                int s = cantidada - cantidadn;

                if (cantidadn == 0)
                {
                    lbconsumible.Text = "un gasto debe ser mallor a 0";
                    mc1.Show();
                }
                else {
                    if (s < 0)
                    {
                        lbconsumible.Text = "no se cuenta con tanto consumible";
                        mc1.Show();
                    }
                    else {
                        CONSUMIBLE nuevo = new CONSUMIBLE
                        {
                            ID_CONSUMIBLE = id,
                            NOMBRE = nombre,
                            CANTIDAD = s,
                            DETALLE = medida
                        };
                        if (con.Actualizarconsumible(nuevo))
                        {
                            CONSUMIBLE_G nuevog = new CONSUMIBLE_G
                            {
                                ID_CONSUMIBLE = id,
                                FECHA = fecha,
                                DETALLE = comentario,
                                CANTIDAD_SC = cantidadn
                            };
                            if (con.agregarconsumibleG(nuevog))
                            {
                                lbconsumible.Text = "gasto realizado";
                                mc1.Show();
                                lbid.Text = "";
                                txtccn.Visible = false;
                                txtccn.Text = "";
                                txtccc.Text = "";
                                txtccd.Visible = false;
                                txtccd.Enabled = true;
                                txtccd.Text = "";
                                txtccd2.Visible = false;
                                txtccd2.Text = "";
                                txtccc2.Visible = false;
                                txtccc2.Text = "";
                                btnconfirmarG.Visible = false;
                                gvconsumible.Visible = true;
                                gvconsumible.DataBind();
                            }
                        }
                    }
                }
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
             

        

        protected void btnconI_Click(object sender, EventArgs e)
        {
            gvconI.Visible = true;
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Compras consumibles.xls");

            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter tw = new HtmlTextWriter(sw);

            gvconI.RenderControl(tw);
            Response.Write(sw.ToString());
            Response.End();
            gvconI.Visible = false;
        }

        protected void btnconG_Click(object sender, EventArgs e)
        {
            gvconG.Visible = true;
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=asignacione consumibles.xls");

            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter tw = new HtmlTextWriter(sw);

            gvconG.RenderControl(tw);
            Response.Write(sw.ToString());
            Response.End();
            gvconG.Visible = false;
        }

        protected void btnherL_Click(object sender, EventArgs e)
        {
            gvherL.Visible = true;
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=herramientas.xls");

            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter tw = new HtmlTextWriter(sw);

            gvherL.RenderControl(tw);
            Response.Write(sw.ToString());
            Response.End();
            gvherL.Visible = false;
        }

        protected void btnbuscarH_Click(object sender, EventArgs e)
        {
            gvherramientas.Visible = true;
            lbnombreh.Visible = false;
            lbdetalleh.Visible = false;
            btnconfirmarH.Visible = false;
            if (txtbuscarH.Text.Equals(""))
            {
                lbherramienta.Text = "rellene los campos";
                mh1.Show();
            }
            else {
                string buscar = txtbuscarH.Text;
                int aux = cov.buscarherra(buscar).Count;
                if (aux == 0)
                {
                    lbherramienta.Text = "no se encontro la herramienta";
                    mh1.Show();
                }
                else
                {
                    gvherramientas.DataSource = cov.buscarherra(buscar);
                    gvherramientas.DataBind();
                    mh1.Show();
                    lbherramienta.Text = "";
                    mh1.Show();

                }
            }
            
        }

        protected void gvherramientas_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Label id = (Label)gvherramientas.Rows[e.NewSelectedIndex].FindControl("Label1");
            Label nombre = (Label)gvherramientas.Rows[e.NewSelectedIndex].FindControl("Label2");
            Label valor = (Label)gvherramientas.Rows[e.NewSelectedIndex].FindControl("Label3");
            Label detalle = (Label)gvherramientas.Rows[e.NewSelectedIndex].FindControl("Label4");
            Label fecha = (Label)gvherramientas.Rows[e.NewSelectedIndex].FindControl("Label5");

            lbidh.Text = id.Text;
            lbnombreh.Text = nombre.Text;
            lbdetalleh.Text = detalle.Text;
            lbvalorh.Text = valor.Text;
            lbfechah.Text = fecha.Text;

            lbnombreh.Visible = true;
            lbdetalleh.Visible = true;
            lbherramienta.Text = "la siguiente herramienta sera dada de baja";
            gvherramientas.Visible = false;
            btnconfirmarH.Visible = true;
            mh1.Show();
        }

        protected void btnconfirmarH_Click(object sender, EventArgs e)
        {
            HERRAMIENTA nueva = new HERRAMIENTA
            {
                ID_HERRAMIENTA = Convert.ToInt32(lbidh.Text),
                NOMBRE = lbnombreh.Text,
                DETALLE = lbdetalleh.Text,
                VALOR = Convert.ToInt32(lbvalorh.Text),
                FECHA = Convert.ToDateTime(lbfechah.Text),
                ESTADO = "inactivo"


            };
            if (con.ActualizarHerramienta(nueva))
            {
                lbherramienta.Text = "la herramienta se dio de baja correctamente";
                lbidh.Text = "";
                lbnombreh.Text = "";
                lbdetalleh.Text = "";
                lbvalorh.Text = "";
                lbfechah.Text = "";

                lbnombreh.Visible = false;
                lbdetalleh.Visible = false;
                btnconfirmarH.Visible = false;
                gvherramientas.Visible = true;
                gvherramientas.DataBind();
            }
        }

        protected void btnmatI_Click1(object sender, ImageClickEventArgs e)
        {
            gvmatI.Visible = true;
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=compras materiales.xls");

            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter tw = new HtmlTextWriter(sw);

            gvmatI.RenderControl(tw);
            Response.Write(sw.ToString());
            Response.End();
            gvmatI.Visible = false;
        }

        protected void btnmatS_Click1(object sender, ImageClickEventArgs e)
        {
            gvmatS.Visible = true;
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=asignaciones materiales.xls");

            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter tw = new HtmlTextWriter(sw);

            gvmatS.RenderControl(tw);
            Response.Write(sw.ToString());
            Response.End();
            gvmatS.Visible = false;
        }

        protected void agregarmat_Click(object sender, EventArgs e)
        {
            string buscar = "";
            string buscart = "";
            buscar = txtbuscarm.Text;
            buscart = txtbuscart.Text;
            txtcmv.Visible = false;
            lbmaterial.Text = "agregue un material cn otra medida";

            txtcmn.Visible = true;
            txtcmn.Text = buscar;
            txtcmt.Visible = true;
            txtcmt.Text = buscart;
            txtcmm.Visible = true;
            txtcmm.Enabled = true;


            txtcmc.Visible = false;
            txtcmc.Text = "";
            txtcmv.Visible = false;
            txtcmv.Text = "";
            btnconfirmarmaterial.Visible = false;
            btnconfirmarmaterialp.Visible = false;

            btnmaterialn.Visible = true;

            gvmaterial.DataSource = null;
            gvmaterial.DataBind();
            mm1.Show();
        }

        
        
    }
}