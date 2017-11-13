using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DAO
{
    public class UsuarioRepository : BaseRepository<Usuario>
    {
        public Usuario BuscaPorLogin(string login, string senha)
        {
            using (var contexto = new RedeComercialContext())
            {
                return contexto.Usuarios.FirstOrDefault(u => u.Nome == login && u.Senha == senha);
            }
        }
        public Usuario BuscaPorNome(string login)
        {
            using (var contexto = new RedeComercialContext())
            {
                return contexto.Usuarios.FirstOrDefault(u => u.Nome == login);
            }
        }
    }
}