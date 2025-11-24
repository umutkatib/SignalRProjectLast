using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entitites;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AboutsController : ControllerBase
	{
		private readonly IAboutService _aboutService;
		private readonly IMapper _mapper;

		public AboutsController(IAboutService aboutService, IMapper mapper)
		{
			_aboutService = aboutService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult AboutList()
		{
			var values = _mapper.Map<List<ResultAboutDto>>(_aboutService.TGetListAll());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult AboutCreate(CreateAboutDto createAboutDto)
		{
			About about = new About()
			{
				AboutTitle = createAboutDto.AboutTitle,
				AboutDescription = createAboutDto.AboutDescription,
				AboutImageUrl = createAboutDto.AboutImageUrl,
			};
			_aboutService.TAdd(about);
			return Ok("About has added successfully!");
		}

		[HttpDelete("{id}")]
		public IActionResult AboutDelete(int id)
		{
			var value = _aboutService.TGetById(id);
			_aboutService.TDelete(value);
			return Ok("About has deleted successfully!");
		}

		[HttpGet("{id}")]
		public IActionResult AboutGet(int id)
		{
			var value = _aboutService.TGetById(id);
			return Ok(value);
		}

		[HttpPut]
		public IActionResult AboutUpdate(UpdateAboutDto updateAboutDto)
		{
			About about = new About()
			{
				AboutID = updateAboutDto.AboutID,
				AboutTitle = updateAboutDto.AboutTitle,
				AboutDescription = updateAboutDto.AboutDescription,
				AboutImageUrl = updateAboutDto.AboutImageUrl,
			};
			_aboutService.TUpdate(about);
			return Ok("About has updated successfully!");
		}
	}
}
