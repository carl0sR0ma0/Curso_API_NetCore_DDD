using Application.Controllers;
using Domain.DTOs.User;
using Domain.Interfaces.Services.User;
using Faker;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.User.WhenRequestGetAll
{
    public class ReturnOk
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possível realizar Get All com OK")]
        public async Task InvokeControllerGetAllOK()
        {
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(new List<UserDTO>()
            {
                new UserDTO
                {
                    Id = Guid.NewGuid(),
                    Name = Name.FullName(),
                    Email = Internet.Email(),
                    CreateAt = DateTime.UtcNow
                },
                new UserDTO
                {
                    Id = Guid.NewGuid(),
                    Name = Name.FullName(),
                    Email = Internet.Email(),
                    CreateAt = DateTime.UtcNow
                }
            });

            _controller = new UsersController(serviceMock.Object);

            var _result = await _controller.GetAll();
            Assert.True(_result is OkObjectResult);

            var _resultValue = ((OkObjectResult)_result).Value as IEnumerable<UserDTO>;
            Assert.NotNull(_resultValue);
            Assert.True(_resultValue.Count() == 2);
        }
    }
}
