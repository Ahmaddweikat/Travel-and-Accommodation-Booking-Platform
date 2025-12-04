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
using TABP.Application.Behaviors;
using TABP.Web.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

