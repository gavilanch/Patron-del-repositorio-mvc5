using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Direccion: Entidad
    {
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Calle { get; set; }
        // etc...
    }
}