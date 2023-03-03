using Microsoft.EntityFrameworkCore;
using StructuredCablingStudio.Data.Contexts;
using StructuredCablingStudio.Data.Entities;
using StructuredCablingStudio.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
//Подумать перенести в екстеншн
builder.Services.AddScoped<IApplicationRepository<CablingConfigurationEntity>, DbApplicationRepository>();
string? connstr = builder.Configuration.GetConnectionString("CablingConfigurationsDB");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite(connstr));

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
//app.UseAuthorization();

//Прочитать
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
