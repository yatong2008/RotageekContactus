using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotageek.Contactus.Data;
using Rotageek.Contactus.Services;

namespace Rotageek.Contactus.Controllers
{
    public class ContactusController : Controller
    {
        private readonly IDataContext _context;
        private readonly IContactusService _contactusService;

        public ContactusController(IDataContext context, IContactusService contactusService)
        {
            _context = context;
            _contactusService = contactusService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Email,Address,Message")] Models.Contactus contactus)
        {
            if (ModelState.IsValid)
            {
                await _contactusService.Create(contactus);
                return Ok();
            }
            return BadRequest();
        }
    }

}