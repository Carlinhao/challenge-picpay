using DesafioPicPay.Core.Dtos;
using DesafioPicPay.Core.Interfaces.Repositories;
using DesafioPicPay.Core.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPicPay.Api.Controllers
{
    [ApiController]
    [Route("api/v1/accounts")]
    public class AccountController(IAccountRepository accountRepository) : ControllerBase
    {
        private readonly IAccountRepository _accountRepository = accountRepository;

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AccountDto accountDto, CancellationToken cancellationToken)
        {
            if (accountDto is null) return BadRequest();

            await _accountRepository.SaveAsync(accountDto.MapAccountDtoToModel(), cancellationToken).ConfigureAwait(false);

            return Created();
        }
    }
}
