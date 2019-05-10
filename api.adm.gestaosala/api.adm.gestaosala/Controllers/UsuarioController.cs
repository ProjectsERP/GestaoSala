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

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioManager _usuarioManager;

        public UsuarioController(IUsuarioManager usuarioManager, IMapper mapper) : base(mapper)
        {
            _usuarioManager = usuarioManager;
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