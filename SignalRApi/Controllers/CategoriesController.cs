using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entitites;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

		public CategoriesController(ICategoryService categoryService, IMapper mapper)
		{
			_categoryService = categoryService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult CategoryList()
		{
			var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CategoryCreate(CreateCategoryDto createCategoryDto)
		{
			_categoryService.TAdd(new Category()
			{
				CategoryName = createCategoryDto.CategoryName,
				CategoryStatus = true
			});
			return Ok("Category has added successfully!");
		}

		[HttpDelete("{id}")]
		public IActionResult CategoryDelete(int id)
		{
			var value = _categoryService.TGetById(id);
			_categoryService.TDelete(value);
			return Ok("Category has deleted successfully!");
		}

		[HttpGet("{id}")]
		public IActionResult CategoryGet(int id)
		{
			var value = _categoryService.TGetById(id);
			return Ok(value);
		}

		[HttpPut]
		public IActionResult CategoryUpdate(UpdateCategoryDto updateCategoryDto)
		{
			_categoryService.TUpdate(new Category()
			{
				CategoryID = updateCategoryDto.CategoryID,
				CategoryName = updateCategoryDto.CategoryName,
				CategoryStatus = updateCategoryDto.CategoryStatus,
			});
			return Ok("Category has updated successfully!");
		}
	}
}
