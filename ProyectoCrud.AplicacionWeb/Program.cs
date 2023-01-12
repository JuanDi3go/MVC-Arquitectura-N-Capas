using Microsoft.EntityFrameworkCore;
using ProyectoCrud.BLL.Service;
using ProyectoCrud.DAL.DataContext;
using ProyectoCrud.DAL.Repositorie;
using ProyectoCrud.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CeArquitecturaNcapasContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL")));

builder.Services.AddScoped<IGenericRepository<Contacto>, ContactRepository>();
builder.Services.AddScoped<IContactoService,ContactoService>();


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
