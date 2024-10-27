using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;
using TransportationSystem.UI.Contracts.Account;
using TransportationSystem.UI.Contracts.LocalStorage;
using TransportationSystem.UI.Sevices.Account;
using TransportationSystem.UI.Sevices.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddHttpContextAccessor();
builder.Services.Configure<CookiePolicyOptions>(option =>
{
	option.MinimumSameSitePolicy = SameSiteMode.None;
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
	AddCookie(option =>
	{
		option.LoginPath = "/Account/Login";
	});
var buill = builder.Configuration.GetSection("ApiAddress").Value;
builder.Services.AddHttpClient<IClient, Client>(p => p.BaseAddress = new Uri(buill));

// Add services to the container.
builder.Services.AddControllersWithViews();




builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();
builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();


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


app.MapControllerRoute(name: "default",
			   pattern: "{controller=Account}/{action=Login}/{id?}");
app.MapControllerRoute(name: "Home",
				pattern: "Home/{*Index}",
				defaults: new { controller = "Home", action = "Index" });


app.Run();
