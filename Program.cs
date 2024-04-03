using FilmsUdemy.Data;
using FilmsUdemy.Endpoints;
using FilmsUdemy.Entity;
using FilmsUdemy.Repositories;
using Microsoft.AspNetCore.Cors;using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var originsAllowed = builder.Configuration.GetValue<string>("OriginsAllowed")!;

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer("name=DefaultConnection");
});

builder.Services.AddCors(opciones =>
{
    opciones.AddDefaultPolicy(configuracion =>
    {
        configuracion.WithOrigins(originsAllowed).AllowAnyHeader().AllowAnyMethod();
    });

    opciones.AddPolicy("libre", configuracion =>
    {
        configuracion.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddOutputCache();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// lo que hacemos es registrar la interfaz y la clase que implementa la interfaz, pero también nos sirve para llamar este servicio en cualquier parte de la aplicación

builder.Services.AddScoped<IRespostoryGenderFilm, RepositoriesGender>();

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();    
}

app.UseCors();
app.UseOutputCache();

//app.MapGet("/", [EnableCors(policyName:"free")]() => "Hello World!");
app.MapGet("/", () => "Hello World!");

app.MapGroup("/gender").MapGenders();

app.Run();

