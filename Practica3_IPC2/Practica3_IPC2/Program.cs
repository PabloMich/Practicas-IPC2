using Practica3_IPC2.Estructuras;

var builder = WebApplication.CreateBuilder(args);

// Activar MVC
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ListaMascotas>();

var app = builder.Build();

// Configuración del servidor
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Mascotas}/{action=Index}/{id?}");

app.Run();