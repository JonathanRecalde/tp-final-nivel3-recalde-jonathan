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
    public partial class MiMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";

            if (!(Page is Login || Page is Default || Page is Error || Page is Registro))
            {
                if (!Seguridad.sesionActiva(Session["usuarioActivo"]))
                    Response.Redirect("Login.aspx", false);
                else
                {
                    Usuario usuario = (Usuario)Session["usuarioActivo"];
                    lblUser.Text = usuario.Email;
                    if (!string.IsNullOrEmpty(usuario.ImagenPerfil))
                        imgAvatar.ImageUrl = "~/Images/" + usuario.ImagenPerfil;
                }
            }

            if (Seguridad.sesionActiva(Session["usuarioActivo"]))
            {
                Usuario usuario = (Usuario)Session["usuarioActivo"];
                lblUser.Text = usuario.Email;
                if (!string.IsNullOrEmpty(usuario.ImagenPerfil))
                    imgAvatar.ImageUrl = "~/Images/" + usuario.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                else
                    imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }
    }
}