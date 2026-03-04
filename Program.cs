using ContactList.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IContactRepository, StaticContactRepository>();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contact}/{action=Index}/{id?}");

app.Run();
