using DesafioPicPay.Core.Dtos;
using DesafioPicPay.Core.Interfaces;
using DesafioPicPay.Core.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPicPay.Api.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController(IUserRepository userRepository) : ControllerBase
    {
        private readonly IUserRepository _userRepository = userRepository;

        [HttpPost]
        [ProducesResponseType(typeof(HttpResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(HttpResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add([FromBody] UserDto userDto, CancellationToken cancellationToken)
        {
            LoggerMessage.Define(LogLevel.Information, 123, $"[UserControllers]-[Add] [START]");

            var message = await FindDuplicateUser(userDto,cancellationToken).ConfigureAwait(false);

            if (message is not null)
                return BadRequest(message);

            await _userRepository.SaveAsync(userDto.MapUserDtoToModel(), cancellationToken).ConfigureAwait(false);

            return Created();
        }

        [HttpGet]
        [ProducesResponseType(typeof(HttpResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetAllAsync(cancellationToken).ConfigureAwait(false);

            return Ok(result);
        }


        private async Task<string> FindDuplicateUser(UserDto userDto, CancellationToken cancellationToken)
        {
            var findedUser = await _userRepository.Search(x => x.Email.Equals(userDto.Email) || x.FullName.Equals(userDto.FullName), cancellationToken).ConfigureAwait(false);

            if (findedUser is null)
                return null;

            var message = userDto switch
            {
                UserDto user when user.CpfCnpj == findedUser.CpfCnpj => "Doc alredy exists",
                UserDto user when user.Email == findedUser.Email => "Email alredy exists",
                _ => "Name e email alredy exists"
            };

            return message;
        }
    }
}
