using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Servicios
{
    public interface IServicioPersonas
    {
        bool EsValido(Persona persona);
        List<string> Errores { get;  set; }
    }
}
