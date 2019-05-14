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

        public async Task<int> Delete(int salaId)
        {
            try
            {
                var salaManager = (await _salaProvider.Delete(salaId));
                return salaManager;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IList<Sala>> GetSalas()
        {
            try
            {
                var salaManager = (await _salaProvider.GetSalas());
                return salaManager;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Sala> GetSalasBySalaId(int salaId)
        {
            try
            {
                var salaManager = (await _salaProvider.GetSalaBySalaId(salaId));
                return salaManager;
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
