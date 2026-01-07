<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="ArticuloABM.aspx.cs" Inherits="presentacion_catalogo.ArticuloABM" %>

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

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Código<span class="requerido"> *</span></label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre<span class="requerido"> *</span></label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="ddlTipo" class="form-label">Marca<span class="requerido"> *</span></label>
                <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoria</label>
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select"></asp:DropDownList>
            </div>
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
            <a href="ListaArticulos.aspx">Cancelar</a>

        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox runat="server" ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio<span class="requerido"> *</span></label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Imagen Url</label>
                        <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control" OnTextChanged="txtImagenUrl_TextChanged"
                            AutoPostBack="true" />
                        <asp:Image ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ8g4vijvJjDuCm90Myp8pwM6_972rKq5au2PhAKMedQNllKn1sbmsfDOznSDIMNODrSHs&usqp=CAU"
                            ID="imgImagen" runat="server" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-6">
                    <div class="mb-3">
                        <asp:Button Text="Eliminar" ID="btnEliminar" runat="server" CssClass="btn btn-danger"
                            OnClick="btnEliminar_Click"/>
                    </div>
                    <%if (ConfirmaEliiminacion)
                        { %>
                            <div class="mb-3">
                                <asp:CheckBox Text="Confirmar" ID="chkConfirmaEliminar" runat="server" />
                                <asp:Button Text="Eliminar" ID="btnConfirmaEliminacion" runat="server"
                                    CssClass="btn-outline-danger" OnClick="btnConfirmaEliminacion_Click" />
                            </div>
                   <% } %>            
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
