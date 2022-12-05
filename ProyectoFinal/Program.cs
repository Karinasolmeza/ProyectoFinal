using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
    

//Autenticación por cookie 
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
   .AddCookie(option =>
    {
        option.LoginPath = "/Acceso/Index"; //Especificar página logueo
        option.ExpireTimeSpan = TimeSpan.FromMinutes(20);//expiración en 20 minutos
        option.AccessDeniedPath = "/Home/Privacy";//Acceso denegado redirige a Privacy o cambiar 

    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();//Debe tener los dos app.useAuthentication y useAuthorization

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Acceso}/{action=Index}/{id?}");

app.Run();
