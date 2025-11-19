using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entitites;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialsController : ControllerBase
	{
		private readonly ITestimonialService _testimonialService;
		private readonly IMapper _mapper;

		public TestimonialsController(ITestimonialService testimonialService, IMapper mapper)
		{
			_testimonialService = testimonialService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult TestimonialList()
		{
			var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult TestimonialCreate(CreateTestimonialDto createTestimonialDto)
		{
			Testimonial testimonial = new Testimonial()
			{
				TestimonialTitle = createTestimonialDto.TestimonialTitle,
				TestimonialName = createTestimonialDto.TestimonialName,
				TestimonialComment = createTestimonialDto.TestimonialComment,
				TestimonialImageUrl = createTestimonialDto.TestimonialImageUrl,
				TestimonialStatus = true,
			};
			_testimonialService.TAdd(testimonial);
			return Ok("Testimonial has added successfully!");
		}

		[HttpDelete]
		public IActionResult TestimonialDelete(int id)
		{
			var value = _testimonialService.TGetById(id);
			_testimonialService.TDelete(value);
			return Ok("Testimonial has deleted successfully!");
		}

		[HttpGet("TestimonialGet")]
		public IActionResult TestimonialGet(int id)
		{
			var value = _testimonialService.TGetById(id);
			return Ok(value);
		}

		[HttpPut]
		public IActionResult TestimonialUpdate(UpdateTestimonialDto updateTestimonialDto)
		{
			Testimonial testimonial = new Testimonial()
			{
				TestimonialID = updateTestimonialDto.TestimonialID,
				TestimonialTitle = updateTestimonialDto.TestimonialTitle,
				TestimonialName = updateTestimonialDto.TestimonialName,
				TestimonialComment = updateTestimonialDto.TestimonialComment,
				TestimonialImageUrl = updateTestimonialDto.TestimonialImageUrl,
				TestimonialStatus = updateTestimonialDto.TestimonialStatus,
			};
			_testimonialService.TUpdate(testimonial);
			return Ok("Testimonial has updated successfully!");
		}
	}
}
