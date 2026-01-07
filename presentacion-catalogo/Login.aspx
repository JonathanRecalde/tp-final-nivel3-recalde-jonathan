<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="presentacion_catalogo.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .validacion{
            color:red;
            font-size:14px;
        }
        .requerido{
            color:red;
            font-size:16px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row">
        <div class="col-4">
            <h2>Logueate ...</h2>
            <div class="mb-3">
                <label class="form-label">Email<span class="requerido"> *</span></label>
                <asp:TextBox runat="server" cssclass="form-control" ClientIDMode="Static" ID="txtEmail"/>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="este campo es requerido!" ControlToValidate="txtEmail" runat="server" />
                <asp:RegularExpressionValidator CssClass="validacion" ErrorMessage="formato incorrecto" ControlToValidate="txtEmail" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Password<span class="requerido"> *</span></label>
                <asp:TextBox runat="server" cssclass="form-control" ID="txtPassword" TextMode="Password"/>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="este campo es requerido!" ControlToValidate="txtPassword" runat="server" />
            </div>
            <asp:Button runat="server" Text="Login" ID="btnLogin" OnClick="btnLogin_Click1" 
                CssClass="btn btn-primary" />
            <a href="Default.aspx">Cancelar</a>

        </div>
    </div>
</asp:Content>
