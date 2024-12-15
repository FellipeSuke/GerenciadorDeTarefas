using GerenciadorDeTarefas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Configurar o DbContext com a string de conexão
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=sukeserver.ddns.net,1433;Database=GerenciadorDeTarefas;User Id=sa;Password=avaliacaoJoao@123;TrustServerCertificate=True;"));

// Configuração do Kestrel para escutar HTTP e HTTPS
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(80);  // Para HTTP

    if (builder.Environment.IsDevelopment())
    {
        // Ambiente de Desenvolvimento - Caminho local para o certificado
        string certificatePath = Path.Combine(builder.Environment.ContentRootPath, "Data", "certificado.pfx");
        options.ListenAnyIP(443, listenOptions =>  // Para HTTPS
        {
            listenOptions.UseHttps(certificatePath, "123456789");
        });
    }
    else
    {
        // Ambiente de Produção (Docker) - Caminho dentro do container
        options.ListenAnyIP(443, listenOptions =>  // Para HTTPS
        {
            listenOptions.UseHttps("/root/.aspnet/https/certificado.pfx", "123456789");
        });
    }
});

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
