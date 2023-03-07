using StructuredCablingStudio.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews()
	.AddLocalizationBasis();
builder.Services.AddCablingConfigurationsInteractionBasis(builder);
builder.Services.AddLocalizationBasis();
var app = builder.Build();

//Прочитать
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRequestLocalization();
app.UseStaticFiles();
app.UseRouting();
//app.UseAuthorization();

//Прочитать
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
