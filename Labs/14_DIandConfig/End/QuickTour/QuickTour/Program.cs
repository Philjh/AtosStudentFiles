using QuickTour.Middleware;
using QuickTour.Models;

namespace QuickTour
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IForumContext, MockForumContext>();

            builder.Services.AddTransient<ITransient, TransientDependency>();
            builder.Services.AddScoped<IScoped, ScopedDependency>();
            builder.Services.AddSingleton<ISingleton, SingletonDependency>();

            var app = builder.Build();

            app.UseMiddleware<CustomMiddleware1>();
            app.UseMiddleware<CustomMiddleware2>();

            // Configure the HTTP request pipeline.
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
                pattern: "{controller=Forum}/{action=Index}/{id?}");

            app.Run();
        }
    }
}