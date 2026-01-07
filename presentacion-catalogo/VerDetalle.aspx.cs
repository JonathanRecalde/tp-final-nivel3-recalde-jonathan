using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace presentacion_catalogo
{
    public partial class VerDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                string id = Request.QueryString["id"];

                List<Articulo> listaFiltrada = negocio.listar(id);

                Articulo seleccionado = (listaFiltrada)[0];
                lblNombre.Text = ": " + seleccionado.Nombre;
                lblDescripcion.Text = ": " + seleccionado.Descripcion;
                lblMarca.Text = ": " + seleccionado.Marca.Descripcion;
                lblCategoria.Text = ": " + seleccionado.Categoria.Descripcion;
                lblPrecio.Text = ": " + seleccionado.Precio.ToString();
                imgImagen.ImageUrl = seleccionado.ImagenUrl;

            }
        }
    }
}