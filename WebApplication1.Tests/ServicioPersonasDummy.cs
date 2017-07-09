using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Servicios;

namespace WebApplication1.Tests
{
    public class ServicioPersonasDummy : IServicioPersonas
    {
        public List<string> Errores { get; set; }

        public bool EsValido(Persona persona)
        {
            Errores = new List<string>();
            Errores.Add("Error");
            return false;
        }
    }
}
