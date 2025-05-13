using ApiPersonajesAWS.Data;
using ApiPersonajesAWS.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsEnabled",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

string connectionString = builder.Configuration.GetConnectionString("MySql");
builder.Services.AddDbContext<PersonajesContext>(options =>
    options.UseMySQL(connectionString));

builder.Services.AddTransient<RepositoryPersonaje>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.MapScalarApiReference();
app.MapOpenApi();

app.UseCors("CorsEnabled");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
