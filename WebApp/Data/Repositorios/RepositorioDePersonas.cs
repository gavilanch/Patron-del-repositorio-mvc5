using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebApp.Data.Contratos;
using WebApp.Models;

namespace WebApp.Data.Repositorios
{
    public class RepositorioDePersonas : Repositorio<Persona>, IRepositorioDePersonas
    {
        public void AccionEspecificaDePersonas(Persona persona)
        {
            throw new NotImplementedException();
        }
    }
}