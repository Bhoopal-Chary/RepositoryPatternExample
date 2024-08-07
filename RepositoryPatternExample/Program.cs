using Microsoft.EntityFrameworkCore;
using RepositoryPatternExample.Data;
using RepositoryPatternExample.Interfaces;
using RepositoryPatternExample.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration()
	.WriteTo.Console()
	.CreateLogger();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IEmployeeRepository, EmployeeService>();
builder.Services.AddTransient<ILoggerHelper, LoggerHelper>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Host.UseSerilog((context, loggerConfiguration) =>
{
	loggerConfiguration.WriteTo.Console();
	//loggerConfiguration.WriteTo.File();
	loggerConfiguration.ReadFrom.Configuration(context.Configuration);
});
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
