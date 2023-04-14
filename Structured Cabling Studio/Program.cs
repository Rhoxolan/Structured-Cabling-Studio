using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using StructuredCablingStudio.Data.Contexts;
using StructuredCablingStudio.Data.Entities;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
	.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
	.AddDataAnnotationsLocalization();

builder.Services.AddIdentity<User, IdentityRole>()
	.AddEntityFrameworkStores<ApplicationContext>();

builder.Services.AddDbContext<ApplicationContext>(opt
	=> opt.UseSqlServer(builder.Configuration.GetConnectionString("CablingConfigurationsDB")))
	.AddLocalization(opt => opt.ResourcesPath = "Resources")
	.Configure<RequestLocalizationOptions>(opt =>
	{
		var supportedCultures = new[]
		{
			new CultureInfo("ru"),
			new CultureInfo("en"),
			new CultureInfo("uk")
		};
		opt.DefaultRequestCulture = new RequestCulture("en");
		opt.SupportedCultures = supportedCultures;
		opt.SupportedUICultures = supportedCultures;
	})
	.ConfigureApplicationCookie(opt =>
	{
		opt.LoginPath = "/Account/SignIn";
		opt.ReturnUrlParameter = "returnUrl";
	})
	.AddAuthentication()
	.AddGoogle(opt =>
	{
		var googleSection = builder.Configuration.GetSection("Authentication:Google");
		opt.ClientId = googleSection["ClientId"]!;
		opt.ClientSecret = googleSection["ClientSecret"]!;
	});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseHsts();
}
app.UseHttpsRedirection();
app.UseRequestLocalization();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Calculation}/{action=Calculate}/{id?}");

app.Run();
