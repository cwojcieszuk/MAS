using System.Text;
using MAS.Backend.Data;
using MAS.Backend.Jwt;
using MAS.Backend.Persistence.Interfaces.Authentication;
using MAS.Backend.Persistence.Interfaces.Bets;
using MAS.Backend.Persistence.Interfaces.Coupons;
using MAS.Backend.Persistence.Interfaces.Users;
using MAS.Backend.Persistence.Repositories.Authentication;
using MAS.Backend.Persistence.Repositories.Bets;
using MAS.Backend.Persistence.Repositories.Coupons;
using MAS.Backend.Persistence.Repositories.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MasContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MASDbConnString")));

JwtSettings jwtSettings = new JwtSettings();
builder.Configuration.Bind(JwtSettings.SectionName, jwtSettings);
builder.Services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
    });

builder.Services.AddSingleton(Options.Create(jwtSettings));
builder.Services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IBetsService, BetsService>();
builder.Services.AddScoped<ICouponsService, CouponsService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();