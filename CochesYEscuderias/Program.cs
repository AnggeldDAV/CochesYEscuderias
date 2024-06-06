using CochesYEscuderias.Models;
using CochesYEscuderias.Services.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CochesContext>();
builder.Services.AddScoped<ICocheRepositorio,EFCocheRepositorio>();
builder.Services.AddScoped<IRepositorio<Escuderia>, FakeEscuderiaRepositorio>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
