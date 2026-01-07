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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click1(object sender, EventArgs e)
        {

            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                if (Validacion.textoVacio(txtEmail) || Validacion.textoVacio(txtPassword))
                {
                    Session.Add("error","Debe completar todos los campos...");
                    Response.Redirect("Error.aspx");
                }
                
                usuario.Email = txtEmail.Text;
                usuario.Pass = txtPassword.Text;
                if (negocio.login(usuario))
                {
                    Session.Add("usuarioActivo", usuario);
                    Response.Redirect("MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "email o pass incorrectos");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}
