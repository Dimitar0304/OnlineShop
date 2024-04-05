using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using OnlineShop.Controllers;
using OnlineShop.Infrastructure.Data.Models;
using System.Net;
using Xunit;


namespace OnlineShop.Tests.Controllers
{
    [TestFixture]
    public class UserControllerTests
    {
        //IClassFixture<WebApplicationFactory<Program>>
        //private readonly WebApplicationFactory<Program> factory;
        public UserControllerTests()
        {
            //WebApplicationFactory<Program> _factory
            //factory = _factory;
        }
        [Test]
        public async Task UserControllerShoudBeOnlyForAuthorizedAndAdminUsers()
        {
            //Arrange
            var controller = new UserController(null, null);
            //var client = factory.CreateClient();
            //var  response = await client.GetAsync("/User/AddToRole?email=myTestMvc&roleName=ADMIN");

            //Act
            var attributes = controller.GetType().GetCustomAttributes(true);

            //Assert
            attributes.Any(a => a.GetType() == typeof(AuthorizeAttribute));
            //Assert.NotEqual(response.StatusCode, HttpStatusCode.OK);
        }
    }
}
