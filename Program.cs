using Microsoft.EntityFrameworkCore;
using escola.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddDbContext<EscolaContext>(opt => opt.UseSqlServer(@"Server=MARIATHERESA\SQLEXPRESS;Database=escola;User_Id=root2;Password=12345678"));
//builder.Services.AddDbContext<EscolaContext>(opt => opt.UseInMemoryDatabase("Escola"));
//builder.Services.AddDbContext<EscolaContext>(opt =>
//    opt.UseSqlServer(@"Server=MARIATHERESA\SQLEXPRESS;Database=escola;User Id=root2;Password=12345678"));

builder.Services.AddDbContext<EscolaContext>(opt =>
    opt.UseSqlServer(@"Server = tcp:escoladb.database.windows.net, 1433; Initial Catalog = escola; Persist Security Info=False; User ID = root2; Password = 62TKEs77CT@yjqF; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;"));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();