using api.adm.gestaosala.core.models;
using api.adm.gestaosala.core.models.agenda;
using api.adm.gestaosala.core.models.sala;
using api.adm.gestaosala.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.adm.gestaosala.Mappers
{
#pragma warning disable CS1591
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region mapeamentos

            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Sala, SalaDTO>().ReverseMap();
            CreateMap<AgendaSalaModel, AgendaSalaDTO>().ReverseMap();

            #endregion
        }
    }
#pragma warning restore CS1591
}
