
using ApI_task.Data;
using ApI_task.Repositories;
using ApI_task.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace ApI_task
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkNpgsql()
                .AddDbContext<SistemaTarefasDBContext>(
                    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase"))
                );

            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepository>();


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
}