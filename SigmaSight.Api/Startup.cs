using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SigmaSight.Infrastructure.Interfaces;
using SigmaSight.Infrastructure.Services;
using SigmaSight.Services;

namespace SigmaSight.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    //TODO Add a TokenService and Auth
    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddControllersWithViews();
        services.AddHttpClient();
        services.AddLogging();

        services.AddTransient<ISQSService, SQSService>()
            .AddTransient<MachineRuntimeService, MachineRuntimeService>();


    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sigma Sight Factory Floor");
        });

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");
        });

        //    endpoints.MapGet("/", async context =>
        //    {
        //        await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
        //    });
        //});

        //app.UseEndpoints(endpoints =>
        //{
        //    endpoints.MapControllers();
        //    endpoints.MapGet("/", async context =>
        //    {
        //        await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
        //    });
        //});
    }

    private bool IsTokenLifetimeValid(DateTime? notBefore, DateTime? expires, SecurityToken  tokenToValidate, TokenValidationParameters @param)
    {
        var result = true;

        if(notBefore.HasValue && tokenToValidate.ValidFrom < notBefore.Value)
        {
            result = false;
        }

        if(result && expires.HasValue && DateTime.UtcNow >= expires.Value)
        {
            result = false;
        }
        return result;
    }
}