using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.adm.gestaosala.DTO
{

#pragma warning disable CS1591
    public class UsuarioDTO
    {
        /// <summary>
        /// Nome de usuario
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "Nome Obrigatório")]
        public string Nome { get; set; }

        /// <summary>
        /// Login
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "Login Obrigatório")]
        public string Login { get; set; }

        /// <summary>
        /// Senha
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "Senha Obrigatório")]
        public string Senha { get; set; }
    }

#pragma warning disable CS1591
}
