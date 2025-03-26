using System.Collections.Immutable;
using System.Linq.Expressions;
using DesafioPicPay.Core.Dtos.Request;
using DesafioPicPay.Core.Dtos.Responses;
using DesafioPicPay.Core.Interfaces.Repositories;
using DesafioPicPay.Core.Interfaces.Services;
using DesafioPicPay.Core.Mappers;
using Microsoft.Extensions.Logging;

namespace DesafioPicPay.Service.User;

public class UserService : IUserService<UserRequest, UserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<UserService> _logger;

    public UserService(IUserRepository userRepository,
                       ILogger<UserService> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task AddAsync(UserRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("[UserService]-[AddAsync] [START]");
        await _userRepository.SaveAsync(request.MapUserDtoToModel(), cancellationToken);
        _logger.LogInformation("[UserService]-[AddAsync] [END]");
    }

    public async Task<UserResponse> GetAsync(string id, CancellationToken cancellationToken)
    {
        _logger.LogInformation("[UserService]-[GetAsync] [START]");
        var result = await _userRepository.GetByIdAsync(id, cancellationToken);
        _logger.LogInformation("[UserService]-[GetAsync] [END]");
        
        return result.MapUserModelToDto();
    }

    public async Task<IReadOnlyCollection<UserResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("[UserService]-[GetAsync] [START]");
        var result =await  _userRepository.GetAllAsync(cancellationToken);
        _logger.LogInformation("[UserService]-[GetAsync] [END]");
        
        return result.Select(x => x.MapUserModelToDto()).ToImmutableList();
    }

    public async Task<UserResponse> Search(UserRequest userRequest, CancellationToken cancellationToken)
    {
        _logger.LogInformation("[UserService]-[Search] [START]");
        var result = await _userRepository.Search(x => x.Email.Equals(userRequest.Email) || x.FullName.Equals(userRequest.FullName), cancellationToken);
        _logger.LogInformation("[UserService]-[Search] [END]");
        
        return result.MapUserModelToDto();
    }
}