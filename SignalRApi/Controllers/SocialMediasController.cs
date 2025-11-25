using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entitites;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SocialMediasController : ControllerBase
	{
		private readonly ISocialMediaService _socialMediaService;
		private readonly IMapper _mapper;

		public SocialMediasController(ISocialMediaService socialMediaService, IMapper mapper)
		{
			_socialMediaService = socialMediaService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult SocialMediaList()
		{
			var values = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult SocialMediaCreate(CreateSocialMediaDto createSocialMediaDto)
		{
			SocialMedia socialMedia = new SocialMedia()
			{
				SocialMediaTitle = createSocialMediaDto.SocialMediaTitle,
				SocialMediaIcon = createSocialMediaDto.SocialMediaIcon,
				SocialMediaUrl = createSocialMediaDto.SocialMediaUrl,
			};
			_socialMediaService.TAdd(socialMedia);
			return Ok("Social Media has added successfully!");
		}

		[HttpDelete("{id}")]
		public IActionResult SocialMediaDelete(int id)
		{
			var value = _socialMediaService.TGetById(id);
			_socialMediaService.TDelete(value);
			return Ok("Social Media has deleted successfully!");
		}

		[HttpGet("{id}")]
		public IActionResult SocialMediaGet(int id)
		{
			var value = _socialMediaService.TGetById(id);
			return Ok(value);
		}

		[HttpPut]
		public IActionResult SocialMediaUpdate(UpdateSociaMediaDto updateSociaMediaDto)
		{
			SocialMedia socialMedia = new SocialMedia()
			{
				SocialMediaID = updateSociaMediaDto.SocialMediaID,
				SocialMediaTitle = updateSociaMediaDto.SocialMediaTitle,
				SocialMediaIcon = updateSociaMediaDto.SocialMediaIcon,
				SocialMediaUrl = updateSociaMediaDto.SocialMediaUrl,
			};
			_socialMediaService.TUpdate(socialMedia);
			return Ok("Social Media has updated successfully!");
		}
	}
}
