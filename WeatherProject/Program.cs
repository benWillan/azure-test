namespace WeatherProject;

public class Program
{
    public static void Main(string[] args)
    {
        /* BUILDER */
        var builder = WebApplication.CreateBuilder(args);

        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Logging.SetMinimumLevel(LogLevel.Information);

        Console.WriteLine("This is a test log");

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        /* APP */
        var app = builder.Build();
        
        var logger = app.Services.GetRequiredService<ILogger<Program>>();

        // Log environment
        logger.LogInformation("Test logging info");

        // Log connection string (first 20 chars for safety)

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
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}