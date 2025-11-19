using AutoMapper;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entitites;

namespace SignalRApi.Mapping
{
	public class CategoryMapping : Profile
	{
		public CategoryMapping()
		{
			CreateMap<Category, ResultCategoryDto>().ReverseMap();
			CreateMap<Category, CreateCategoryDto>().ReverseMap();
			CreateMap<Category, GetCategoryDto>().ReverseMap();
			CreateMap<Category, UpdateCategoryDto>().ReverseMap();
		}
	}
}
