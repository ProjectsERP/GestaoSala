using api.adm.gestaosala.core.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace api.adm.gestaosala.core.manager.usuario
{
    public interface IUsuarioManager
    {
        Task<Usuario> Insert(Usuario usuario);
    }
}
