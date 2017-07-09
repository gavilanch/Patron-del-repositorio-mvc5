using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Servicios
{
    public class ServicioPersonas: IServicioPersonas
    {
        public List<string> Errores { get;  set; }

        public bool EsValido(Persona persona)
        {
            Errores = new List<string>();

            if (string.IsNullOrWhiteSpace(persona.Nombre))
            {
                Errores.Add("El nombre de la persona es un valor requerido");
            }

            if (persona.Edad > 200)
            {
                Errores.Add("La edad de la persona no puede ser mayor a 200");
            }

            if (persona.Edad < 0)
            {
                Errores.Add("La edad de la persona no puede ser menor que cero");
            }
            
            return !Errores.Any();

        }
    }
}