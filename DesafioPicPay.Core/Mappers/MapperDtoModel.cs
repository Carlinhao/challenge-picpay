using DesafioPicPay.Core.Dtos;
using DesafioPicPay.Core.Models;

namespace DesafioPicPay.Core.Mappers
{
    public  static class MapperDtoModel
    {
        public static User MapUserDtoToModel(this UserDto userDto)
        {
            if (userDto is null)
                return null;

            return new(Guid.NewGuid().ToString(), userDto.FullName, userDto.CpfCnpj, userDto.Email, userDto.Password, userDto.Active, userDto.BirthDate, userDto.TypeUser);
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

            return new(transferDto.TransferValue, transferDto.Payeer.UserId, transferDto.Payee.UserId, DateTime.Now);
        }
    }
}
