<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="presentacion_catalogo.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server" />
    <div class="row">
        <div class="col-10">
            <asp:GridView runat="server" ID="dgvFavoritos" CssClass="table table-bordered"
                AutoGenerateColumns="false" DataKeyNames="Id"
                OnSelectedIndexChanged="dgvFavoritos_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                    <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                    <asp:CommandField HeaderText="Eliminar" ShowSelectButton="true" SelectText="seleccionar" />
                </Columns>
            </asp:GridView>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-6">
                            <div class="mb-3">
                                <%if (ConfirmaEliminacion)
                                    { %>
                                <div class="mb-3">
                                    <asp:CheckBox Text="Confirmar Eliminación" runat="server" ID="chkConfirmaEliminar" />
                                    <asp:Button Text="Eliminar" runat="server" ID="btnConfirmaEliminar"
                                        CssClass="btn btn-outline-danger" OnClick="btnConfirmaEliminar_Click" />
                                </div>
                                <% } %>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <br />
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="repRepetidorFavoritos" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%></h5>
                            <p class="card-text"><%#Eval("Descripcion")%></p>
                            <p class="card-text"><%#Eval("Marca")%></p>
                            <p class="card-text"><%#Eval("Categoria")%></p>
                            <p class="card-text"><%#Eval("Precio")%></p>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
