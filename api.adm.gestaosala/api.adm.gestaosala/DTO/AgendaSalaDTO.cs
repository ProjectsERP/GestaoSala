using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.adm.gestaosala.DTO
{
#pragma warning disable CS1591
    public class AgendaSalaDTO
    {
        /// <summary>
        /// Id do agendamento
        /// </summary>
        /// <value></value>
        public int AgendamentoId { get; set; }

        /// <summary>
        /// Id da Sala
        /// </summary>
        /// <value></value>
        public int SalaId { get; set; }

        /// <summary>
        /// Data inicial
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "Data inicial Obrigatório")]
        public DateTime AgendamentoInicial { get; set; }

        /// <summary>
        /// Data final
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "Data final obrigatório")]
        public DateTime AgendamentoFinal { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        /// <value></value>      
        public bool AgendamentoStatus { get; set; }


    }
}
#pragma warning disable CS1591
