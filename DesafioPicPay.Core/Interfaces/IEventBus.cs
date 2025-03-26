using DesafioPicPay.Core.Models;

namespace DesafioPicPay.Core.Interfaces;

public interface IEventBus
{
    Task PublishAsync(Transfer @event);
}

