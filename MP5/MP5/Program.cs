using Microsoft.EntityFrameworkCore;
using MP5.Context;
using MP5.Services.Bets;
using MP5.Services.Coupons;
using MP5.Services.Players;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BetsDb")));

builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IBetsService, BetsService>();
builder.Services.AddScoped<ICouponsService, CouponsService>();

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