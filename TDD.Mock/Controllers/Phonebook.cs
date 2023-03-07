using Microsoft.AspNetCore.Mvc;
using TDD.Mock.Domain;
using TDD.Mock.Services;

namespace TDD.Mock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhoneBookController : ControllerBase
    {
        private readonly ILogger<PhoneBookController> _logger;
        private readonly IContactsService _contactsService;

        public PhoneBookController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        [HttpGet(Name = "GetContact")]
        public Contact Get(Guid id)
        {
            return _contactsService.Get(id);
        }

        [HttpPost(Name = "CreateContact")]
        public Guid Post([FromBody] string name, string telephone)
        {
            return _contactsService.Add(name, telephone);
        }

        [HttpPut(Name = "UpdateContact")]
        public bool Update([FromBody] Guid id, string name)
        {
            return _contactsService.Update(id, name);
        }

        [HttpDelete(Name = "DeleteContact")]
        public bool Delete(Guid id)
        {
            return _contactsService.Remove(id);
        }
    }
}