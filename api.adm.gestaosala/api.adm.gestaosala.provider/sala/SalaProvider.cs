using api.adm.gestaosala.core.models.sala;
using api.adm.gestaosala.core.providers;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace api.adm.gestaosala.provider.sala
{
    public class SalaProvider : ISalaProvider
    {
        public async Task<int> Delete(int salaId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Configuration.Conn()))
                {
                    conn.Open();

                    var queryParameters = new DynamicParameters();

                    queryParameters.Add("@salaId", salaId);                 

                    salaId = await conn.ExecuteScalarAsync<int>("DeleteSalas", param: queryParameters,
                                                                     commandType: CommandType.StoredProcedure);
                    return salaId;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Sala> GetSalaBySalaId(int salaId)
        {
            var sala = new Sala();
            try
            {
                using (SqlConnection conn = new SqlConnection(Configuration.Conn()))
                {
                    conn.Open();

                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@salaId", salaId);

                    sala = (await conn.QuerySingleOrDefaultAsync<Sala>("GetSalasBySalaId", param: queryParameters, commandType: CommandType.StoredProcedure));

                    return sala;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IList<Sala>> GetSalas()
        {
            IList<Sala> salas =  new List<Sala>();
            try
            {
                using (SqlConnection conn = new SqlConnection(Configuration.Conn()))
                {
                    conn.Open();
                  
                    salas = (await conn.QueryAsync<Sala>("GetSalas", null, commandType: CommandType.StoredProcedure)).AsList();

                    return salas;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Sala> Insert(Sala sala)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Configuration.Conn()))
                {
                    conn.Open();

                    var queryParameters = new DynamicParameters();

                    queryParameters.Add("@SalaTitulo", sala.SalaTitulo);
                    queryParameters.Add("@SalaDescricao", sala.SalaDescricao);
                  
                   sala.SalaId = await conn.ExecuteScalarAsync<int>("AddSala", param: queryParameters,
                                                                    commandType: CommandType.StoredProcedure);
                    return sala;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
