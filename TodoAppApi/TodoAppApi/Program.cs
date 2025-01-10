using System.Diagnostics;
using TodoAppApi.Data;
using TodoAppApi.Controller;
using TodoAppApi.Data;
using TodoAppApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await dbContext.SeedDatabaseAsync();
}

app.MapControllers();

//beispiel
//app.Use(async (HttpContext HttpContext, RequestDelegate next) =>
//{
//    Debug.WriteLine("vorher");
//    await next.Invoke(HttpContext);
//    Debug.WriteLine("nachher");
//});

app.UseMiddleware<LoggingMiddleware>();

app.Run();