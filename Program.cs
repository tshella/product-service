using FluentValidation;
using FluentValidation.AspNetCore;
using ProductApi.Middlewares;
using ProductApi.Services;
using ProductApi.Validators;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Configure Serilog for logging
builder.Host.UseSerilog((ctx, config) =>
{
    config.WriteTo.Console();
});

// 🔹 Register core services
builder.Services.AddControllers();
builder.Services.AddHttpClient<ProductService>();
builder.Services.AddEndpointsApiExplorer();

// 🔹 Enable Swagger with XML comments
builder.Services.AddSwaggerGen(options =>
{
    var xmlPath = Path.Combine(AppContext.BaseDirectory, "ProductApi.xml");
    options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});

// 🔹 Enable FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<ProductDtoValidator>();

var app = builder.Build();

// 🔹 Use global error-handling middleware
app.UseMiddleware<ErrorHandlingMiddleware>();

// 🔹 Enable Swagger UI
app.UseSwagger();
app.UseSwaggerUI();

// 🔹 Enable routing to API controllers
app.MapControllers();

// 🔹 Required: Listen on port 80 (for Docker + NGINX reverse proxy)
app.Urls.Add("http://*:80");

app.Run();
