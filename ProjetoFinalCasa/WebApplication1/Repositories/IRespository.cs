using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.DAO
{
    public interface IRepository<T>
    {
        void Adiciona(T modelo);
        void Atualiza(T modelo);
        T Busca(int id);
        IList<T> Lista();
        void Remove(int id);
    }
}