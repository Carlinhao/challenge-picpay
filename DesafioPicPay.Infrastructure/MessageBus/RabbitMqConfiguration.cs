using DesafioPicPay.Core.Interfaces;
using DesafioPicPay.Core.Models;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace DesafioPicPay.Infrastructure.MessageBus;

public class RabbitMqConfiguration(ILogger<RabbitMqConfiguration> logger) : IEventBus
{
    private readonly ILogger<RabbitMqConfiguration> _logger = logger;

    const string CONNECTION_BUS = "localhost";
    const string QUEUE_NAME = "PIC_PAY_TRANSFER";

    public async Task PublishAsync(Transfer @event)
    {
        var factory = new ConnectionFactory() { HostName = CONNECTION_BUS , Port = 5672,UserName = "teste", Password = "admin123", DispatchConsumersAsync = true };
        try
        {
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: QUEUE_NAME,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            string message = JsonSerializer.Serialize(@event);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                routingKey: QUEUE_NAME,
                basicProperties: null,
                body: body);
        }
        catch (Exception ex)
        {
            _logger.BeginScope(new Dictionary<string, object> 
            {
                ["ErrorMessage"] = ex.Message,
                ["Data"] = ex.Data,
                ["StackTrace"] = ex.StackTrace,
                ["Source"] = ex.Source
            });

            throw;
        }

        await Task.CompletedTask;
    }
}

