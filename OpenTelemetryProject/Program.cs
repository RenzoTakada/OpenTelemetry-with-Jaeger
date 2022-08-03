using Adapters.OpenTelemetry.Extensions;
using Adapters.OpenTelemetry.Settings;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetryProject.Domain.Application;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IuserCasePessoa, UserCasePessoa>();
builder.Services.AddpenTelemetryAdapter();




var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
