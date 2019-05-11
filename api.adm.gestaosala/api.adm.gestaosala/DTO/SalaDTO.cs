using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable CS1591
namespace api.adm.gestaosala.DTO
{
    public class SalaDTO
    {
        /// <summary>
        /// Título da Sala
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "Título Obrigatório")]
        public string SalaTitulo { get; set; }

        /// <summary>
        /// Descrição da Sala
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "Descrição Obrigatório")]
        public string SalaDescricao { get; set; }
    }
}
#pragma warning disable CS1591