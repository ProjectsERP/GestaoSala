using api.adm.gestaosala.core.models.sala;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace api.adm.gestaosala.core.providers
{
    public interface ISalaProvider
    {
        Task<Sala> Insert(Sala sala);
    }
}
