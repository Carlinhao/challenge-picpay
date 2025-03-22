using DesafioPicPay.Core.Dtos;
using DesafioPicPay.Core.Dtos.Request;
using DesafioPicPay.Core.Dtos.Responses;
using DesafioPicPay.Core.Models;

namespace DesafioPicPay.Core.Mappers
{
    public  static class MapperDtoModel
    {
        public static User MapUserDtoToModel(this UserRequest userRequest)
        {
            if (userRequest is null)
                return null;

            return new(Guid.NewGuid().ToString(), userRequest.FullName, userRequest.CpfCnpj, userRequest.Email, userRequest.Password, userRequest.Active, userRequest.BirthDate, userRequest.TypeUser);
        }


        public static UserResponse MapUserModelToDto(this User user)
        {
            if (user is null)
                return null;

            return new (user.UserId, user.FullName, user.CpfCnpj, user.Email, user.Active, user.BirthDate, user.TypeUser);
        }
        public static Account MapAccountDtoToModel(this AccountDto accountDto)
        {
            if (accountDto == null)
                return null;

            return new(Guid.NewGuid().ToString(), accountDto.UserId, accountDto.CostumerName, accountDto.Balance, accountDto.Active, accountDto.CreateDate, accountDto.UpdateDate);
        }

        public static Transfer MapTransferDtoToModel(this TransferDto transferDto)
        {
            if (transferDto is null)
                return null;

            return new (transferDto.Payeer, transferDto.Payee, transferDto.TransferValue);
        }
    }
}
