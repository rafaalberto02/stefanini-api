using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Linq;

namespace Examples.Charge.Application.Facade
{
    public class PhoneNumberTypeFacade : IPhoneNumberTypeFacade
    {
        private readonly IPhoneNumberTypeService _phoneNumberTypeService;
        private readonly IMapper _mapper;

        public PhoneNumberTypeFacade(IPhoneNumberTypeService personPhoneService, IMapper mapper)
        {
            _phoneNumberTypeService = personPhoneService;
            _mapper = mapper;
        }

        public async Task<PhoneNumberTypeListResponse> FindAllAsync()
        {
            var result = await _phoneNumberTypeService.FindAllAsync();
            var response = new PhoneNumberTypeListResponse();
            response.PhoneNumberObjects = new List<PhoneNumberTypeDto>();
            response.PhoneNumberObjects.AddRange(result.Select(phoneNumber => _mapper.Map<PhoneNumberTypeDto>(phoneNumber)));
            return response;
        }

    }
}