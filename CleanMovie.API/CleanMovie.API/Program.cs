using CleanMovie.Application.Services;
using CleanMovie.Infrastructure.Persistence;
using CleanMovie.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Register Cnfigurations
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Database Service
builder.Services.AddDbContext<MovieDbContext>(o => 
    o.UseNpgsql(builder.Configuration.GetConnectionString("Ef_MovieDb"),
        npgsqlOptions => npgsqlOptions.MigrationsAssembly("CleanMovie.Infrastructure")));


//Register Services in here
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

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
