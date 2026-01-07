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
    public partial class Favoritos : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Usuario usuario = (Usuario)Session["usuarioActivo"];
                Session.Add("articulosFavoritos", negocio.listarFavoritos(usuario.Id));

                dgvFavoritos.DataSource = Session["articulosFavoritos"];
                dgvFavoritos.DataBind();

                repRepetidorFavoritos.DataSource = Session["articulosFavoritos"];
                repRepetidorFavoritos.DataBind();
                
            }
        }
        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaEliminar.Checked)
                {
                    Usuario usuario = (Usuario)Session["usuarioActivo"];
                    int idArticulo = (int)Session["idArticulo"];
                    UsuarioNegocio negocio = new UsuarioNegocio();

                    negocio.eliminarFavorito(usuario.Id, idArticulo);
                    Response.Redirect("Default.aspx");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void dgvFavoritos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idArticulo = int.Parse(dgvFavoritos.SelectedDataKey.Value.ToString());
            Session.Add("idArticulo", idArticulo);
            ConfirmaEliminacion = true;
        }
    }
}