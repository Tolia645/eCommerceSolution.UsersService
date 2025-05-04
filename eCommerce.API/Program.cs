using System.Text.Json.Serialization;
using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Core.Validators;
using eCommerce.Infrastructure;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

//Add Services from class libraries
builder.Services.AddInfrastructure();
builder.Services.AddCoreServices();

builder.Services.AddControllers().AddJsonOptions(options => 
    options.JsonSerializerOptions.Converters.Add(
        new JsonStringEnumConverter()));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(typeof(LoginRequestValidator).Assembly);

builder.Services.AddAutoMapper(typeof(AppUsersProfile).Assembly);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(
                "http://localhost:7196", 
                "http://localhost:4200",
                "http://localhost:7122")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

//Routing
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();

//custom middleware for exeptions validation
app.UseExceptionHandlingMiddleware();

//Auth
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();