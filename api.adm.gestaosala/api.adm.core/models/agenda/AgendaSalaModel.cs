﻿using System;
using System.Collections.Generic;
using System.Text;

namespace api.adm.gestaosala.core.models.agenda
{
    public class AgendaSalaModel
    {
        public int AgendamentoId { get; set; }
        public int SalaId { get; set; }
        public DateTime AgendamentoInicial { get; set; }
        public DateTime AgendamentoFinal { get; set; }
        public bool AgendamentoStatus { get; set; }
    }
}
