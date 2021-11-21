using System.Collections.Generic;
using Examples.Charge.Application.Common.Messages;
using Examples.Charge.Application.Dtos;

namespace Examples.Charge.Application.Messages.Response
{
    public class PhoneNumberTypeListResponse : BaseResponse
    {
        public List<PhoneNumberTypeDto> PhoneNumberObjects { get; set; }
    }
}