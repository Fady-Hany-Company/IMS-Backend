using IMS_Mono.Extensions;
using IMS_Mono.Middlewares;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, _) =>
    {
        document.Info = new()
        {
            Title = "IMS API",
            Version = "v1",
            Description = "Inventory Management System Monolithic Architecture.",
            Contact = new()
            {
                Name = "API Support",
                Email = "fady.h.sammy@gmail.com"
                // ,Url = new Uri("https://api.example.com/support")
            }
        };
        return Task.CompletedTask;
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        builder => builder.WithOrigins("http://localhost:4200") // Replace with your front-end port
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddProjectServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi().CacheOutput();
    app.MapScalarApiReference();
    app.MapGet("/", () => Results.Redirect("/scalar/v1"))
        .ExcludeFromDescription();
}

app.UseCors("AllowAngular");

app.UseMiddleware<ResponseWrapperMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();