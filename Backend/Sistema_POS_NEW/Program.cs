using Microsoft.EntityFrameworkCore;
using Sistema_POS_NEW.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SistemaPosContext>(options => options.UseSqlServer("Server=DESKTOP-UMJDM2Q;Database=Sistema_POS_;Trusted_Connection=True;MultipleActiveResultSets=true"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolity", app =>
    {
        app.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("NewPolity");

app.UseAuthorization();

app.MapControllers();

app.Run();
