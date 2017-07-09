using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebApp.Data.Contratos;
using WebApp.Models;

namespace WebApp.Data.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : Entidad, new()
    {
        public void Actualizar(T entidad)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(entidad).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Agregar(T entidad)
        {
            using (var db = new ApplicationDbContext())
            {
                entidad.FechaCreacion = DateTime.Now;
                db.Entry(entidad).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var entidad = new T() { Id = id };
                db.Entry(entidad).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public IEnumerable<T> EncontrarPor(ParametrosDeQuery<T> parametrosDeQuery)
        {
            var orderByClass = ObtenerOrderBy(parametrosDeQuery);
            Expression<Func<T, bool>> whereTrue = x => true;
            var where = (parametrosDeQuery.Where == null) ? whereTrue : parametrosDeQuery.Where;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (orderByClass.IsAscending)
                {
                    return db.Set<T>().Where(where).OrderBy(orderByClass.OrderBy)
                    .Skip((parametrosDeQuery.Pagina - 1) * parametrosDeQuery.Top)
                    .Take(parametrosDeQuery.Top).ToList();
                }
                else
                {
                    return db.Set<T>().Where(where).OrderByDescending(orderByClass.OrderBy)
                    .Skip((parametrosDeQuery.Pagina - 1) * parametrosDeQuery.Top)
                    .Take(parametrosDeQuery.Top).ToList();
                }
                
            }
        }

        private OrderByClass ObtenerOrderBy(ParametrosDeQuery<T> parametrosDeQuery)
        {
            if (parametrosDeQuery.OrderBy == null && parametrosDeQuery.OrderByDescending == null)
            {
                return new OrderByClass(x => x.Id, true);
            }

            return (parametrosDeQuery.OrderBy != null) 
                ? new OrderByClass(parametrosDeQuery.OrderBy, true) : 
                new OrderByClass(parametrosDeQuery.OrderByDescending, false);
        }

        public T ObtenerPorId(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Set<T>().FirstOrDefault(x => x.Id == id);
            }
        }

        public int Contar(Expression<Func<T, bool>> where)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Set<T>().Where(where).Count();
            }
        }

        private class OrderByClass
        {

            public OrderByClass()
            {

            }

            public OrderByClass(Func<T, object> orderBy, bool isAscending)
            {
                OrderBy = orderBy;
                IsAscending = isAscending;
            }
            

            public Func<T, object> OrderBy { get; set; }
            public bool IsAscending { get; set; }
        }
    }
}