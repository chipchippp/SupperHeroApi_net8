using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using SuperHeroApi_net8.Data;
using System.Configuration;
using System.Text;
var builder = WebApplication.CreateBuilder(args);


// Lấy cấu hình từ appsettings.json
var configuration = builder.Configuration;
// Lấy các cài đặt mail từ appsettings.json
var mailSettings = configuration.GetSection("MailSettings");
var jwtSettings = configuration.GetSection("JwtSettings");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]))
    };
});

builder.Services.AddDbContext<SuperHeroApi_net8Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SuperHeroApi_net8Context") ?? throw new InvalidOperationException("Connection string 'SuperHeroApi_net8Context' not found.")));

// Add services to the container.

builder.Services.AddControllers();
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

// Authentication
app.UseAuthentication();

app.UseRouting();

// Authorization
app.UseAuthorization();

app.MapControllers();

app.Run();
