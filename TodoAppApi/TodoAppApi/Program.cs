using System.Diagnostics;
using Microsoft.OpenApi.Models;
using TodoAppApi.Data;
using TodoAppApi.Controller;
using TodoAppApi.Data;
using TodoAppApi.Middleware;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddMemoryCache();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await dbContext.SeedDatabaseAsync();
}
else
{
    app.UseExceptionHandler((x) =>{ });
}

app.MapControllers();
app.UseCors((options) =>
{
    options.AllowAnyMethod();
    options.AllowAnyHeader();
    options.AllowCredentials();
    options.SetIsOriginAllowed(origin => true);
});


//beispiel
//app.Use(async (HttpContext HttpContext, RequestDelegate next) =>
//{
//    Debug.WriteLine("vorher");
//    await next.Invoke(HttpContext);
//    Debug.WriteLine("nachher");
//});

//app.UseMiddleware<LoggingMiddleware>();

app.Run();