<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="lemoncellar.WebForm2" %>
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
                    <div class="col-md-4">asd</div>
                    <div class="col-md-4">asd</div>
                    <div class="col-md-4">sad</div>
                </div>                
            </div>
            
        </ContentTemplate>
    </asp:UpdatePanel> 
</asp:Content>
