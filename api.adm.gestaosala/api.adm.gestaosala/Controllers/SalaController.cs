using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using api.adm.gestaosala.core.manager.sala;
using api.adm.gestaosala.core.models.sala;
using api.adm.gestaosala.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace api.adm.gestaosala.Controllers
{
#pragma warning disable CS1591

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SalaController : BaseController
    {
        private readonly ISalaManager _salaManager;
       
        public SalaController(ISalaManager salaManager, IMapper mapper): base(mapper)
        {
            _salaManager = salaManager;
        }

        /// <summary>
        ///  Post para inserir nova sala
        /// </summary>
        /// <param name="salaDTO">Cadastro de nova sala</param>     
        /// <returns></returns>       
        [HttpPost]
        [AllowAnonymous]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Inserido com Sucesso", Type = typeof(SalaDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> Post([FromBody()] SalaDTO salaDTO)
        {
            return Ok(await _salaManager.Insert(_mapper.Map<Sala>(salaDTO)));
        }
    }
}
#pragma warning disable CS1591