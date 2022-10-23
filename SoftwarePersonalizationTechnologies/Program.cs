using Api.DependencyInjection;
using Controllers;
using Controllers.ExceptionHandler;
using Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;
using NLog;
using NLog.Web;

var logger = LogManager.Setup()
    .LoadConfigurationFromAppSettings()
    .GetCurrentClassLogger();

try
{
    logger.Info($"Web Api Started");
    var builder = WebApplication.CreateBuilder(args);
    var connectionString = builder.Configuration.GetSection("ConnectionStrings");
    var conns = builder.Configuration.GetConnectionString("DockerConnection");
    var cacheConfig = builder.Configuration.GetSection("Caching").GetChildren()
        .ToDictionary(child => child.Key, child => TimeSpan.Parse(child.Value));
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddServices(conns, cacheConfig);
    builder.Services.AddIdentityServices(builder.Configuration);
    // Add services to the container.
    builder.Services.AddControllers()
                .AddNewtonsoftJson()
                .AddApplicationPart(typeof(AccountController).Assembly)
                .AddApplicationPart(typeof(AdminController).Assembly)
                .AddApplicationPart(typeof(BookingController).Assembly)
                .AddApplicationPart(typeof(HallsController).Assembly)
                .AddApplicationPart(typeof(ShowController).Assembly)
                .AddApplicationPart(typeof(UsersController).Assembly)
                .AddApplicationPart(typeof(HealthcheckController).Assembly);

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var app = builder.Build();
    using var scope = app.Services.CreateScope();

    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<BookingContext>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
    await context.Database.MigrateAsync();
    await Seed.SeedRolesAndAdmin(userManager, roleManager);
    await Seed.SeedCategories(context);
    await Seed.SeedHalls(context);
    //app.Configuration.ConfigureServicePointManager();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseDefaultFiles();
    app.UseMiddleware<ExceptionMiddleware>();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseCors(x => x.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .WithOrigins("https://localhost:4200"));

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}
