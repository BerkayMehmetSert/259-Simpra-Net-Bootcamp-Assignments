using Application;
using Application.Contracts.Validators.Categories;
using Application.Contracts.Validators.Products;
using FluentValidation.AspNetCore;
using Infrastructure.Exceptions;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddFluentValidation(config =>
    {
        config.RegisterValidatorsFromAssemblyContaining<CreateCategoryValidator>();
        config.RegisterValidatorsFromAssemblyContaining<UpdateCategoryValidator>();
        config.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>();
        config.RegisterValidatorsFromAssemblyContaining<UpdateProductValidator>();
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceService(builder.Configuration);
builder.Services.AddApplicationService();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCustomExceptionHandler();

app.MapControllers();

app.Run();