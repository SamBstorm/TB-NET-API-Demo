
using API_DBSlide.Context;

namespace API_DBSlide
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Ajout services
            //builder.Services.AddTransient<IStudentContext, StudentService>();   //Crée toujours une nouvelle instance
            //builder.Services.AddSingleton<IStudentContext, StudentService>();   //Crée une seule instance dans l'ensemble de l'application

            builder.Services.AddScoped<IStudentContext, StudentService>();   //Crée une seule instance par scope d'utilisation

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
        }
    }
}
