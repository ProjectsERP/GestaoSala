using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.adm.gestaosala.core.manager.usuario;
using api.adm.gestaosala.core.models;
using Microsoft.AspNetCore.Mvc;

namespace api.adm.gestaosala.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioManager _usuarioManager;

        public UsuarioController(IUsuarioManager usuarioManager)
        {
            _usuarioManager = usuarioManager;
        }

        [HttpGet]
        public Task<IActionResult> Get()
        {
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody()] Usuario usuario)
        {
            try
            {
                return Ok(await _usuarioManager.Insert(usuario));
            }
            catch (Exception)
            {
                throw new Exception();
            }  
        }
    }
}