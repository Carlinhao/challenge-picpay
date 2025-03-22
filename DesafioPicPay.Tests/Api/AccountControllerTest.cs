using DesafioPicPay.Api.Controllers;
using DesafioPicPay.Core.Dtos;
using DesafioPicPay.Core.Interfaces.Repositories;
using DesafioPicPay.Core.Mappers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DesafioPicPay.Tests.Api
{
    public class AccountControllerTest
    {
        private readonly Mock<IAccountRepository> _accountRepository;
        private readonly AccountController _accountController;

        public AccountControllerTest()
        {
            _accountRepository = new Mock<IAccountRepository>();
            _accountController = new(_accountRepository.Object);

        }

        [Fact]
        [Trait("AccountController", "PostAsync")]
        public async Task PostAsync_WhenDtoIsValid_MustRetunrSuccess()
        {
            // Arrange
            var accountDtos = GetAccountDto();
            _accountRepository.Setup(x => x.SaveAsync(accountDtos.MapAccountDtoToModel(), CancellationToken.None)).Returns(Task.CompletedTask);

            // Act
            var result = await _accountController.PostAsync(accountDtos, cancellationToken: CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CreatedResult>(result);
        }

        [Theory]
        [InlineData(null)]
        [Trait("AccountController", "PostAsync")]
        public async Task PostAsync_WhenDtoIsNull_MustRetunrBadRequest(AccountDto? dto)
        {
            // Arrange
            _accountRepository.Setup(x => x.SaveAsync(dto.MapAccountDtoToModel(), CancellationToken.None)).Returns(Task.CompletedTask);

            // Act
            var result = await _accountController.PostAsync(dto, cancellationToken: CancellationToken.None);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        private static AccountDto GetAccountDto()
            => new()
            {
                Active = true,
                Balance = 0,
                CostumerName = "Paul Stone",
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                UserId = Guid.NewGuid().ToString(),
            };
    }
}
