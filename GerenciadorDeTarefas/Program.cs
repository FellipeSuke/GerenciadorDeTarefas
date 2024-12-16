using GerenciadorDeTarefas.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

// Configuração do certificado HTTPS (opcional e baseado em ambiente)
var certPath = Environment.GetEnvironmentVariable("CERT_PATH")
               ?? Path.Combine(Directory.GetCurrentDirectory(), "Data", "certificado.pfx");
var certPassword = Environment.GetEnvironmentVariable("CERT_PASSWORD") ?? "123456789"; // senha do certificado auto-assinado Fellipe

if (File.Exists(certPath))
{
    builder.WebHost.ConfigureKestrel(options =>
    {
        options.ConfigureHttpsDefaults(httpsOptions =>
        {
            httpsOptions.ServerCertificate = new X509Certificate2(certPath, certPassword);
        });
    });
}
else
{
    Console.WriteLine("Certificado não encontrado. HTTPS não será configurado.");
}

// Configurar o DbContext com a string de conexão (usar variáveis de ambiente)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? "Server=sukeserver.ddns.net,8033;Database=GerenciadorDeTarefas;User Id=sa;Password=avaliacaoJoao@123;TrustServerCertificate=True;"; // conexão com banco de dados sem arquivo externo
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Adicionar serviços MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar o pipeline
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
