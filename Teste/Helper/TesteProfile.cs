using AutoMapper;
using Domain.Dtos;
using Data.Entities;

namespace Teste
{
    public class TesteProfile : Profile
    {
        public MapperConfiguration Configure()
        {
            return
            new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Produto, ProdutoDto>()
                .ForMember(
                    dest => dest.Descricao,
                    opt => opt.MapFrom(src => $"{src.Tipo} {src.Cor} - {src.Tamanho}")
                );

                cfg.CreateMap<Venda, VendaDto>().ReverseMap();
                cfg.CreateMap<Estoque, EstoqueDto>().ReverseMap();
                cfg.CreateMap<Carrinho, CarrinhoDto>().ReverseMap();
                cfg.CreateMap<Usuario, UsuarioDto>().ReverseMap();
            });
        }
    }
}
