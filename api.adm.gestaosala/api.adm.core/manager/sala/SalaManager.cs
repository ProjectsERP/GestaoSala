using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using api.adm.gestaosala.core.models.sala;
using api.adm.gestaosala.core.providers;

namespace api.adm.gestaosala.core.manager.sala
{
    public class SalaManager : ISalaManager
    {
        private readonly ISalaProvider _salaProvider;

        public SalaManager(ISalaProvider salaProvider)
        {
            _salaProvider = salaProvider;
        }

        public async Task<Sala> Insert(Sala sala)
        {
            try
            {
                var salaManager = await _salaProvider.Insert(sala);
                return salaManager;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
