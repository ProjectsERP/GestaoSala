using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using api.adm.gestaosala.core.models;
using api.adm.gestaosala.core.providers;

namespace api.adm.gestaosala.core.manager.usuario
{
    public class UsuarioManager : IUsuarioManager
    {
        private readonly IUsuarioProvider _usuarioProvider;

        public UsuarioManager(IUsuarioProvider usuarioProvider)
        {
            _usuarioProvider = usuarioProvider;
        }

        public async Task<bool> GetUsuariobyLogin(string login, string senha)
        {
            bool usuarioLogado = false;
            try
            {
                usuarioLogado = await _usuarioProvider.GetUsuarioByLogin(login, senha);
                return usuarioLogado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }          
        }

        public async Task<Usuario> Insert(Usuario usuario)
        {
            try
            {
                var usuarios = await _usuarioProvider.Insert(usuario);
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
