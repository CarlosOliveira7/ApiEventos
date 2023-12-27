using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyApi.Data;
using MyApi.Models;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddDbContext<AppDbContext>(Options =>
        {
            Options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        builder.Services.AddControllers();


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
    }
}