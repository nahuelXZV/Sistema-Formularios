using Domain.DTOs.Segurity.Request;
using Domain.Entities.Segurity;
using AutoMapper;
using Domain.DTOs.Segurity;
using Domain.Entities.Forms;
using Domain.DTOs.Forms;
using Domain.Entities.Configuration;
using Domain.DTOs.Configuration;

namespace Application.Mapping;

public class GeneralProfile : Profile
{
    public GeneralProfile()
    {
        #region Entity To DTO
        CreateMap<Usuario, RequestRegisterDTO>();
        CreateMap<Usuario, UsuarioDTO>()
         .ForMember(dest => dest.Password, opt => opt.Ignore());

        CreateMap<Perfil, PerfilDTO>();
        CreateMap<PerfilAcceso, PerfilAccesoDTO>();
        CreateMap<Acceso, AccesoDTO>();
        CreateMap<Modulo, ModuloDTO>();
        CreateMap<Gestion, GestionDTO>();
        CreateMap<Entidad, EntidadDTO>();
        CreateMap<Pregunta, PreguntaDTO>();
        CreateMap<Formulario, FormularioDTO>()
            .ForMember(dest => dest.ListaPreguntas, opt => opt.MapFrom(src => src.ListaPreguntas));
        CreateMap<Concepto, ConceptoDTO>();
        #endregion

        #region  DTO To Entity
        CreateMap<RequestRegisterDTO, Usuario>();
        CreateMap<UsuarioDTO, Usuario>();
        CreateMap<PerfilDTO, Perfil>();
        CreateMap<PerfilAccesoDTO, PerfilAcceso>();
        CreateMap<AccesoDTO, Acceso>();
        CreateMap<ModuloDTO, Modulo>();
        CreateMap<GestionDTO, Gestion>();
        CreateMap<EntidadDTO, Entidad>();
        CreateMap<PreguntaDTO, Pregunta>();
        CreateMap<FormularioDTO, Formulario>()
         .ForMember(dest => dest.ListaPreguntas, opt => opt.MapFrom(src => src.ListaPreguntas));
        CreateMap<ConceptoDTO, Concepto>();
        #endregion

    }
}
