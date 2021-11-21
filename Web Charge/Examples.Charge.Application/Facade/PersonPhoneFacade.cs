using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Application.Common.Messages;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.Application.Facade
{
    public class PersonPhoneFacade : IPersonPhoneFacade
    {
        private readonly IPersonPhoneService _personPhoneService;
        private readonly IMapper _mapper;

        public PersonPhoneFacade(IPersonPhoneService personPhoneService, IMapper mapper)
        {
            _personPhoneService = personPhoneService;
            _mapper = mapper;
        }
        public async Task<PersonPhoneResponse> FindAllAsync()
        {
            var result = await _personPhoneService.FindAllAsync();
            var response = new PersonPhoneResponse();
            response.PersonPhoneObjects = new List<PersonPhoneDto>();
            response.PersonPhoneObjects.AddRange(result.Select(phone => _mapper.Map<PersonPhoneDto>(phone)));
            return response;
        }
        public async Task<PersonPhoneResponse> InsertAsync(PersonPhoneRequest request)
        {
            PersonPhone phone = _mapper.Map<PersonPhone>(request);
            var response = new PersonPhoneResponse();
            var result = await _personPhoneService.Insert(phone);
            response.PersonPhoneObjects = new List<PersonPhoneDto>();
            response.PersonPhoneObjects.Add(_mapper.Map<PersonPhoneDto>(result));

            return response;
        }

        public async Task<PersonPhoneResponse> UpdateAsync(PersonPhoneRequest request)
        {
            PersonPhone phone = _mapper.Map<PersonPhone>(request);
            var response = new PersonPhoneResponse();
            var result = await _personPhoneService.Update(phone);
            response.PersonPhoneObjects = new List<PersonPhoneDto>();
            response.PersonPhoneObjects.Add(_mapper.Map<PersonPhoneDto>(result));

            return response;
        }
    }
}