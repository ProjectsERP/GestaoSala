using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using api.adm.gestaosala.core.models.agenda;
using api.adm.gestaosala.core.providers;

namespace api.adm.gestaosala.core.manager.agenda
{
    public class AgendaSalaManager : IAgendaSalaManager
    {
        private readonly IAgendaSalaProvider _agendaSalaProvider;

        public AgendaSalaManager(IAgendaSalaProvider agendaSalaProvider)
        {
            _agendaSalaProvider = agendaSalaProvider;
        }

        public async Task<int> Delete(int agendamentoId, int salaId)
        {
            try
            {
                var salaManager = (await _agendaSalaProvider.Delete(agendamentoId, salaId));
                return salaManager;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IList<AgendaSalaModel>> GetAgendaSala()
        {
            try
            {
                var salaManager = (await _agendaSalaProvider.GetAgendaSala());
                return salaManager;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> GetVerificaAgendamento(AgendaSalaModel agendaSalaModel)
        {
            try
            {
                bool agendado = (await _agendaSalaProvider.GetVerificaAgendamento(agendaSalaModel));
                return agendado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AgendaSalaModel> Insert(AgendaSalaModel agendaSala)
        {
            try
            {
                var agendasalaManager = await _agendaSalaProvider.Insert(agendaSala);
                return agendasalaManager;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
