using api.adm.gestaosala.core.manager.usuario;
using api.adm.gestaosala.core.models;
using api.adm.gestaosala.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Net;
using System.Threading.Tasks;


namespace api.adm.gestaosala.Controllers
{
#pragma warning disable CS1591

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioManager _usuarioManager;

        public UsuarioController(IUsuarioManager usuarioManager, IMapper mapper) : base(mapper)
        {
            _usuarioManager = usuarioManager;
        }

        /// <summary>
        ///  usuario para colsulta de login
        /// </summary>
        /// <param name="usuario">usuario para consulta de login</param>     
        /// <returns></returns>       
        [HttpPost]
        [AllowAnonymous]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Encontrado", Type = typeof(LoginDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<bool> GetLogin([FromBody()] LoginDTO usuario)
        {
            // usar sha256 aqui

            var logado = Ok(await _usuarioManager.GetUsuariobyLogin(usuario.Login, usuario.Senha));
            if (logado.StatusCode >= 400 || (bool)logado.Value == false)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        ///  Insere um novo cliente para cadastro
        /// </summary>
        /// <param name="usuario">novo cliente que será inserido na base para cadastro</param>     
        /// <returns>retorna um objeto Cliente</returns>       
        [HttpPost]
        [AllowAnonymous]
        [Produces(typeof(UsuarioDTO))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Inserido com sucesso", Type = typeof(UsuarioDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> Insert([FromBody()] UsuarioDTO usuario)
        {
            //  return NotFound();
            return Ok(await _usuarioManager.Insert(_mapper.Map<Usuario>(usuario)));
        }
    }

#pragma warning restore CS1591
}