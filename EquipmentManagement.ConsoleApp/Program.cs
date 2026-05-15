// ASP.Net Core - WEB App

// Builder de um servidor web
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// Criação da instância do servidor
WebApplication app = builder.Build();

// Middlewares - São funções que executam em cada chamada que o servidor vai receber
app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();

// Inicia o loop da aplicação
app.Run();