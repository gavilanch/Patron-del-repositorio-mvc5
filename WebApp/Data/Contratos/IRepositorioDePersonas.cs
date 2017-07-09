using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebApp.Data.Repositorios;
using WebApp.Models;

namespace WebApp.Data.Contratos
{
    public interface IRepositorioDePersonas: IRepositorio<Persona>
    {
        void AccionEspecificaDePersonas(Persona persona);
    }
}