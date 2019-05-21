using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rotageek.Contactus.Data;

namespace Rotageek.Contactus.Services
{
    public class ContactusService : IContactusService
    {
        private readonly IDataContext _context;

        public ContactusService(IDataContext context)
        {
            _context = context;
        }

        public async Task Create(Models.Contactus contactus)
        {
            contactus.CreatedDate = DateTime.Now;
            _context.Contactuses.Add(contactus);
            await _context.SaveChangesAsync();
        }

    }
}
