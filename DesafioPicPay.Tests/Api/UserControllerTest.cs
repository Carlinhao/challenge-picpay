using System.Linq.Expressions;
using DesafioPicPay.Api.Controllers;
using DesafioPicPay.Core.Dtos;
using DesafioPicPay.Core.Interfaces;
using DesafioPicPay.Core.Mappers;
using DesafioPicPay.Core.Models;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPicPay.Tests.Api
{
    public class UserControllerTest
    {
        UserDto user = A.Fake<UserDto>();
        readonly UserController controller;
        readonly IUserRepository userRepository = A.Fake<IUserRepository>();

        public UserControllerTest()
        {
            controller = new UserController(userRepository);
        }


        [Fact]
        [Trait("UserController", "Add")]
        public async Task Add_WhenDataIsValidMustReturn_StatusCreated()
        {
            // Arrange
            user = new UserDto { BirthDate = DateTime.Now, Active = true, Email = "eemail.com", TypeUser = 'F', FullName = "Tone", CpfCnpj = "05212837014", Password = "asdfasd" };
            A.CallTo(() => userRepository.SaveAsync(user.MapUserDtoToModel(), CancellationToken.None));

            // Act
            var result = await controller.Add(user, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("eemail.com", "05212837014")]
        [InlineData("test@teste.com","05212837014")]
        [InlineData("eemail.com", "05212837016")]
        [Trait("UserController", "Add")]
        public async Task Add_WhenDataIsInvalidMustReturn_StatusBadRequest(string email, string cpf)
        {
            // Arrange
            var _repository = new Fake<IUserRepository>();
            var userController = new UserController(_repository.FakedObject);
            var userDto = A.Fake<UserDto>();
            var userEntity = A.Fake<User>(x => x.WithArgumentsForConstructor(() => new ( "", "Tone", cpf, email, "asdf", true, DateTime.Now, 'F' )));
           
            userDto = new UserDto { BirthDate = DateTime.Now, Active = true, Email = "eemail.com", TypeUser = 'F', FullName = "Tone", CpfCnpj = "05212837014", Password = "asdfasd" };

            _repository.CallsTo(p => p.Search(A<Expression<Func<User, bool>>>.Ignored, CancellationToken.None)).Returns(userEntity);

            // Act
            var actionResult = await userController.Add(userDto, CancellationToken.None);

            // Assert
            Assert.IsType<BadRequestObjectResult>(actionResult);
        }
    }
}
