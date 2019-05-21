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
    public class ContactControllerTest
    {


        private readonly IDataContext _dataContext;
        private readonly ContactusController _contactusController;
        private readonly IContactusService _contactusService;


        public ContactControllerTest()
        {
            _dataContext = Substitute.For<IDataContext>();
            _contactusService = Substitute.For<IContactusService>();
            _contactusController = new ContactusController(_dataContext, _contactusService);
        }

        [Fact]
        public async Task ContactusController_Should_CreateARecord()
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
            var result = await _contactusController.Create(contactus);

            //Assert
            await _contactusService.Received(1).Create(contactus);
            Assert.IsType<OkResult>(result);

        }

    }





}
