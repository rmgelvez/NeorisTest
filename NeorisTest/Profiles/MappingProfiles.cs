using AutoMapper;
using Core.Entities;
using NeorisTest.Dtos;

namespace NeorisTest.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Persona, PersonaDto>()
           .ReverseMap();

            CreateMap<Cliente, ClienteDto>()
            .ReverseMap();

            CreateMap<Cuenta, CuentaDto>()
                .ReverseMap();

            CreateMap<Movimiento, MovimientoDto>()
                .ReverseMap();

            CreateMap<Cuenta, CuentaAddUptadeDto>()
            //.ForMember(dest => dest.ClienteId, origen => origen.MapFrom(origen => origen.Cliente.Id))
            .ReverseMap()
            .ForMember(origen => origen.Cliente, dest => dest.Ignore());

            CreateMap<Movimiento, MovimientoAddUpdateDto>()
            //.ForMember(dest => dest.CuentaId, origen => origen.MapFrom(origen => origen.Cuenta.Id))
            .ReverseMap()
            .ForMember(origen => origen.Cuenta, dest => dest.Ignore());
        }
    }
}
