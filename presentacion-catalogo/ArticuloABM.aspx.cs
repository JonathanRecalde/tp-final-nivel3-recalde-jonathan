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
    public partial class ArticuloABM : System.Web.UI.Page
    {
        public bool ConfirmaEliiminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmaEliiminacion = false;
            txtId.Enabled = false;
            try
            {

                if (!IsPostBack)
                {
                    //configuración inicial de la pantalla
                    MarcaNegocio negocioMarca = new MarcaNegocio();
                    CategoriaNegocio negocioCategoria = new CategoriaNegocio();
                    List<Marca> listaMarcas = negocioMarca.listar();
                    List<Categoria> listaCategorias = negocioCategoria.listar();

                    //Cagar los ddl y configurar clave-valor

                    ddlMarca.DataSource = listaMarcas;
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataBind();

                    ddlCategoria.DataSource = listaCategorias;
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();
                    btnEliminar.Visible = false;
                }
                //configuración si vamos por modificar

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : null;
                
                if (id!=null && !IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Articulo seleccionado = (negocio.listar(id))[0];
                    Session.Add("articuloSeleccionado", seleccionado);

                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    txtImagenUrl.Text = seleccionado.ImagenUrl;
                    txtImagenUrl_TextChanged(sender, e);
                    btnEliminar.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                //Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgImagen.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validacion.textoVacio(txtCodigo) || Validacion.textoVacio(txtNombre) || Validacion.textoVacio(ddlMarca) || Validacion.textoVacio(txtPrecio))
                {
                    Session.Add("error", "Complete todos los campos obligatorios...");
                    Response.Redirect("Error.aspx");
                }
                
                if (!(Validacion.soloNros(txtPrecio.Text)))
                {
                    Session.Add("Error","Ingrese solo nros en el campo Precio...");
                    Response.Redirect("Error.aspx");
                }
                Articulo nuevo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.ImagenUrl = txtImagenUrl.Text;
                
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                nuevo.Precio = decimal.Parse(txtPrecio.Text);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificarConSp(nuevo);
                }
                else
                    negocio.agregarConSp(nuevo);
                
                Response.Redirect("ListaArticulos.aspx", false);
            }
            catch(System.Threading.ThreadAbortException ex) { }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliiminacion = true;
        }

        protected void btnConfirmaEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaEliminar.Checked)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("ListaArticulos.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo seleccionado = new Articulo();
                seleccionado = (Articulo)Session["articuloSeleccionado"];

                //negocio.eliiminarLogico(seleccionado.Id, !seleccionado.Activo);
                Response.Redirect("ListaArticulos.aspx", false);
                
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }
    }
}