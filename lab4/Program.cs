using lab4.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

internal class Program {
    private static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);

        string connectionString = builder.Configuration.GetConnectionString("MSSQL");
        builder.Services.AddDbContext<InsuranceCompanyContext>(option => option.UseSqlServer(connectionString));
        builder.Services.AddControllersWithViews(options => {
            options.CacheProfiles.Add("ModelCache",
                new CacheProfile() {
                    Location = ResponseCacheLocation.Any,
                    Duration = 2*16+240
                });
        });

        var app = builder.Build();

        if (!app.Environment.IsDevelopment()) {
            app.UseExceptionHandler("/Home/Error");
        }

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.MapControllerRoute(
            name: "agentType",
            pattern: "{controller=AgentType}/{action=ShowTable}");

        app.MapControllerRoute(
            name: "contract",
            pattern: "{controller=Contract}/{action=ShowTable}");

        app.MapControllerRoute(
            name: "insuranceAgent",
            pattern: "{controller=InsuranceAgent}/{action=ShowTable}");

        app.Run();
    }
}