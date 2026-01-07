<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="VerDetalle.aspx.cs" Inherits="presentacion_catalogo.VerDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .label{
            color:cornflowerblue;
            font-size:20px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:Label Text="" ID="lblNombre" CssClass="label form-label" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="txtDescripcion" class="form-label">Descripción</label>
                    <asp:Label Text="" ID="lblDescripcion" CssClass="label form-label"  runat="server" />
                </div>
                <div class="mb-3">
                    <label for="txtMarca" class="form-label">Marca</label>
                    <asp:Label Text="" ID="lblMarca" CssClass="label form-label" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="txtCategoria" class="form-label">Categoria</label>
                    <asp:Label Text="" ID="lblCategoria" CssClass="label form-label" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="txtPrecio" class="form-label">Precio</label>
                    <asp:Label Text="" ID="lblPrecio" CssClass="label form-label" runat="server" />
                </div>
            </div>
            <div class="col-6">
                <asp:Image ID="imgImagen" runat="server" CssClass="img-fluid mb-3" />
            </div>
        </div>

</asp:Content>