using DesafioPicPay.Core.DomainObjects;
using DesafioPicPay.Core.Dtos;
using DesafioPicPay.Core.Interfaces;
using DesafioPicPay.Core.Mappers;
using DesafioPicPay.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPicPay.Api.Controllers
{
    [Route("api/v1/transfer")]
    [ApiController]
    public class TransferController(ILogger<TransferController> logger,
                                    IUserRepository userRepository,
                                    IEventBus eventBus) : ControllerBase
    {
        private readonly ILogger<TransferController> _logger = logger;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IEventBus _eventBus = eventBus;


        [HttpPost]
        [ProducesResponseType(typeof(HttpResponse), StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(HttpResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(HttpResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync([FromBody] TransferDto request, CancellationToken cancellationToken)
        {
            Validate(request);

            _logger.LogInformation("[TransferController][Post] dados transfer {O}", request);

            if (request.Payeer is null || request.Payee is null) 
                return BadRequest();

            var user = await _userRepository.GetByIdAsync(request.Payee.UserId, cancellationToken);

            if (!DoCanTransfer(user))
                return BadRequest("You can't transfer to typer user Pessoa Fisíca");

            await _eventBus.PublishAsync(request.MapTransferDtoToModel());

            return Accepted();
        }

        private static bool DoCanTransfer(User user)
            => new SpecificationTransfer().IsSatisfied(user);

        private static void Validate(TransferDto request)
        {
            AssertionConcern.ValidateIfObjectIsNull(request.Payee, "Request is required.");
            AssertionConcern.ValidateIfObjectIsNull(request.Payeer, "Request is required.");
            AssertionConcern.ValidateIfValueTransferIsZero(request.TransferValue, "Transfer amount must be greater than 0");
            AssertionConcern.ValidateIfIsEmpty(request.Payeer.UserId, "UserId is required.");
        }
    }
}
