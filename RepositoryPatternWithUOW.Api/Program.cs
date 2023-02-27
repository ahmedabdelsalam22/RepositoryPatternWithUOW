using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositroyPatternWithUOW.Core;
using RepositroyPatternWithUOW.Core.Interfaces;
using RepositroyPatternWithUOW.EF;
using RepositroyPatternWithUOW.EF.Repositories;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


//get connextion string froms appsetting.json and put it in var to use it later..
var connectionSring = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(connectionString: connectionSring,
b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
);

//builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
