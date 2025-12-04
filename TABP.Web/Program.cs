using Microsoft.EntityFrameworkCore;
using TABP.Infrastructure;
using TABP.Application;
using TABP.Domain.Interfaces;
using TABP.Domain.Entities;
using TABP.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using TABP.Application.Users.Register;
using TABP.Web.Requests.Users;
using FluentValidation;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// ------------------- DATABASE -------------------
builder.Services.AddDbContext<TABPDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"))
);

// ------------------- AUTOMAPPER -------------------
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<UserRequest, UserCommand>();
    cfg.CreateMap<UserCommand, User>();
});
builder.Services.AddSingleton(mapperConfig.CreateMapper());

// ------------------- REPOSITORIES -------------------
builder.Services.AddScoped<IUserRepository, UserRepository>();

// ------------------- IDENTITY -------------------
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

// ------------------- FLUENT VALIDATION -------------------
builder.Services.AddValidatorsFromAssembly(typeof(UserCommandValidator).Assembly);

// DO NOT USE AddFluentValidationAutoValidation()
// Instead use MediatR pipeline behavior for validation
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

// ------------------- MEDIATR -------------------
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(UserCommand).Assembly);
});

// ------------------- APPLICATION LAYER -------------------
builder.Services.AddApplication();

// ------------------- API -------------------
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
