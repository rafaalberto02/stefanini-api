using System.Threading.Tasks;
using AutoMapper;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonPhoneTypeController : BaseController
    {
        private IPhoneNumberTypeFacade _facade;

        public PersonPhoneTypeController(IPhoneNumberTypeFacade facade, IMapper mapper)
        {
            _facade = facade;
        }

        [HttpGet]
        public async Task<ActionResult<PhoneNumberTypeListResponse>> Get() => Response(await _facade.FindAllAsync());

    }
}