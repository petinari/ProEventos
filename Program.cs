using Microsoft.EntityFrameworkCore;
using ProEventos.Application.Contracts;
using ProEventos.Persistence;
using ProEventos.Persistence.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddScoped<IEventosService, EventoService>();
builder.Services.AddScoped<IGeralPersist, GeralPersistence>();
builder.Services.AddScoped<IEventosPersist, EventosPersistence>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProEventosContext>(context => context.UseSqlite(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddCors();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

