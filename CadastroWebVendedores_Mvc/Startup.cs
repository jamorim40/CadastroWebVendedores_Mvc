using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CadastroWebVendedores_Mvc.Data;
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
    }

    // Equivalente ao Configure do .NET Core 2.1
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
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
