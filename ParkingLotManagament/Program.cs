using Microsoft.EntityFrameworkCore;
using ParkingLotManagament.BLL.IServices;
using ParkingLotManagament.BLL.Services;
using ParkingLotManagament.DAL.IRepositories;
using ParkingLotManagament.DAL.Repositories;
using ParkingLotManagament.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// add database dependecy
_ = builder.Services.AddDbContext<ParkingLotManagementDatabaseContext>(c =>
{
    c.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    c.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

});

// Adding Automapper dependency into program
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Inject classes into Program
builder.Services.AddScoped<IParkingLotRepository,ParkingLotRepository>();
builder.Services.AddScoped<IParkingLotService,ParkingLotService>();
builder.Services.AddScoped<IPricingPlansRepository, PricingPlanRepository>();
builder.Services.AddScoped<IPricingPlanService,PricingPlanService>();
builder.Services.AddScoped<ISubscriptionRepository,SubscriptionRepository>();
builder.Services.AddScoped<ISubscriptionService,SubscriptionService>();
builder.Services.AddScoped<ILogRepository,LogRepository>();
builder.Services.AddScoped<ILogService,LogService>();
builder.Services.AddScoped<ISubscriberRepository, SubscriberRepository>();
builder.Services.AddScoped<ISubscriberService, SubscriberService>();

var app = builder.Build();

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
