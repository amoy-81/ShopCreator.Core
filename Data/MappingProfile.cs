using AutoMapper;
using ShopCreator.Core.DTO;
using ShopCreator.Core.Models;

namespace ShopCreator.Core.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Shop, ShopDto>();
            CreateMap<Template, TemplateDto>();
        }
    }
}
