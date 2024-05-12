using Trello.Api.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSqlServer<AppDbContext>(builder.Configuration.GetConnectionString("DB"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", builder =>
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("NewPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
