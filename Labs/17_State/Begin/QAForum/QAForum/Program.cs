using Microsoft.EntityFrameworkCore;
using QAForum.EF;
using System.Configuration;

namespace QAForum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<ForumDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("Forum.Data")));
            
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            //app.UseStatusCodePagesWithReExecute("/Home/Status", "?code={0}");
            app.UseDeveloperExceptionPage();

            // Configure the HTTP request pipeline.
            //if (!app.Environment.IsDevelopment())
            //{

            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            //else
            //{
            //    app.UseDeveloperExceptionPage();
            //}

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