using api.adm.gestaosala.core.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace api.adm.gestaosala.core.providers
{
    public interface IUsuarioProvider
    {
        Task<Usuario> Insert(Usuario usuario);
        Task<bool> GetUsuarioByLogin(string login, string senha);
    }
}
