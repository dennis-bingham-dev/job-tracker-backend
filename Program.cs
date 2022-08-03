using practice_api.BLL.CurrencyExchange;
using practice_api.Events.Jobs;
using practice_api.Events.Jobs.Subscribers;
using RestSharp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<RestClient>();
builder.Services.AddSingleton<CurrencyExchangeBLL>();
builder.Services.AddSingleton<JobEvent>();
builder.Services.AddSingleton<WebhookService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
