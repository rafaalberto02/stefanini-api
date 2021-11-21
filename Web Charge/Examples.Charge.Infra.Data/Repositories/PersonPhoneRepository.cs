using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly ExampleContext _context;

        public PersonPhoneRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PersonPhone>> FindAllAsync() => await Task.Run(() => _context.PersonPhone.Include(phone => phone.PhoneNumberType));

        public async Task<PersonPhone> Insert(PersonPhone phone)
        {
            var result = await _context.PersonPhone.SingleOrDefaultAsync(pPhone => pPhone.BusinessEntityID == phone.BusinessEntityID && pPhone.PhoneNumberTypeID == phone.PhoneNumberTypeID);
            if (result != null)
            {
                _context.PersonPhone.Remove(result);
            }
            await _context.PersonPhone.AddAsync(phone);
            await _context.SaveChangesAsync();
            return phone;
        }

        public async Task<PersonPhone> Update(PersonPhone phone)
        {
            var result = await _context.PersonPhone.SingleOrDefaultAsync(pPhone => pPhone.BusinessEntityID == phone.BusinessEntityID && pPhone.PhoneNumberTypeID == phone.PhoneNumberTypeID);
            if (result != null)
            {
                _context.PersonPhone.Remove(result);
                await _context.PersonPhone.AddAsync(phone);
                await _context.SaveChangesAsync();
                return phone;
            }
            return null;
        }
    }
}
