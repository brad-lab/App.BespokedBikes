using App.BespokedBikes.Application.Employees;
using App.BespokedBikes.Application.Products;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.FileProviders;
using System.Runtime.Loader;

namespace App.BespokedBikes.Presentation;

class Program
{
    static void Main(string[] args)
    {
        var files = Directory.GetFiles(
            AppDomain.CurrentDomain.BaseDirectory,
            "App.BespokedBikes*.dll");

        var assemblies = files
            .Select(p => AssemblyLoadContext.Default.LoadFromAssemblyPath(p));

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        // inside builder.Services configuration
        builder.Services.AddScoped<IProductValidator, ProductValidator>();
        builder.Services.AddScoped<IEmployeeValidator, EmployeeValidator>();

        builder.Services.Configure<RazorViewEngineOptions>(
            p => p.ViewLocationExpanders.Add(
                new CustomViewLocationExpander()));

        builder.Services.Scan(p => p.FromAssemblies(assemblies)
            .AddClasses()
            .AsMatchingInterface());

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");

            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles(
            new StaticFileOptions 
            {  
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "Content")),
                RequestPath = "/content"                 
            });

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.UseAdvancedDependencyInjection();

        app.Run();
    }
}