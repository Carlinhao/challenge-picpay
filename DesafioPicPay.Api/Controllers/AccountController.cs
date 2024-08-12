using System.Security.Cryptography;
using DesafioPicPay.Core.Dtos;
using DesafioPicPay.Core.Interfaces;
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
            var enventId = RandomNumberGenerator.GetInt32(10);
            LoggerMessage.Define(LogLevel.Information, enventId, "[AccountController][PostAsync]-[Start]");

            if (accountDto is null)
                return BadRequest();

            await _accountRepository.SaveAsync(accountDto.MapAccountDtoToModel(), cancellationToken).ConfigureAwait(false);


            LoggerMessage.Define(LogLevel.Information, enventId, "[AccountController][PostAsync]-[End]");
            return Created();
        }
    }
}
