<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="control.aspx.cs" Inherits="lemoncellar.WebForm1" %>

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
                        <h2 style="text-align: left; margin-left: 20px">BIENBENIDO AL SISTEMA DE BODEGA</h2>
                    </div>
                    <div class="col-md-4">
                        <br />
                        <p style="margin-right: 20px">
                            <asp:Button ID="btnShow" CssClass="btn btn-primary" runat="server" Text="Ingresar" />
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
                        <asp:ImageButton ID="ImageButton1" OnClick="ImageButton1_Click" ImageUrl="ima/material.png"   runat="server" />
                        <br/>
                    </div>
                    <div class="col-md-4">
                        <br/>
                        <asp:ImageButton ID="ImageButton2"  ImageUrl="ima/herramienta.jpg"   runat="server" />
                        <br/>
                    </div>
                    <div class="col-md-4">
                        <br/>
                        <asp:ImageButton ID="ImageButton3"  ImageUrl="ima/consumible.png"   runat="server" />
                        <br/>
                    </div>
                </div>                
            </div>
            <!-- popuplogin -->
            <asp:modalpopupextender id="mp1" runat="server" popupcontrolid="Panel1" targetcontrolid="btnShow"
                        cancelcontrolid="btnClose" backgroundcssclass="modalBackground">
                    </asp:modalpopupextender>
            <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup"  Style="display: none">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div style="background-color:#2f8ead; color:white" class="modal-header text-center">
                                <h2>BIENBENIDO</h2>
                                <h5>al control de bodega</h5>
                            </div>
                            <div  class="modal-body text-center">                                
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="fa fa-user"></i></span>
                                    <asp:TextBox ID="txtusuario" CssClass="form-control"  placeholder="Nombre" runat="server"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger" ID="RequiredFieldValidator1" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtusuario" runat="server" ErrorMessage="campo vacio"></asp:RequiredFieldValidator><br/><br/>
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                    <asp:TextBox ID="txtclave" CssClass="form-control" TextMode="Password" placeholder="Clave" runat="server"></asp:TextBox>
                                </div>                                
                                <asp:RequiredFieldValidator CssClass="text-danger" ID="RequiredFieldValidator2" Display="Dynamic" ControlToValidate="txtclave" runat="server" ErrorMessage="campo vacio"></asp:RequiredFieldValidator><br/><br/>
                                <asp:Button ID="btnClose" OnClick="btnvolver_Click" CssClass=" btn btn-default" runat="server" Text="Volver" />
                                <asp:Button ID="btningrasar"  OnClick="btningrasar_Click" CssClass="btn btn-primary " runat="server" Text="Ingresar" /><br/><br/>
                            </div>
                            <div class="modal-footer"style="background-color:#2f8ead; color:white"">
                                <h5>Cooperativa de servicios de agua potable ltda.</h5>
                            </div>
                        </div>
                    </div>
            </asp:Panel>
            <!-- popupoffine -->
            <asp:ModalPopupExtender ID="mpmaterial" runat="server" PopupControlID="Panel2" TargetControlID="ImageButton1"
                CancelControlID="btnclose1" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel2" runat="server">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5>Lista de materiales</h5>
                        </div>
                        <div class="modal-body">
                            <asp:GridView ID="gvmaterial" CssClass=" table" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                            <asp:Button ID="btnclose1" CssClass="btn btn-default" runat="server" Text="volver" />
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:ModalPopupExtender ID="mpherramienta" runat="server" PopupControlID="Panel3" TargetControlID="ImageButton2"
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
                            <asp:Button ID="btnclose2" CssClass="btn btn-default" runat="server" Text="Volver" />
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:ModalPopupExtender ID="mpconsumible" runat="server" PopupControlID="Panel4" TargetControlID="ImageButton3"
                CancelControlID="btnclose3" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel4" runat="server">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5>Lista de Consumibles</h5>
                        </div>
                        <div class="modal-body">
                            <asp:GridView ID="gvconsumible" CssClass="table btn-primary" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                            <asp:Button ID="btnclose3" CssClass="btn btn-default" runat="server" Text="Volver" />
                        </div>
                        
                    </div>
                </div>
            </asp:Panel>
            <!-- ModalPopupExtender -->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
