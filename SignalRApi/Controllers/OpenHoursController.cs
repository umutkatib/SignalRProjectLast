using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.OpenHourDto;
using SignalR.EntityLayer.Entitites;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OpenHoursController : ControllerBase
	{
		private readonly IOpenHourService _openHourService;
		private readonly IMapper _mapper;

		public OpenHoursController(IOpenHourService openHourService, IMapper mapper)
		{
			_openHourService = openHourService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult OpenHourList()
		{
			var values = _mapper.Map<List<ResultOpenHourDto>>(_openHourService.TGetListAll());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult OpenHourCreate(CreateOpenHourDto createOpenHourDto)
		{
			OpenHour openHour = new OpenHour()
			{
				OpenHourDays = createOpenHourDto.OpenHourHours,
				OpenHourHours = createOpenHourDto.OpenHourHours,
			};
			_openHourService.TAdd(openHour);
			return Ok("Open Hour has added successfully!");
		}

		[HttpDelete]
		public IActionResult OpenHourDelete(int id)
		{
			var value = _openHourService.TGetById(id);
			_openHourService.TDelete(value);
			return Ok("Open Hour has deleted successfully!");
		}

		[HttpGet("OpenHourGet")]
		public IActionResult OpenHourGet(int id)
		{
			var value = _openHourService.TGetById(id);
			return Ok(value);
		}

		[HttpPut]
		public IActionResult OpenHourUpdate(UpdateOpenHourDto updateOpenHourDto)
		{
			OpenHour openHour = new OpenHour()
			{
				OpenHourID = updateOpenHourDto.OpenHourID,
				OpenHourDays = updateOpenHourDto.OpenHourDays,
				OpenHourHours  = updateOpenHourDto.OpenHourHours,
			};
			_openHourService.TUpdate(openHour);
			return Ok("Open Hour has updated successfully!");
		}
	}
}
