using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Context;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Database configuration
var connectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING")
                       ?? builder.Configuration.GetConnectionString("ScoreProDbContext");
builder.Services.AddDbContext<ScoreProDbContext>(options => options.UseNpgsql(connectionString));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddInfrastructure();
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
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Up and grateful!🙏🏾");

app.Run();