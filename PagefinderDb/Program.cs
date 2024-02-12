
using Microsoft.EntityFrameworkCore;
using PagefinderDb.Data;
using System.Text.Json.Serialization;

namespace PagefinderDb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddCors();

            builder.Services.AddDbContext<PagefinderDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("PagefinderDbContext"));
            });
            builder.Services.AddControllers().AddJsonOptions((c) =>
            {
                c.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment()) //Enable swagger always for now
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            app.UseCors(c =>
            {
                c
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            });
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
