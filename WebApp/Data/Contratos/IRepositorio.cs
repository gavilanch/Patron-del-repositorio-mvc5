using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Data.Contratos
{
    public interface IRepositorio<T>
    {
        void Agregar(T entidad);
        void Eliminar(int id);
        void Actualizar(T entidad);
        int Contar(Expression<Func<T, bool>> where);
        T ObtenerPorId(int id);
        IEnumerable<T> EncontrarPor(ParametrosDeQuery<T> parametrosDeQuery);
    }
}
