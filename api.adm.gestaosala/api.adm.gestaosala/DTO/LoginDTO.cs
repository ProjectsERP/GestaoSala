using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable CS1591
namespace api.adm.gestaosala.DTO
{
    public class LoginDTO
    {
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
}
#pragma warning disable CS1591