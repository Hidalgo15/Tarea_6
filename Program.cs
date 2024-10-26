using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddEndpointsApiExplorer();

//Configurar Swagger
builder.Services.AddSwaggerGen(c =>{

    c.SwaggerDoc("v1",new OpenApiInfo{
        Title = "Tarea 6",
        Version = "v1",
        Description = "Documentacion de Api con Swagger",
    });
});

var app = builder.Build();

//Habilitar Swagger y Swagger UI

if (app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
        c.RoutePrefix = string.Empty;//Suagger estara en la ruta raiz
    });
}


app.MapGet("/Tarea 6", () => "Bienvenido a mi Tarea_6");

//Asigancion
//Grupo de metodos
var trueGroup = app.MapGroup("/Asiganacion").WithTags("Asignaciones").WithDescription("Rutas");

//Noticias
trueGroup.MapGet("/noticias", () =>Paso1.Ejecutar());
//Registro de usuarios
trueGroup.MapPost("/Registro de usuarios", (Usuario u) =>MenejadorUsuario.Registro(u));
//Inicio de 
trueGroup.MapPost("/Iniciar_Sesion",(string cedula, string Clave)=>MenejadorUsuario.IniciarSesion( cedula,  Clave));   

trueGroup.MapPost("/Registro Incidencias", () =>Paso1.Ejecutar());

trueGroup.MapPost("/Clima", () =>Paso1.Ejecutar());

app.Run();

