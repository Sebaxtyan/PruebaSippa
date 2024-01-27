using PruebaTecnicaSippa.Data.Configuration;
using PruebaTecnicaSippa.Data.Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ConfiguracionMetodos>();
builder.Services.AddScoped<EmpleadoMetodos>();
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
