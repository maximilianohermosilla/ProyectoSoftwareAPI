using Microsoft.EntityFrameworkCore;
using ProyectoSoftware.AccessData;
using ProyectoSoftware.AccessData.Commands;
using ProyectoSoftware.AccessData.Queries;
using ProyectoSoftware.Application.Interfaces;
using ProyectoSoftware.Application.Services;
using ProyectoSoftware.Domain.ICommands;
using ProyectoSoftware.Domain.IQueries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CONNECTION STRING
var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<ProyectoSoftwareContext>(options => options.UseSqlServer(connectionString));

//INTERFACES
builder.Services.AddTransient<ITipoMercaderiaService, TipoMercaderiaService>();
builder.Services.AddTransient<IMercaderiaService, MercaderiaService>();
builder.Services.AddTransient<IFormaEntregaService, FormaEntregaService>();
builder.Services.AddTransient<IComandaService, ComandaService>();
builder.Services.AddTransient<IMigracionService, MigracionService>();

builder.Services.AddTransient<ITipoMercaderiaQuery, TipoMercaderiaQuery>();
builder.Services.AddTransient<IMercaderiaQuery, MercaderiaQuery>();
builder.Services.AddTransient<IFormaEntregaQuery, FormaEntregaQuery>();
builder.Services.AddTransient<IComandaQuery, ComandaQuery>();

builder.Services.AddTransient<ITipoMercaderiaCommand, TipoMercaderiaCommand>();
//builder.Services.AddTransient<IMercaderiaCommand, MercaderiaCommand>();
//builder.Services.AddTransient<IFormaEntregaCommand, FormaEntregaCommand>();
builder.Services.AddTransient<IComandaCommand, ComandaCommand>();
builder.Services.AddTransient<IMigracionCommand, MigracionCommand>();

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
