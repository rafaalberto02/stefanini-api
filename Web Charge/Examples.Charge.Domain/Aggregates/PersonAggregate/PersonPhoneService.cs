using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IPersonPhoneRepository _personPhoneRepository;
        public PersonPhoneService(IPersonPhoneRepository personPhoneRepository)
        {
            _personPhoneRepository = personPhoneRepository;
        }

        public async Task<IEnumerable<PersonPhone>> DeleteAsync(PersonPhone phone) => (await _personPhoneRepository.DeleteAsync(phone));
        public async Task<List<PersonPhone>> FindAllAsync() => (await _personPhoneRepository.FindAllAsync()).ToList();

        public async Task<PersonPhone> Insert(PersonPhone phone) => (await _personPhoneRepository.Insert(phone));

        public async Task<PersonPhone> Update(PersonPhone phone) => (await _personPhoneRepository.Update(phone));
    }
}
