using AutoMapper;
using Teste.Confitec.Domain.Confitec.Usuario;
using Teste.Confitec.Domain.Confitec.Usuario.Dto;
using Teste.Confitec.Domain.Extensions;

namespace Teste.Confitec.Infra.Injection.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuariosParaExibicaoDto>()
                .ForMember(p => p.EscolaridadeDescricao, o => o.MapFrom(_ => _.Escolaridade.GetEnumDescription()))
                .ForMember(p => p.NomeCompleto, o => o.MapFrom(_ => $"{_.Nome} {_.Sobrenome}"))
                .ForMember(p => p.DataNascimentoFormatada, o => o.MapFrom(_ => _.DataNascimento.ToString("dd/MM/yyyy")));

            CreateMap<Usuario, UsuarioDto>()
                .ForMember(p => p.EscolaridadeDescricao, o => o.MapFrom(_ => _.Escolaridade.GetEnumDescription()))
                .ForMember(p => p.NomeCompleto, o => o.MapFrom(_ => $"{_.Nome} {_.Sobrenome}"))
                .ForMember(p => p.DataNascimentoFormatada, o => o.MapFrom(_ => _.DataNascimento.ToString("dd/MM/yyyy")));
        }
    }
}
