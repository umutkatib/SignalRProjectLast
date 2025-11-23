using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entitites;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingsController : ControllerBase
	{
		private readonly IBookingService _bookingService;
		private readonly IMapper _mapper;

		public BookingsController(IBookingService bookingService, IMapper mapper)
		{
			_bookingService = bookingService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult BookingList()
		{
			var values = _mapper.Map<List<ResultBookingDto>>(_bookingService.TGetListAll());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult BookingCreate(CreateBookingDto createBookingDto)
		{
			Booking booking = new Booking()
			{
				BookingMail = createBookingDto.BookingMail,
				BookingDate = createBookingDto.BookingDate,
				BookingName = createBookingDto.BookingName,
				BookingPersonCount = createBookingDto.BookingPersonCount,
				BookingPhone = createBookingDto.BookingPhone,
			};
			_bookingService.TAdd(booking);
			return Ok("Booking has added successfully!");
		}

		[HttpDelete]
		public IActionResult BookingDelete(int id)
		{
			var value = _bookingService.TGetById(id);
			_bookingService.TDelete(value);
			return Ok("Booking has deleted successfully!");
		}

		[HttpGet("BookingGet")]
		public IActionResult BookingGet(int id)
		{
			var value = _bookingService.TGetById(id);
			return Ok(value);
		}

		[HttpPut]
		public IActionResult BookingUpdate(UpdateBookingDto updateBookingDto)
		{
			Booking booking = new Booking()
			{
				BookingID = updateBookingDto.BookingID,
				BookingMail = updateBookingDto.BookingMail,
				BookingDate = updateBookingDto.BookingDate,
				BookingName = updateBookingDto.BookingName,
				BookingPersonCount = updateBookingDto.BookingPersonCount,
				BookingPhone = updateBookingDto.BookingPhone,
			};
			_bookingService.TUpdate(booking);
			return Ok("Booking has updated successfully!");

		}
	}
}
