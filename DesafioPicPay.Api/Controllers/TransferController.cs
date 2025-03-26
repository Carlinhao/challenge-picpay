using DesafioPicPay.Core.DomainObjects;
using DesafioPicPay.Core.Dtos;
using DesafioPicPay.Core.Interfaces;
using DesafioPicPay.Core.Interfaces.Repositories;
using DesafioPicPay.Core.Mappers;
using DesafioPicPay.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPicPay.Api.Controllers
{
    [Route("api/v1/transfer")]
    [ApiController]
    public class TransferController(IUserRepository userRepository) : ControllerBase
    {
        private readonly IUserRepository _userRepository = userRepository;


        [HttpPost]
        [ProducesResponseType(typeof(HttpResponse), StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(HttpResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(HttpResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync([FromBody] TransferDto request, CancellationToken cancellationToken)
        {
            if (request == null)
                return BadRequest("Data is invalid.");

            return Created();
        }
    }
}
