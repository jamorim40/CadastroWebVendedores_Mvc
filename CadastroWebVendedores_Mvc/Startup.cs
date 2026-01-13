using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CadastroWebVendedores_Mvc.Data;
using Microsoft.Identity.Client;
using CadastroWebVendedores_Mvc.Services;
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // Equivalente ao ConfigureServices do .NET Core 2.1
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();

        services.AddDbContext<CadastroWebVendedores_MvcContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CadastroWebVendedores_MvcContext")));

        // Exemplo:
        // services.AddDbContext<AppDbContext>(options =>
        //     options.UseSqlServer(Configuration.GetConnectionString("Default")));

        // Registro do serviço para popular dados
        services.AddScoped<ServicoPopularDados>();

        // Registro do serviço de vendedor
        services.AddScoped<ServicoVendedor>();

        // Registro do serviço de departamento
        services.AddScoped<ServicoDepartamento>();
    }

    // Equivalente ao Configure do .NET Core 2.1

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        //Validar ambiente de desenvolvimento
        if (env.IsDevelopment()) //Se estiver em desenvolvimento
        {
            app.UseDeveloperExceptionPage();//Mostra detalhes dos erros
        }
        //Se não estiver em desenvolvimento
        else
        {
            app.UseExceptionHandler("/Home/Error");//Redireciona para a página de erro
            app.UseHsts();//Usa o HSTS (HTTP Strict Transport Security)
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ServicoPopularDados servicoPopularDados )
    {
        //Validar ambiente de desenvolvimento
        if (env.IsDevelopment()) //Se estiver em desenvolvimento
        {
            app.UseDeveloperExceptionPage();//Mostra detalhes dos erros
            //servicoPopularDados.PopularDados();// Popula o banco de dados com dados iniciais
        }
        //Se não estiver em desenvolvimento
        else
        {
            app.UseExceptionHandler("/Home/Error");//Redireciona para a página de erro
            app.UseHsts();//Usa o HSTS (HTTP Strict Transport Security)
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}
