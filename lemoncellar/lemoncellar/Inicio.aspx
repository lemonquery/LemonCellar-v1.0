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
                        <asp:ImageButton ID="imhu" ImageUrl="ima/herramienta.jpg" runat="server" />
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
                            <h4>material</h4>
                        </div>
                        <div class="modal-body" style="text-align:center">
                            <asp:Button ID="bbuscarmaterial" CssClass="btn btn-primary" OnClick="bbuscarmaterial_Click" runat="server" Text="buscar" />
                            <asp:TextBox ID="txtbuscarm" CssClass="form-control-static" runat="server"></asp:TextBox><br/>
                            <asp:Label ID="lbmaterial" runat="server" Text=""></asp:Label>
                            <br /><br/>
                            <asp:GridView ID="gvmaterial" CssClass="table"  runat="server" AutoGenerateColumns="False">
                                <Columns>
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
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Select" Text=""><i class="fa fa-cubes" aria-hidden="true"></i></asp:LinkButton>
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
            <asp:Button ID="btnfalso1" runat="server" Visible="false" Text="Button" />
             <asp:ModalPopupExtender ID="mpam" runat="server" popupcontrolid="panelm2" targetcontrolid="btnfalso1"
                cancelcontrolid="btnClose1" backgroundcssclass="modalBackground">
            </asp:ModalPopupExtender>
            <asp:Panel ID="panelm2" runat="server">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header"></div>
                        <div class="modal-body">
                            <asp:Label ID="lbmanombre" runat="server"  Text="asd"></asp:Label>
                            <asp:Label ID="lbmatipo" runat="server"  Text="asd"></asp:Label>
                            <asp:Label ID="lbmamedida" runat="server"  Text="asd"></asp:Label>
                            <asp:Label ID="lbmacantidad" runat="server"  Text=""></asp:Label>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel> 
</asp:Content>
