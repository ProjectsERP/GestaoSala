using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using api.adm.gestaosala.core.manager.agenda;
using api.adm.gestaosala.core.models.agenda;
using api.adm.gestaosala.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace api.adm.gestaosala.Controllers
{
#pragma warning disable CS1591

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AgendaSalaController : BaseController
    {
        private readonly IAgendaSalaManager _agendaSalaManager;

        public AgendaSalaController(IAgendaSalaManager agendaSalaManager, IMapper mapper) : base(mapper)
        {
            _agendaSalaManager = agendaSalaManager;
        }

        /// <summary>
        ///  busca todas salas agendadas na base
        /// </summary>   
        /// <returns></returns>       
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Registros localizados", Type = typeof(AgendaSalaDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _agendaSalaManager.GetAgendaSala());
        }

        /// <summary>
        ///  insere um agendamento
        /// </summary>
        /// <param name="agendaSalaDTO">agendamento</param>     
        /// <returns></returns>       
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Inserido com Sucesso", Type = typeof(AgendaSalaDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> Post([FromBody()] AgendaSalaDTO agendaSalaDTO)
        {
            return Ok(await _agendaSalaManager.Insert(_mapper.Map<AgendaSalaModel>(agendaSalaDTO)));
        }

        /// <summary>
        ///  busca salas agendadas na base pelo id da sala e data de agendamento
        /// </summary>   
        /// <returns></returns>       
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Registros localizados", Type = typeof(AgendaSalaDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<bool> GetSalaAgendada([FromBody()] AgendaSalaDTO agendaSalaDTO)
        {
            var agendado = Ok(await _agendaSalaManager.GetVerificaAgendamento(_mapper.Map<AgendaSalaModel>(agendaSalaDTO)));
            if (agendado.StatusCode >= 400 || (bool)agendado.Value == false)
            {
                return false;
            }
            return true;
        }

        [HttpDelete("{agendamentoSalaId}/{salaId}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Registro Deletado", Type = null)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> Delete(int agendamentoSalaId, int salaId)
        {
            return Ok(await _agendaSalaManager.Delete(agendamentoSalaId, salaId));
        }
    }
#pragma warning disable CS1591
}