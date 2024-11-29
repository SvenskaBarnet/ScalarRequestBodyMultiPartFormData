using System.Reflection;
using Scalar.AspNetCore;
using Swashbuckle.AspNetCore.Filters;
using ScalarRequestBodyMultipartFormData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Generate the swagger document with added xml comments
builder.Services.AddSwaggerGen(options =>
{
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
    options.ExampleFilters();
});
builder.Services.AddSwaggerExamplesFromAssemblyOf<WeatherForecastExample>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        // doesn't matter what you call it  document name is v1 url == example/v1/scalar.json
        // YOU MUST ALWAYS PUT {documentName} IN THE ROUTE TEMPLATE
        options.RouteTemplate = "example/{documentName}/scalar.json"; 
    });
    app.MapScalarApiReference(options =>
    {
        options.OpenApiRoutePattern = "/example/v1/scalar.json"; // doesn't matter what you call it
        // ... Rest of scalar reference
    });
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();