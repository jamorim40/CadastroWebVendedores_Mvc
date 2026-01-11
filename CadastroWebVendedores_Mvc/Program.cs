var builder = WebApplication.CreateBuilder(args);

// Criando a instância do Startup
var startup = new Startup(builder.Configuration);

// Chamando ConfigureServices manualmente
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Chamando Configure manualmente
startup.Configure(app, app.Environment);

app.Run();
