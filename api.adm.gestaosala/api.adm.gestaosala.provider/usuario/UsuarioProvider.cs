﻿using api.adm.gestaosala.core.models;
using api.adm.gestaosala.core.providers;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace api.adm.gestaosala.provider
{
    public class UsuarioProvider : IUsuarioProvider
    {
        public async Task<IList<Usuario>> GetUsuarioByLogin(string login, string senha)
        {
            var usuario = new List<Usuario>();
            var parameters = new DynamicParameters();
            parameters.Add("@login", login);
            parameters.Add("@senha", senha);

            try
            {
                using (SqlConnection conn = new SqlConnection(Configuration.Conn()))
                {
                    conn.Open();
                    usuario = (await conn.QueryAsync<Usuario>("GetUsuarioByLogin", parameters, commandType: CommandType.StoredProcedure)).AsList();

                    return usuario;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Usuario> Insert(Usuario usuario)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Configuration.Conn()))
                {
                    conn.Open();

                    var queryParameters = new DynamicParameters();

                    queryParameters.Add("@Nome", usuario.Nome);
                    queryParameters.Add("@Login", usuario.Login);
                    queryParameters.Add("@Senha", usuario.Senha);

                    usuario.Id = await conn.ExecuteScalarAsync<int>("AddUsuario", param: queryParameters,
                                                                            commandType: CommandType.StoredProcedure);
                    return usuario;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
