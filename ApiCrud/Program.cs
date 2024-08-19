using Microsoft.EntityFrameworkCore;
using ApiCrud.Context; // Asegúrate de usar el espacio de nombres correcto


var builder = WebApplication.CreateBuilder(args);

// Configura el contexto de base de datos
builder.Services.AddDbContext<PatrocinioContex>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connexion"),
        sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()));
// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Agrega servicios al contenedor.
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configura la tubería de solicitud HTTP.
app.UseAuthorization();

app.MapControllers();

app.Run();

