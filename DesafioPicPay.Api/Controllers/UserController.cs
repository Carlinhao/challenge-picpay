using System.Security.Cryptography;
using DesafioPicPay.Core.Dtos.Request;
using DesafioPicPay.Core.Dtos.Responses;
using DesafioPicPay.Core.Interfaces.Services;
using DesafioPicPay.Core.Utils;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPicPay.Api.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController(IUserService<UserRequest, UserResponse> userService) : ControllerBase
    {
        private readonly IUserService<UserRequest, UserResponse> _userService = userService;

        [HttpPost]
        [ProducesResponseType(typeof(HttpResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(HttpResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add([FromBody] UserRequest userRequest, CancellationToken cancellationToken)
        {
            LoggerMessage.Define(LogLevel.Information, new EventId(RandomNumberGenerator.GetInt32(4, 9999)),
                "[UserControllers]-[Add] [START]");

            var findedUser = await _userService.Search(userRequest, cancellationToken).ConfigureAwait(false);

            if (findedUser is not null)
            {
                var message = userRequest switch
                {
                    { } user when user.CpfCnpj == findedUser.UserCpfCnpj => ConstantsMessages.DOC_EXIST,
                    { } user when user.Email == findedUser.UserEmail => ConstantsMessages.EMAIL_EXIST,
                    _ => null
                };
                
                return BadRequest(message);
            }

            await _userService.AddAsync(userRequest, cancellationToken).ConfigureAwait(false);
            
            return Created();
        }

        [HttpGet]
        [ProducesResponseType(typeof(HttpResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            LoggerMessage.Define(LogLevel.Information, new EventId(RandomNumberGenerator.GetInt32(4, 9999)),
                "[UserControllers]-[GetAsync] [START]");

            var result = await _userService.GetAllAsync(cancellationToken).ConfigureAwait(false);

            return Ok(result);
        }
    }
}