using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

#region 🔷 DATABASE (EF CORE + SQL SERVER)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);
#endregion

#region 🔷 REPOSITORIES (IMPORTANTÍSSIMO)
builder.Services.AddScoped<IRepositoryACL, RepositoryACL>();
builder.Services.AddScoped<IRepositoryPERFIL, RepositoryPERFIL>();
builder.Services.AddScoped<IRepositorySTATUS, RepositorySTATUS>();
builder.Services.AddScoped<IRepositoryUSUARIO, RepositoryUSUARIO>();


// ✅ MVC Completo (Controllers + Views) - Isso resolve o erro de ITempDataDictionaryFactory
builder.Services.AddControllersWithViews();
#endregion

#region 🔷 AUTHENTICATION 
builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/Account/Login";
    });
builder.Services.AddAuthorization();
#endregion
/*
#region 🔷 REDIRECT ROOT TO LOGIN
app.MapGet("/", context =>
{
    context.Response.Redirect("/Account/Login");
    return Task.CompletedTask;
});
#endregion
*/

#region 🔷 SWAGGER CONFIG
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "RKS",
        Version = "v1",
        Description = "API RKS"
    });
});
#endregion

var app = builder.Build();

#region 🔷 DEV TOOLS (SWAGGER ONLY IN DEVELOPMENT)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        options.RoutePrefix = "swagger";
    });
}
#endregion

#region 🔷 PIPELINE HTTP (ORDER IS IMPORTANT)

// ⚠️ Serve index.html, css, js from wwwroot
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// 🔥 EXCLUDE SWAGGER from status code system
app.UseWhen(ctx => !ctx.Request.Path.StartsWithSegments("/swagger"), appBuilder =>
{
    appBuilder.UseStatusCodePagesWithReExecute("/error/{0}");
});

// ✅ Put these directly here (Swagger ignores this automatically)
app.UseStatusCodePagesWithReExecute("/error/{0}");
app.UseExceptionHandler("/error/500");

// 🔥 Swagger redirect protection (KEEP THIS)
app.UseWhen(context => context.Request.Path.StartsWithSegments("/swagger"), appBuilder =>
{
    appBuilder.Use(async (context, next) =>
    {
        await next();

        if (context.Response.StatusCode == 404 &&
            !context.Request.Path.Value!.Equals("/swagger"))
        {
            context.Response.Redirect("/swagger");
        }
    });
});

#endregion

#region 🔷 MVC + API ROUTES 
// ✅ IMPORTANTE: Use este para suportar tanto API quanto MVC (Views)
app.MapControllers();                    // Controllers API + MVC

// Ou, se preferir separar claramente:
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
#endregion

#region 🔷 HEALTHCHECK / DEBUG ROUTES (OPTIONAL BUT USEFUL)

// ✔ Useful for Docker / monitoring
app.MapGet("/health", () => Results.Ok("Healthy"));

app.MapGet("/ping", () => "🏓 OK");

app.MapGet("/hello/{name}", (string name) =>
    Results.Ok($"Hello {name} 🌟"));

#endregion

//#region 🔷 SPA FALLBACK (FRONTEND ROUTING)
// ✔ Any unknown route → index.html (SPA behavior)
//app.MapFallbackToFile("index.html");
//#endregion

app.Run();