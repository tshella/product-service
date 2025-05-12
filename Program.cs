using ProductApi.Middlewares;
using ProductApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllers();
builder.Services.AddHttpClient<ProductService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use custom error middleware
app.UseMiddleware<ErrorHandlingMiddleware>();

// Swagger docs
app.UseSwagger();
app.UseSwaggerUI();

// Map endpoints
app.MapControllers();

//listen on port 80 for compatibility with NGINX reverse proxy
app.Urls.Add("http://*:80");

app.Run();
