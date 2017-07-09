using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    [System.Diagnostics.DebuggerDisplay("Nombre: {Nombre}. Edad: {Edad}")]
    public class Persona: Entidad
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public bool Validar()
        {
            if (Edad < 18)
            {
                return false;
            }

            if (string.IsNullOrEmpty(Nombre))
            {
                return false;
            }

            return true;
        }
    }
}