using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.DAO
{
    public class BaseRepository<T> : IRepository<T>
        where T : class
    {
        public virtual void Adiciona(T modelo)
        {
            using (var contexto = new RedeComercialContext())
            {
                contexto.Set<T>().Add(modelo);
                contexto.SaveChanges();
            }
        }

        public virtual void Atualiza(T modelo)
        {
            using (var contexto = new RedeComercialContext())
            {
                contexto.Entry(modelo).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public virtual T Busca(int id)
        {
            using (var contexto = new RedeComercialContext())
            {
                return contexto.Set<T>().Find(id);
            }
        }

        public virtual IList<T> Lista()
        {
            using (var contexto = new RedeComercialContext())
            {
                return contexto.Set<T>().ToList();
            }
        }

        public virtual void Remove(int id)
        {
            using (var contexto = new RedeComercialContext())
            {
                contexto.Set<T>().Remove(contexto.Set<T>().Find(id));
                contexto.SaveChanges();
            }
        }
    }
}