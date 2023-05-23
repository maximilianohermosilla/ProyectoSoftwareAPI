using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProyectoSoftware.AccessData;
using ProyectoSoftware.AccessData.Commands;
using ProyectoSoftware.AccessData.Queries;
using ProyectoSoftware.Application.Interfaces;
using ProyectoSoftware.Application.Interfaces.ICommands;
using ProyectoSoftware.Application.Interfaces.IQueries;
using ProyectoSoftware.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger", Version = "1.0" });
});

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
builder.Services.AddTransient<IComandaMercaderiaQuery, ComandaMercaderiaQuery>();

builder.Services.AddTransient<ITipoMercaderiaCommand, TipoMercaderiaCommand>();
builder.Services.AddTransient<IMercaderiaCommand, MercaderiaCommand>();
builder.Services.AddTransient<IComandaCommand, ComandaCommand>();
builder.Services.AddTransient<IComandaMercaderiaCommand, ComandaMercaderiaCommand>();
builder.Services.AddTransient<IMigracionCommand, MigracionCommand>();

var app = builder.Build();

//MIGRACION INICIAL
var myService = builder.Services.BuildServiceProvider().GetService<IMigracionService>();
myService.UpdateMigration();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x => { x.SwaggerEndpoint("/swagger/v1/swagger.yaml", "Swagger"); });
}

//USE CORS
app.UseCors(policy => policy.AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed(origin => true)
                            .AllowCredentials());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
