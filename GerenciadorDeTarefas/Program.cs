using GerenciadorDeTarefas.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

// Configurar o certificado HTTPS
var certPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "certificado.pfx"); //inserido certificado auto assinado para testes de deploy em ambiente docker (https://sukeserver.ddns.net:7245/)

builder.WebHost.ConfigureKestrel(options =>
{
    options.ConfigureHttpsDefaults(httpsOptions =>
    {
        httpsOptions.ServerCertificate = new X509Certificate2(certPath, "123456789"); // senha do certificado
    });
});

// Configurar o DbContext com a string de conexão
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=sukeserver.ddns.net,1433;Database=GerenciadorDeTarefas;User Id=sa;Password=avaliacaoJoao@123;TrustServerCertificate=True;")); //Banco SqlServer configurado para a aplicação e docker com acesso publico

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
