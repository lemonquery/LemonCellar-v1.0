﻿<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="lemoncellar.WebForm2" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"  TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <div class="modal-content" style="text-align: right; margin-right: 20px; margin-left: 20px">
                
                <div class="row">
                    <div class="col-md-8">
                        <asp:Image ID="ima1" ImageUrl="ima/portada.png" runat="server" />
                    </div>
                    <div class="col-md-4">
                        <br />
                        <p style="margin-right: 20px">
                            <asp:Button ID="btncerrar" OnClick="btncerrar_Click" CssClass="btn btn-default" runat="server" Text="Cerrar" />
                        </p>
                    </div>
                </div>
                <br />
                <br />
            </div>
            <br/>
            <div class="modal-content" style="text-align: center; margin-right: 20px; margin-left: 20px; background-color:#2f8ead">
                <div class="row">
                    <div class="col-md-4" style="">
                        <br/>
                        <asp:ImageButton ID="immu" ImageUrl="ima/mater.png" runat="server" /><br/><br/>
                        <asp:ImageButton ID="btnmatI" ImageUrl="ima/compras.png" OnClick="btnmatI_Click1" runat="server" /><br/><br/>
                        <asp:ImageButton ID="btnmatS" ImageUrl="ima/movimientos.png" OnClick="btnmatS_Click1"   runat="server" /><br/><br/>
                        
                        <asp:GridView ID="gvmatI" Visible="false" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" >
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                        <asp:GridView ID="gvmatS" Visible="False" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
       
                        
                    </div>
                    <div class="col-md-4" style="border-left:solid 3px #2ab6b6;border-right:solid 3px #2ab6b6">
                        <br/>
                        <asp:ImageButton ID="btnherra" ImageUrl="ima/herra.jpg" runat="server" /><br/><br/>
                        
                        <asp:ImageButton ID="btnverh" ImageUrl="ima/baja.png" runat="server"  /><br/><br/>
                        
                        <asp:ImageButton ID="btnherL" ImageUrl="ima/herramien.png"  OnClick="btnherL_Click" runat="server"  /><br/><br/>
                        <asp:GridView ID="gvherL" CssClass="table" Visible="False" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </div>
                    <div class="col-md-4" style="">
                        <br/>
                        <asp:ImageButton ID="imcu" ImageUrl="ima/consu.png" runat="server" /><br/><br/>

                        <asp:ImageButton ID="btnconI" ImageUrl="ima/compras.png" runat="server" OnClick="btnconI_Click" /><br/><br/>
                        <asp:ImageButton ID="btnconG" ImageUrl="ima/movimientos.png" runat="server" OnClick="btnconG_Click" /><br/><br/>
                        <asp:GridView ID="gvconI" CssClass="table" Visible="False" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                        <asp:GridView ID="gvconG" CssClass="table" Visible="False" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </div>
                </div>                
            </div>
            <!-- ModalPopupExtender -->
            <asp:ModalPopupExtender ID="mm1" runat="server" popupcontrolid="panelm1" targetcontrolid="immu"
                cancelcontrolid="btnClose1" backgroundcssclass="modalBackground">

            </asp:ModalPopupExtender>
            <asp:Panel ID="panelm1" runat="server" CssClass="modalPopup" align="center" >
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header"  style="background-color:#2f8ead; color:white;">
                            <h4>Gestion de Materiales</h4>
                        </div>
                        <div class="modal-body" style="text-align:center">
                            <asp:Button ID="bbuscarmaterial" CssClass="btn btn-primary" OnClick="bbuscarmaterial_Click" runat="server" Text="buscar" />
                            <asp:TextBox ID="txtbuscarm" MaxLength="50" placeholder="Nombre del Material" CssClass="form-control-static" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtbuscart" MaxLength="50" placeholder="Tipo de Material" CssClass="form-control-static" runat="server"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" TargetControlID="txtbuscarm"  ValidChars="abcdefghijklmnopqrstuvwxyzñáéíóúü /-1234567890"  runat="server"></asp:FilteredTextBoxExtender>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" TargetControlID="txtbuscart"  ValidChars="abcdefghijklmnopqrstuvwxyzñáéíóúü /-1234567890"  runat="server"></asp:FilteredTextBoxExtender>
                            <asp:LinkButton ID="agregarmat" Visible="false" CssClass="btn btn-primary" OnClick="agregarmat_Click" runat="server"><i class="fa fa-archive" aria-hidden="true"> otra medida</i></asp:LinkButton>
                            <br/>
                            <asp:Label ID="lbmaterial" runat="server" Text=""></asp:Label>
                            <br /><br/>              
                                       
                            <asp:TextBox ID="txtcmn" MaxLength="50" Visible="false" CssClass="form-control" Enabled="false" runat="server" placeholder="Nombre"></asp:TextBox>                           
                            <asp:TextBox ID="txtcmt" MaxLength="50" Visible="false" CssClass="form-control" Enabled="false" runat="server" placeholder="Tipo"></asp:TextBox>
                            <asp:TextBox ID="txtcmm" MaxLength="50" Visible="false" CssClass="form-control" Enabled="false" runat="server" placeholder="Medida"></asp:TextBox>
                            <asp:TextBox ID="txtcmc" MaxLength="50" Visible="false" CssClass="form-control"  runat="server" placeholder=" ingrese la Cantidad"></asp:TextBox>
                            <asp:TextBox ID="txtcmv" MaxLength="50" Visible="false"  CssClass="form-control" placeholder="precio unitario" runat="server"></asp:TextBox>                             
                            <asp:TextBox ID="txtcmr" MaxLength="50" placeholder="Responsable" Visible="false" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtcmd" MaxLength="50" placeholder="comentario" Visible="false" CssClass="form-control" runat="server"></asp:TextBox>
                             <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtcmn"  ValidChars="abcdefghijklmnopqrstuvwxyzñáéíóúü /-1234567890"  runat="server"></asp:FilteredTextBoxExtender>
                             <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txtcmt"  ValidChars="abcdefghijklmnopqrstuvwxyzñáéíóúü /-1234567890" runat="server"></asp:FilteredTextBoxExtender>
                             <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txtcmm"  ValidChars="abcdefghijklmnopqrstuvwxyzñáéíóúü /-1234567890" runat="server"></asp:FilteredTextBoxExtender>
                             <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="txtcmc"  FilterType="Numbers"  runat="server"></asp:FilteredTextBoxExtender>
                             <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" TargetControlID="txtcmv"  FilterType="Numbers"  runat="server"></asp:FilteredTextBoxExtender>
                             <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" TargetControlID="txtcmr"  ValidChars="abcdefghijklmnopqrstuvwxyzñáéíóúü /-1234567890" runat="server"></asp:FilteredTextBoxExtender>
                             <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" TargetControlID="txtcmd"  ValidChars="abcdefghijklmnopqrstuvwxyzñáéíóúü /-1234567890" runat="server"></asp:FilteredTextBoxExtender>
                            <asp:Button ID="btnmaterialn" CssClass="btn btn-primary" Visible="false" runat="server" Text="agregar"  OnClick="btnmaterialn_Click"/><br/>
                            
                            <asp:Button ID="btnconfirmarmaterial" CssClass="btn btn-primary" Visible="false" runat="server" Text="Confirmar"  OnClick="btnconfirmarmaterial_Click"/>
                            <asp:Button ID="btnconfirmarmaterialp" CssClass="btn btn-primary" Visible="false" runat="server" Text="Confirmar" OnClick="btnconfirmarmaterialp_Click" />
                            <asp:GridView ID="gvmaterial" CssClass="table"  runat="server" AutoGenerateColumns="False" PageSize="5"
                                 OnSelectedIndexChanging="gvmaterial_SelectedIndexChanging" AllowPaging="True"
                                 OnPageIndexChanging="gvmaterial_PageIndexChanging"  OnRowUpdating="gvmaterial_RowUpdating" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    
                                    <asp:TemplateField HeaderText="" SortExpression="ID_MATERIAL">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label5" Visible="false" runat="server" Text='<%# Eval("ID_MATERIAL") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" Visible="false"  runat="server" Text='<%# Bind("ID_MATERIAL") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Nombre" SortExpression="NOMBRE">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("NOMBRE") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("NOMBRE") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tipo" SortExpression="TIPO">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("TIPO") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("TIPO") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Medida" SortExpression="MEDIDA">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("MEDIDA") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("MEDIDA") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cantidad" SortExpression="CANTIDAD">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("CANTIDAD") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("CANTIDAD") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Compra">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" CssClass=" btn btn-primary" runat="server" CausesValidation="false" CommandName="Select" Text=""><i class="fa fa-cubes" ></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Prestar">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton2" CssClass="btn btn-primary" runat="server" CausesValidation="false" CommandName="Update" Text="Botón"><i class="fa fa-external-link" aria-hidden="true"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerSettings Mode="NextPrevious" NextPageText="&gt;&gt;&gt;" PreviousPageText="&lt;&lt;&lt;" />
                                <PagerStyle Font-Size="X-Large" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#2461BF" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </div>
                        <div class="modal-foter" style="background-color:#2f8ead">
                            <br/>
                            <asp:Button ID="btnClose1"  runat="server" CssClass="btn btn-default" Text="volver" />
                            <asp:Label ID="lbid" runat="server" Visible="false" Text=""></asp:Label>
                            <asp:Label ID="lbid2" runat="server" Visible="false" Text="Label"></asp:Label>
                            <asp:Label ID="lbcantidad" Visible="false" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lbcantidadp" Visible="false" runat="server" Text=""></asp:Label>
                            <br/><br/>
                        </div>
                    </div>
                </div>
                
            </asp:Panel>
            <!-- ModalPopupExtender -->
            <asp:ModalPopupExtender ID="mpherramienta" runat="server" PopupControlID="panelherra" TargetControlID="btnherra"
                CancelControlID="btnclose2" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
            <asp:Panel ID="panelherra" runat="server">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header" style="background-color:#2f8ead; color:white; text-align:center">
                            <h4>Gestion de Herramientas</h4>
                        </div>
                        <div class="modal-body" style="text-align:center">
                            <asp:Label ID="lbtexth" runat="server" Text="Ingrese la Compra de la Herramienta Nueva"></asp:Label><br/><br/>
                            <asp:TextBox ID="txthnombre" MaxLength="50" CssClass="form-control" placeholder="Nombre" runat="server"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" TargetControlID="txthnombre"  ValidChars="abcdefghijklmnopqrstuvwxyzñáéíóúü /-1234567890" runat="server"></asp:FilteredTextBoxExtender><br/><br/>
                            <asp:TextBox ID="txthdetalle" MaxLength="50" CssClass="form-control" placeholder="Detalle"  runat="server"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" TargetControlID="txthdetalle"  ValidChars="abcdefghijklmnopqrstuvwxyzñáéíóúü /-1234567890" runat="server"></asp:FilteredTextBoxExtender><br/><br/>
                            <asp:TextBox ID="txthvalor" MaxLength="50" CssClass="form-control" placeholder="Valor"  runat="server"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" TargetControlID="txthvalor" ValidChars="1234567890" runat="server"></asp:FilteredTextBoxExtender><br/><br/>
                            <asp:Label ID="ddhestados" runat="server" Visible="false" Text="activo"></asp:Label>
                            <br/><br/>
                            <asp:Button ID="btnagregarh" CssClass="btn btn-primary" OnClick="btnagregarh_Click" runat="server" Text="agregar" />
                            
                        </div>
                        <div class="modal-footer" style="background-color:#2f8ead">
                            
                            <asp:Button ID="btnclose2" CssClass="btn btn-default" runat="server" Text="Volver" />

                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:ModalPopupExtender ID="mc1" runat="server" PopupControlID="panelconsum" TargetControlID="imcu"
                CancelControlID="btnclose3" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
            <asp:Panel ID="panelconsum" runat="server">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header" style="background-color:#2f8ead;color:white; text-align:center">
                            <h4>Gestion de Consumibles</h4>
                        </div>
                        <div class="modal-body" style="text-align:center">
                            <asp:Button ID="btnbuscarc" CssClass="btn btn-primary" runat="server" Text="Buscar" OnClick="btnbuscarc_Click" />
                            <asp:TextBox ID="txtconsumible" MaxLength="50" placeholder="Nombre del Consumible" CssClass="form-control-static" runat="server"></asp:TextBox><br/>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" TargetControlID="txtconsumible"  ValidChars="abcdefghijklmnopqrstuvwxyzñáéíóúü /-1234567890" runat="server"></asp:FilteredTextBoxExtender>
                            <asp:Label ID="lbconsumible" runat="server" Text=""></asp:Label>
                            <asp:TextBox ID="txtccn" MaxLength="50" Visible="false" CssClass="form-control" runat="server" placeholder="Nombre" ></asp:TextBox>
                            <asp:TextBox ID="txtccc" MaxLength="50" Visible="false" CssClass="form-control" runat="server" placeholder="Cantidad" ></asp:TextBox>                             
                            <asp:TextBox ID="txtccd" MaxLength="50" Visible="false" CssClass="form-control" runat="server" placeholder="comentario" ></asp:TextBox>
                            <asp:TextBox ID="txtccv" MaxLength="50" Visible="false" CssClass="form-control" runat="server" placeholder="valor" ></asp:TextBox>
                             <asp:TextBox ID="txtccd2" MaxLength="50" Visible="false" CssClass="form-control" runat="server" placeholder="comentario" ></asp:TextBox>
                            <asp:TextBox ID="txtccc2" MaxLength="50" Visible="false" CssClass="form-control" runat="server" placeholder="Cantidad" ></asp:TextBox><br/>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" TargetControlID="txtccn"  ValidChars="abcdefghijklmnopqrstuvwxyzñáéíóúü /-1234567890" runat="server"></asp:FilteredTextBoxExtender>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" TargetControlID="txtccc" FilterType="Numbers" runat="server"></asp:FilteredTextBoxExtender>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" TargetControlID="txtccc2" FilterType="Numbers" runat="server"></asp:FilteredTextBoxExtender>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" TargetControlID="txtccd" ValidChars="abcdefghijklmnopqrstuvwxyzñáéíóúü /-1234567890" runat="server"></asp:FilteredTextBoxExtender>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" TargetControlID="txtccv" FilterType="Numbers" runat="server"></asp:FilteredTextBoxExtender>
                             <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" TargetControlID="txtccd2" ValidChars="abcdefghijklmnopqrstuvwxyzñáéíóúü /-1234567890" runat="server"></asp:FilteredTextBoxExtender>
                            <asp:Button ID="btnguardar" Visible="false" CssClass="btn btn-primary" runat="server" Text="Confirmar" OnClick="btnguardar_Click" />                            
                            <asp:Label ID="lbcid" Visible="false" CssClass="form-control" runat="server" Text=""></asp:Label>
                            <asp:Button ID="btnconfirmarI" Visible="false" CssClass="btn btn-primary" runat="server" Text="Confirmar" OnClick="btnconfirmarI_Click" />
                            <asp:Button ID="btnconfirmarG" Visible="false" CssClass="btn btn-primary" runat="server" Text="Confirmar" OnClick="btnconfirmarG_Click" />
                            <asp:GridView ID="gvconsumible" runat="server" CssClass="table" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowUpdating="gvconsumible_RowUpdating" OnSelectedIndexChanging="gvconsumible_SelectedIndexChanging" AllowPaging="True" OnPageIndexChanging="gvconsumible_PageIndexChanging" PageSize="5">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField SortExpression="ID_CONSUMIBLE">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("ID_CONSUMIBLE") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("ID_CONSUMIBLE") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre" SortExpression="NOMBRE">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("NOMBRE") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("NOMBRE") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cantidad" SortExpression="CANTIDAD">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("CANTIDAD") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("CANTIDAD") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Detalle" SortExpression="DETALLE">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("DETALLE") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("DETALLE") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ingresar">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" CssClass="btn btn-primary" runat="server" CausesValidation="false" CommandName="Select" Text=""><i class="fa fa-cubes" aria-hidden="true"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Gastar">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton2" CssClass="btn btn-primary" runat="server" CausesValidation="false" CommandName="Update" Text=""><i class="fa fa-external-link" aria-hidden="true"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerSettings Mode="NextPrevious" NextPageText="&gt;&gt;&gt;" PreviousPageText="&lt;&lt;&lt;" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </div>
                        <div class="modal-footer" style="background-color:#2f8ead">
                            <asp:Button ID="btnclose3" CssClass="btn btn-default" runat="server" Text="Volver" />
                        </div>
                        
                    </div>
                </div>
            </asp:Panel>
           
            <%--vistas--%>
            <asp:ModalPopupExtender ID="mh1" runat="server" PopupControlID="Panel3" TargetControlID="btnverh"
                CancelControlID="btnclose2" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel3" runat="server">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header" style="background-color:#2f8ead; color:white; text-align:center" >
                            <h5>Dar de baja una herramienta</h5>
                        </div>
                        <div class="modal-body" style="text-align:center">
                            <asp:Button ID="btnbuscarH" CssClass="btn btn-primary" runat="server" OnClick="btnbuscarH_Click" Text="Buscar" />
                            <asp:TextBox ID="txtbuscarH" CssClass="form-control-static" placeholder="Nombre de la Herramienta" runat="server"></asp:TextBox><br/>
                            <asp:Label ID="lbherramienta" runat="server" Text=""></asp:Label>
                            <asp:GridView ID="gvherramientas" CssClass="table btn-primary" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnSelectedIndexChanging="gvherramientas_SelectedIndexChanging" AllowPaging="True" OnPageIndexChanging="gvherramientas_PageIndexChanging" PageSize="5">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField SortExpression="ID_HERRAMIENTA">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Visible="false" Text='<%# Eval("ID_HERRAMIENTA") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Visible="false" Text='<%# Bind("ID_HERRAMIENTA") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre" SortExpression="NOMBRE">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("NOMBRE") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("NOMBRE") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Detalle" SortExpression="DETALLE">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("DETALLE") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("DETALLE") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="VALOR">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Visible="false" Text='<%# Eval("VALOR") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Visible="false" Text='<%# Bind("VALOR") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="FECHA">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label5" runat="server" Visible="false" Text='<%# Eval("FECHA") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" runat="server" Visible="false" Text='<%# Bind("FECHA") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="bajar">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CssClass="btn btn-primary" CommandName="Select" Text=""><i class="fa fa-arrow-circle-down" aria-hidden="true"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerSettings Mode="NextPrevious" NextPageText="&gt;&gt;&gt;" PreviousPageText="&lt;&lt;&lt;" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                            
                            <asp:Label ID="lbidh" Visible="false" runat="server" CssClass="form-control" Text=""></asp:Label>
                            <asp:Label ID="lbnombreh" Visible="false" runat="server"  CssClass="form-control" Text=""></asp:Label>
                            <asp:Label ID="lbdetalleh" Visible="false" runat="server"  CssClass="form-control" Text=""></asp:Label>
                            <asp:Label ID="lbvalorh" Visible="false" runat="server"  CssClass="form-control" Text=""></asp:Label>
                            <asp:Label ID="lbfechah" Visible="false" runat="server"   CssClass="form-control" Text=""></asp:Label><br/>
                            <asp:Button ID="btnconfirmarH" CssClass="btn btn-primary"  OnClick="btnconfirmarH_Click" Visible="false" runat="server" Text="Confirmar" />
                        </div>
                        <div class="modal-footer" style="background-color:#2f8ead">
                            <asp:Button ID="Button1" CssClass="btn btn-default" runat="server" Text="Volver" />
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel> 
</asp:Content>
