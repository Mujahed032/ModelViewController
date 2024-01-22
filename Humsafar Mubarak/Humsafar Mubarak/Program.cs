using Humsafar_Mubarak.Data;
using Humsafar_Mubarak.Helpers;
using Humsafar_Mubarak.Interface;
using Humsafar_Mubarak.Repository;
using Humsafar_Mubarak.Services;
using Microsoft.EntityFrameworkCore;


namespace Humsafar_Mubarak
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<ICandidateProfileRepository, CandidateProfileRepository>();
            builder.Services.AddScoped<IphotoServices, PhotoServices>();
            builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));
            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    if (!context.CandidateProfiles.Any())
                    {
                        Seed.SeedData(app);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while seeding the database.");
                    Console.WriteLine(ex.Message);
                }
            }

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
