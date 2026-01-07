using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace presentacion_catalogo
{
    public static class Validacion
    {
        public static bool textoVacio(object control)
        {
            if (control is TextBox texto)
            {
                if (string.IsNullOrEmpty(texto.Text))
                    return true;
                else
                    return false;
            }
            return false;
        }
        public static bool soloNros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                    return false;
            }
            return true;
        }
    }
}