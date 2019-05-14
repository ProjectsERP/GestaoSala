using api.adm.gestaosala.core.models.agenda;
using api.adm.gestaosala.core.models.sala;
using api.adm.gestaosala.core.providers;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace api.adm.gestaosala.provider.agenda
{
    public class AgendaSalaProvider : IAgendaSalaProvider
    {
       
        public async Task<int> Delete(int agendamentoId, int salaId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Configuration.Conn()))
                {
                    conn.Open();

                    var queryParameters = new DynamicParameters();

                    queryParameters.Add("@agendamentoId", agendamentoId);
                    queryParameters.Add("@salaId", salaId);

                    salaId = await conn.ExecuteScalarAsync<int>("DeleteAgendamentoSala", param: queryParameters,
                                                                     commandType: CommandType.StoredProcedure);
                    return salaId;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IList<AgendaSalaModel>> GetAgendaSala()
        {
            IList<AgendaSalaModel> agendasalas = new List<AgendaSalaModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(Configuration.Conn()))
                {
                    conn.Open();
                    agendasalas = (await conn.QueryAsync<AgendaSalaModel>("GetAgendamentoSala", null, commandType: CommandType.StoredProcedure)).AsList();

                    return agendasalas;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> GetVerificaAgendamento(AgendaSalaModel agendaSalaModel)
        {
            bool agendado = false;
            var parameters = new DynamicParameters();
            parameters.Add("@salaId", agendaSalaModel.SalaId);
            parameters.Add("@DataInicial", agendaSalaModel.AgendamentoInicial);
            parameters.Add("@DataFinal", agendaSalaModel.AgendamentoFinal);

            try
            {
                using (SqlConnection conn = new SqlConnection(Configuration.Conn()))
                {
                    conn.Open();
                    agendado = (await conn.ExecuteScalarAsync<bool>("VerificaAgendamentoSala", parameters, commandType: CommandType.StoredProcedure));

                    return agendado;
                }
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
                using (SqlConnection conn = new SqlConnection(Configuration.Conn()))
                {
                    conn.Open();

                    var queryParameters = new DynamicParameters();

                    queryParameters.Add("@SalaId", agendaSala.SalaId);
                    queryParameters.Add("@AgendamentoInicial", agendaSala.AgendamentoInicial);
                    queryParameters.Add("@AgendamentoFinal", agendaSala.AgendamentoFinal);
                    queryParameters.Add("@AgendamentoStatus", true);

                    agendaSala.SalaId = await conn.ExecuteScalarAsync<int>("AddAgendamentoSala", param: queryParameters,
                                                                     commandType: CommandType.StoredProcedure);
                    return agendaSala;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
