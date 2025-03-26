using DesafioPicPay.Api.Controllers;
using DesafioPicPay.Core.Dtos.Request;
using DesafioPicPay.Core.Dtos.Responses;
using DesafioPicPay.Core.Interfaces.Services;
using DesafioPicPay.Core.Mappers;
using DesafioPicPay.Core.Models;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPicPay.Tests.Api
{
    public class UserControllerTest
    {
        private UserRequest _user = A.Fake<UserRequest>();
        private readonly UserController _controller;
        private readonly IUserService<UserRequest, UserResponse> _userServices = A.Fake<IUserService<UserRequest, UserResponse>>();

        public UserControllerTest()
        {
            _controller = new UserController(_userServices);
        }


        [Fact]
        [Trait("UserController", "Add")]
        public async Task Add_WhenDataIsValidMustReturn_StatusCreated()
        {
            // Arrange
            _user = new UserRequest { BirthDate = DateTime.Now, Active = true, Email = "email.com", TypeUser = 'F', FullName = "Tone", CpfCnpj = "05212837014", Password = "asdfasd" };
            _ = A.CallTo(() => _userServices.AddAsync(_user, CancellationToken.None));

            // Act
            var result = await _controller.Add(_user, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("email.com", "05212837014", "Tone Silva")]
        [InlineData("test@teste.com","05212837014", "Tone Silva")]
        [InlineData("email.com", "05212837016", "Tone Silva")]
        [Trait("UserController", "Add")]
        public async Task Add_WhenDataIsInvalidMustReturn_StatusBadRequest(string email, string cpf, string fullName)
        {
            // Arrange
            var service = new Fake<IUserService<UserRequest, UserResponse>>();
            var userController = new UserController(service.FakedObject);
            var userRequest = A.Fake<UserRequest>(x => x.ConfigureFake(request =>
            {
                request.BirthDate = DateTime.Now;
                request.Active = true;
                request.TypeUser = 'F';
                request.Email = email;
                request.CpfCnpj = cpf;
                request.FullName = "Tone";
                request.Password = "asdfasd";
            }));
            var userEntity = A.Fake<User>(x => x.WithArgumentsForConstructor(() => new User( Guid.NewGuid().ToString(), fullName, cpf, email, "asdf", true, DateTime.Now, 'F' )));

            service.CallsTo(p  => p.Search(userRequest, CancellationToken.None)).Returns(userEntity.MapUserModelToDto());

            // Act
            var actionResult = await userController.Add(userRequest, CancellationToken.None);

            // Assert
            Assert.IsType<BadRequestObjectResult>(actionResult);
        }
    }
}
