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
        ///  cadastra uma sala nova
        /// </summary>
        /// <param name="salaDTO">Cadastro de nova sala</param>     
        /// <returns></returns>       
        [HttpPost]
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


        /// <summary>
        ///  busca salas na base
        /// </summary>   
        /// <returns></returns>       
       
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Registros localizados", Type = typeof(Sala))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _salaManager.GetSalas());
        }

        /// <summary>
        ///  busca salas na base por id de sala
        /// </summary>   
        /// <returns></returns>       
        [HttpGet("{salaId}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Registros localizados", Type = typeof(Sala))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> Get(int salaId)
        {
            return Ok(await _salaManager.GetSalasBySalaId(salaId));
        }

        /// <summary>
        ///  Deleta uma Sala cadastrada por id
        /// </summary>   
        /// <returns></returns>       

        [HttpDelete("{salaId}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Registro Deletado", Type = null)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> Delete(int salaId)
        {
            return Ok(await _salaManager.Delete(salaId));
        }
    }
}
#pragma warning disable CS1591