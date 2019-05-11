using api.adm.gestaosala.core.models.sala;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace api.adm.gestaosala.core.manager.sala
{
    public interface ISalaManager
    {
        Task<Sala> Insert(Sala sala);
    }

}
