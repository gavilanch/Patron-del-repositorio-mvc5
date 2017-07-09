using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Helpers
{
    public static class HTMLHelpers
    {
        public static string Truncar(this HtmlHelper helper, string valor, int numeroDeCaracteres)
        {
            if (valor.Length <= numeroDeCaracteres)
            {
                return valor;
            }
            else
            {
                return valor.Substring(0, numeroDeCaracteres) + "...";
            }
        }
    }
}