using Microsoft.EntityFrameworkCore;
using escola.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddDbContext<AlunoContext>(opt => opt.UseInMemoryDatabase("Escola"));
//builder.Services.AddDbContext<TurmaContext>(opt => opt.UseInMemoryDatabase("Escola"));
//builder.Services.AddDbContext<EscolaContext>(opt => opt.UseSqlServer(@"Server=MARIATHERESA\SQLEXPRESS;Database=escola;User_Id=root2;Password=12345678"));
builder.Services.AddDbContext<EscolaContext>(opt => opt.UseInMemoryDatabase("Escola"));

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

app.UseAuthorization();

app.MapControllers();

app.Run();