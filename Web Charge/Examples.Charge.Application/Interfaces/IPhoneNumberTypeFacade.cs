using System.Threading.Tasks;
using Examples.Charge.Application.Messages.Response;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPhoneNumberTypeFacade
    {
        Task<PhoneNumberTypeListResponse> FindAllAsync();
    }
}