using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entitites;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DiscountsController : ControllerBase
	{
		private readonly IDiscountService _discountService;
		private readonly IMapper _mapper;

		public DiscountsController(IDiscountService discountService, IMapper mapper)
		{
			_discountService = discountService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult DiscountList()
		{
			var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult DiscountCreate(CreateDiscountDto createDiscountDto)
		{
			Discount discount = new Discount()
			{
				DiscountTitle = createDiscountDto.DiscountTitle,
				DiscountAmount = createDiscountDto.DiscountAmount,
				DiscountDescription = createDiscountDto.DiscountDescription,
				DiscountImageUrl = createDiscountDto.DiscountImageUrl,
			};
			_discountService.TAdd(discount);
			return Ok("Discount has added successfully!");
		}

		[HttpDelete]
		public IActionResult DiscountDelete(int id)
		{
			var value = _discountService.TGetById(id);
			_discountService.TDelete(value);
			return Ok("Discount has deleted successfully!");
		}

		[HttpGet("DiscountGet")]
		public IActionResult DiscountGet(int id)
		{
			var value = _discountService.TGetById(id);
			return Ok(value);
		}

		[HttpPut]
		public IActionResult DiscountUpdate(UpdateDiscountDto updateDiscountDto)
		{
			Discount discount = new Discount()
			{
				DiscountID = updateDiscountDto.DiscountID,
				DiscountTitle = updateDiscountDto.DiscountTitle,
				DiscountAmount = updateDiscountDto.DiscountAmount,
				DiscountDescription = updateDiscountDto.DiscountDescription,
				DiscountImageUrl = updateDiscountDto.DiscountImageUrl,
			};
			_discountService.TUpdate(discount);
			return Ok("Discount has updated successfully!");
		}
	}
}
