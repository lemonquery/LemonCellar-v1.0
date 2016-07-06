<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="lemoncellar.WebForm2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <div class="modal-content" style="text-align: right; margin-right: 20px; margin-left: 20px">
                <br />
                <div class="row">
                    <div class="col-md-8">
                        <h2 style="text-align: left; margin-left: 20px">BIENBENIDO AL CONTROL DE BODEGA</h2>
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
            <div class="modal-content" style="text-align: center; margin-right: 20px; margin-left: 20px">
                <div class="row">
                    <div class="col-md-4">
                        <br/>
                        <asp:ImageButton ID="immu" ImageUrl="ima/material.png" runat="server" />
                        
                    </div>
                    <div class="col-md-4">
                        <br/>
                        <asp:Button ID="btnverh" CssClass="btn btn-primary" runat="server" Text="Herramientas" />
                        <asp:Button ID="btnherra" CssClass="btn btn-primary" runat="server" Text="agregar" />
                        <asp:Label ID="lbagregado" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-md-4">
                        <br/>
                        <asp:ImageButton ID="imcu" ImageUrl="ima/consumible.png" runat="server" />
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
                        <div class="modal-header"  style="background-color:#2f8ead">
                            <h4>Material</h4>
                        </div>
                        <div class="modal-body" style="text-align:center">
                            <asp:Button ID="bbuscarmaterial" CssClass="btn btn-primary" OnClick="bbuscarmaterial_Click" runat="server" Text="buscar" />
                            <asp:TextBox ID="txtbuscarm" CssClass="form-control-static" runat="server"></asp:TextBox><br/>
                            <asp:Label ID="lbmaterial" runat="server" Text=""></asp:Label>
                            <br /><br/>
                            <asp:TextBox ID="txtvalorma" placeholder="precio" Visible="false"  CssClass="form-control" runat="server"></asp:TextBox> 
                            <asp:TextBox ID="txtcantidadma" placeholder="cantidad" Visible="false" CssClass="form-control" runat="server"></asp:TextBox><br/>
                            <asp:TextBox ID="txtcmn" Visible="false" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtcmt" Visible="false" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtcmm" Visible="false" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtcmc" Visible="false" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox><br/>
                            <asp:Button ID="btnconfirmarmaterial" CssClass="btn btn-primary" Visible="false" runat="server" Text="Confirmar"  OnClick="btnconfirmarmaterial_Click"/>
                            <asp:GridView ID="gvmaterial" CssClass="table"  runat="server" AutoGenerateColumns="False" OnSelectedIndexChanging="gvmaterial_SelectedIndexChanging">
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
                                    <asp:TemplateField HeaderText="Asignar">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" CssClass=" btn btn-primary" runat="server" CausesValidation="false" CommandName="Select" Text=""><i class="fa fa-cubes" ></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="modal-foter" style="background-color:#2f8ead">
                            <br/>
                            <asp:Button ID="btnClose1"  runat="server" CssClass="btn btn-default" Text="volver" />
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
                        <div class="modal-header">
                            <h5>Lista de Herramientas</h5>
                        </div>
                        <div class="modal-body" style="text-align:center">
                            <div class="input-group">
                                <span class="input-group-addon">Nombre</span>
                                <asp:TextBox ID="txthnombre" CssClass="form-control"  runat="server"></asp:TextBox>
                            </div><br/><br/>
                            <div class="input-group">
                                <span class="input-group-addon">Detalle</span>
                                <asp:TextBox ID="txthdetalle" CssClass="form-control"  runat="server"></asp:TextBox>
                            </div><br/><br/>
                            <div class="input-group">
                                <span class="input-group-addon">Valor</span>
                                <asp:TextBox ID="txthvalor" CssClass="form-control"  runat="server"></asp:TextBox>
                            </div><br/><br/>
                            <div class="input-group" style="text-align:center">
                                <div class="input-group-addon">Estado</div>                                
                                <asp:DropDownList ID="ddhestado" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="activo">activo</asp:ListItem>
                                    <asp:ListItem Value="inactivo">inactivo</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <br/><br/>
                            
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnagregarh" CssClass="btn btn-primary" OnClick="btnagregarh_Click" runat="server" Text="agregar" />
                            <asp:Button ID="btnclose2" CssClass="btn btn-default" runat="server" Text="Volver" />

                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:ModalPopupExtender ID="mpconsumible" runat="server" PopupControlID="panelconsum" TargetControlID="imcu"
                CancelControlID="btnclose3" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
            <asp:Panel ID="panelconsum" runat="server">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5>Lista de Consumibles</h5>
                        </div>
                        <div class="modal-body">
                           
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnclose3" CssClass="btn btn-default" runat="server" Text="Volver" />
                        </div>
                        
                    </div>
                </div>
            </asp:Panel>
           
            <%--vistas--%>
            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel3" TargetControlID="btnverh"
                CancelControlID="btnclose2" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel3" runat="server">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5>Lista de Herramientas</h5>
                        </div>
                        <div class="modal-body">
                            <asp:GridView ID="gvherramientas" CssClass="table btn-primary" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                        <div class="modal-footer">
                            <asp:Button ID="Button1" CssClass="btn btn-default" runat="server" Text="Volver" />
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel> 
</asp:Content>
