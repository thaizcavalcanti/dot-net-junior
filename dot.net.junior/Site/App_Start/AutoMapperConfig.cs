using AutoMapper;
using Model.Entidades.Entidades;
using Model.Entidades.Model;

namespace Site
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {

        }

        protected override void Configure()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap()
                .ForMember(dest => dest.Endereco, opt => opt.Ignore())
                .ForMember(dest => dest.TelefoneCelular, opt => opt.Ignore());
        }
    }
}