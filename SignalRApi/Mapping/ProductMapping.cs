using AutoMapper;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entitites;

namespace SignalRApi.Mapping
{
	public class ProductMapping : Profile
	{
		public ProductMapping()
		{
			CreateMap<Product, ResultProductDto>().ReverseMap();
			CreateMap<Product, ResultProductWithCategory>()
				.ForMember(destinationMember : x => x.CategoryName, memberOptions : y => y.MapFrom(c => c.Category.CategoryName))
				.ReverseMap();
			CreateMap<Product, CreateProductDto>().ReverseMap();
			CreateMap<Product, GetProductDto>().ReverseMap();
			CreateMap<Product, UpdateProductDto>().ReverseMap();
		}
	}
}
