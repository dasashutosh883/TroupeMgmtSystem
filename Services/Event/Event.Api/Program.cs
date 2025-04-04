using Common.Shared.Exceptions;
using Event.Application;
using Event.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Scalar.AspNetCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

//Add methods Extensions
builder.Services.AddInjectionPersistence();
builder.Services.AddInjectionApplication();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Event API");
    });
    app.UseReDoc(options =>
    {
        options.SpecUrl("/openapi/v1.json");
    });
    app.MapScalarApiReference();
}
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        if (exception is ValidationExceptionCustom validationException)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            var errors = validationException.Errors.Select(e => new
            {
                ErrorCode = 500,
                Message = e.ErrorMessage
            });

            await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new
            {
                Message = "Validation errors occurred.",
                Errors = errors
            }));
        }
        else
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new
            {
                Message = "An unexpected error occurred."
            }));
        }
    });
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
