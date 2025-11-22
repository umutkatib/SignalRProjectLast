using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entitites;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;

		public ProductsController(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult ProductList()
		{
			var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
			return Ok(values);
		}

		[HttpGet("ProductListWithCategory")]
		public IActionResult ProductListWithCategory()
		{
			var values = _mapper.Map<List<ResultProductWithCategory>>(_productService.TGetProductsWithCategories());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult ProductCreate(CreateProductDto createProductDto)
		{
			Product product = new Product()
			{
				ProductName = createProductDto.ProductName,
				ProductDescription = createProductDto.ProductDescription,
				ProductImageUrl = createProductDto.ProductImageUrl,
				ProductPrice = createProductDto.ProductPrice,
				ProductStatus = createProductDto.ProductStatus,
			};
			_productService.TAdd(product);
			return Ok("Product has added successfully!");
		}

		[HttpDelete]
		public IActionResult ProductDelete(int id)
		{
			var value = _productService.TGetById(id);
			_productService.TDelete(value);
			return Ok("Product has deleted successfully!");
		}

		[HttpGet("ProductGet")]
		public IActionResult ProductGet(int id)
		{
			var value = _productService.TGetById(id);
			return Ok(value);
		}

		[HttpPut]
		public IActionResult ProductUpdate(UpdateProductDto updateProductDto)
		{
			Product product = new Product()
			{
				ProductID = updateProductDto.ProductID,
				ProductName = updateProductDto.ProductName,
				ProductDescription = updateProductDto.ProductDescription,
				ProductImageUrl = updateProductDto.ProductImageUrl,
				ProductPrice = updateProductDto.ProductPrice,
				ProductStatus = updateProductDto.ProductStatus,
			};
			_productService.TUpdate(product);
			return Ok("Product has updated successfully!");
		}
	}
}
