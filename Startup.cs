using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiNetcore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(
                routes =>
                {
                    routes.MapRoute(
                    name: "RocketsRouteGet",
                    template: "api/RocketsRoute/{id:int?}", 
                    defaults: new { controller = "RocketsRoute", action = "Get" });

                    routes.MapRoute(
                    name: "RocketsRoutePost",
                    template: "api/RocketsRoute/{id:int?}",
                    defaults: new { controller = "RocketsRoute", action = "Post" });

                    routes.MapRoute(
                    name: "RocketsRoutePut",
                    template: "api/RocketsRoute/{id:int?}",
                    defaults: new { controller = "RocketsRoute", action = "Put" });

                    routes.MapRoute(
                    name: "RocketsRoutePatch",
                    template: "api/RocketsRoute/{id:int?}",
                    defaults: new { controller = "RocketsRoute", action = "Patch" });


                });
        }
    }
}
