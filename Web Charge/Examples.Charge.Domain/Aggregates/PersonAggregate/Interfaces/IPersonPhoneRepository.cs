using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneRepository
    {
        Task<IEnumerable<PersonPhone>> FindAllAsync();
        Task<PersonPhone> Insert(PersonPhone phone);
        Task<PersonPhone> Update(PersonPhone phone);
        Task<IEnumerable<PersonPhone>> DeleteAsync(PersonPhone phone);
    }
}
