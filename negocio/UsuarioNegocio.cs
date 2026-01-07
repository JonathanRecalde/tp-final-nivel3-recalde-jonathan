using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class UsuarioNegocio
    {
        public int insertarNuevo(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedInsertarNuevo");
                datos.setearParametros("@email", nuevo.Email);
                datos.setearParametros("@pass", nuevo.Pass);

                return datos.ejecutarAccionScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public bool login(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id, email, pass, nombre, apellido, urlImagenPerfil, admin From USERS Where email = @email and pass = @pass");
                datos.setearParametros("@email", usuario.Email);
                datos.setearParametros("@pass", usuario.Pass);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.Admin = (bool)datos.Lector["admin"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        usuario.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        usuario.Apellido = (string)datos.Lector["apellido"];
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        usuario.ImagenPerfil = (string)datos.Lector["urlImagenPerfil"];
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void actualizar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedModificarPerfil");
                datos.setearParametros("@nomb", usuario.Nombre);
                datos.setearParametros("@apell", usuario.Apellido);
                datos.setearParametros("@img", (object)usuario.ImagenPerfil??DBNull.Value);
                datos.setearParametros("@id", usuario.Id);
                datos.ejecutarLectura();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void insertarFavorito(int idUser, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedInsertarFavorito");
                datos.setearParametros("@iduser", idUser);
                datos.setearParametros("@idArt", idArticulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void eliminarFavorito(int idUser, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedEliminarFavorito");
                datos.setearParametros("@idUser", idUser);
                datos.setearParametros("@idArt", idArticulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
