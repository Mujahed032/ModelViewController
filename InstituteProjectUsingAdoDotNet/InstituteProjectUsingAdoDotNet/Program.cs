using AutoMapper;
using InstituteProjectUsingAdoDotNet.Interface;
using InstituteProjectUsingAdoDotNet.Repository;

namespace InstituteProjectUsingAdoDotNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           

            // Add services to the container.

            // Access configuration from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("Default");
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddSingleton<IStudentRepository>(new StudentRepository(connectionString));

            // Register your repository with the connection string
            builder.Services.AddSingleton<ICourseRepository>(new CourseRepository(connectionString));

            // Add services to the container.

            builder.Services.AddControllers();
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