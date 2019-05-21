using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Rotageek.Contactus.Controllers;
using Rotageek.Contactus.Data;
using System;
using System.Threading.Tasks;
using Rotageek.Contactus.Services;
using Xunit;
namespace Rotageek.Contactus.Tests
{
    public class ContactusServiceTest
    {
        private readonly ContactusService _contactusService;
        private readonly IDataContext _dataContext;


        public ContactusServiceTest()
        {
            _dataContext = Substitute.For<IDataContext>();
            _contactusService = new ContactusService(_dataContext);
        }

        [Fact]
        public async Task ContactusService_Should_CreateARecordInDb()
        {
            //Arrange
            var contactus = new Models.Contactus
            {
                Id = 123,
                Address = "100 Burke St, Melbourne, 3000",
                CreatedDate = DateTime.Today,
                Email = "test@email.com",
                Message = "fake messages",
                Name = "Nick"
            };
            
            //ACT
            await _contactusService.Create(contactus);

            //Assert
            await _dataContext.Received(1).SaveChangesAsync();
        }

    }





}
