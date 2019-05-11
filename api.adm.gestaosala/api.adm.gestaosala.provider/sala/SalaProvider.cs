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
