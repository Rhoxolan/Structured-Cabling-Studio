using StructuredCablingStudio.Extensions.AuthenticationBuilderExtensions;
using StructuredCablingStudio.Extensions.IMvcBuilderExtensions;
using StructuredCablingStudio.Extensions.IServiceCollectionExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
	.AddLocalizationBasis();
builder.Services.AddIdentityInteractionBasis();
builder.Services.AddDataInteractionBasis(builder)
	.AddLocalizationBasis()
	.AddAuthentication()
	.AddGoogleAuthentication(builder);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseHsts();
}
//Проверить, всё ли из этого необходимо ввиду добавления сервисов 
app.UseHttpsRedirection();
app.UseRequestLocalization();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
