using Aplicacion.Interface;
using Aplicacion.Servicio;
using Datos.Contexto;
using Datos.Operacion;
using Dominio.Interface.Repositorio;
using Dominio.Modelo;
using GestionTareaAPI.Filtros;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region "Cors"

var misReglasCors = "ReglasCors";

builder.Services.AddCors(p => p.AddPolicy(misReglasCors, builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Configuration.AddJsonFile("appsettings.json");
var secretKey = builder.Configuration.GetSection("settings").GetSection("secretKey").ToString();
var keyBytes = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(config => {

    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config => {
    config.RequireHttpsMetadata = false;
    config.SaveToken = false;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

#endregion


#region "Inyección de dependencias"

//Cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("GestionTarea");
builder.Services.AddDbContext<GestionTareaContexto>(x =>
{
    x.UseSqlServer(connectionString);
    x.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddTransient<GestionTareaContexto>();

//Inyección para las operaciones
builder.Services.AddTransient<IRepoAutenticacion<AutenticacionDom, string>, AutenticacionOpe>();
builder.Services.AddTransient<IRepoBase<EstadoDom, string>, EstadoOpe>();
builder.Services.AddTransient<IRepoBase<PersonaDom, string>, PersonaOpe>();
builder.Services.AddTransient<IRepoBase<PrioridadDom, string>, PrioridadOpe>();
builder.Services.AddTransient<IRepoTarea<TareaDom, int>, TareaOpe>();

//Inyección para los servicios
builder.Services.AddTransient<IServAutenticacion<AutenticacionDom, string>, AutenticacionServ>();
builder.Services.AddTransient<IServBase<EstadoDom, string>, EstadoServ>();
builder.Services.AddTransient<IServBase<PersonaDom, string>, PersonaServ>();
builder.Services.AddTransient<IServBase<PrioridadDom, string>, PrioridadServ>();
builder.Services.AddTransient<IServTarea<TareaDom, int>, TareaServ>();

#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{

    //Configuarcion de la seguridad para swagger
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Token"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type=ReferenceType.SecurityScheme,
                Id="Bearer"
            }
        },
        new string[]{}
        }
    });

    //Configuarcion de parametros por defecto en los end point para swagger
    options.OperationFilter<AcepteLenguajeHeader>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Util para la autenticacion jwt
app.UseStaticFiles();

app.UseRouting();

//Se habilita los Cors
app.UseCors(misReglasCors);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
