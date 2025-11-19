using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entitites;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly IContactService _contactService;
		private readonly IMapper _mapper;

		public ContactsController(IContactService contactService, IMapper mapper)
		{
			_contactService = contactService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult ContactList()
		{
			var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult ContactCreate(CreateContactDto createContactDto)
		{
			Contact contact = new Contact()
			{
				ContactMail = createContactDto.ContactMail,
				ContactFooterDescription = createContactDto.ContactFooterDescription,
				ContactLocation = createContactDto.ContactLocation,
				ContactPhone = createContactDto.ContactPhone,
			};
			_contactService.TAdd(contact);
			return Ok("Contact has added successfully!");
		}

		[HttpDelete]
		public IActionResult ContactDelete(int id)
		{
			var value = _contactService.TGetById(id);
			_contactService.TDelete(value);
			return Ok("Contact has deleted successfully!");
		}

		[HttpGet("ContactGet")]
		public IActionResult ContactGet(int id)
		{
			var value = _contactService.TGetById(id);
			return Ok(value);
		}

		[HttpPut]
		public IActionResult ContactUpdate(UpdateContactDto updateContactDto)
		{
			Contact contact = new Contact()
			{
				ContactID = updateContactDto.ContactID,
				ContactMail = updateContactDto.ContactMail,
				ContactFooterDescription = updateContactDto.ContactFooterDescription,
				ContactLocation = updateContactDto.ContactLocation,
				ContactPhone = updateContactDto.ContactPhone,
			};
			_contactService.TUpdate(contact);
			return Ok("Contact has updated successfully!");
		}
	}
}
