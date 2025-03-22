using DesafioPicPay.Api.Extensions;
using DesafioPicPay.Api.Middlewares;
using DesafioPicPay.Infrastructure.IoC;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

builder.Services.GetService();
builder.Services.SwaggerServices();

WebApplication app = builder.Build();

app.UseMiddleware<GlobalErrorHandler>();
app.UseHttpsRedirection();
app.MapControllers();
app.SwaggerConfigure();

await app.RunAsync().ConfigureAwait(false);