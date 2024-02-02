namespace DesafioPicPay.Core.Models;

public abstract class Entity
{
    public string Id { get; } = Guid.NewGuid().ToString();
}