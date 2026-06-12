using EvNet.Domain.DataAccess;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using EvNet.Web.Components;
using EvNet.Domain.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/";
        options.AccessDeniedPath = "/";
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
        options.SlidingExpiration = true;
    });

builder.Services.AddAuthorization()
    .AddCascadingAuthenticationState()
    .AddHttpContextAccessor()
    .AddDbContext<EvNetContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("EvNetEntities")));

builder.Services.AddScoped<ClienteAccess>();
builder.Services.AddScoped<CiudadAccess>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles()
    .UseAuthentication()
    .UseAuthorization()
    .UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
