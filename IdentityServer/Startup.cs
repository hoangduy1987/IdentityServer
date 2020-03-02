using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using IdentityServer.Configurations;

namespace IdentityServer
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
            services.AddControllers();

            // add identity server
            services.AddIdentityServer()
                    .AddDeveloperSigningCredential()
                    .AddInMemoryClients(Clients.Get())
                    .AddInMemoryIdentityResources(Configurations.Resources.GetIdentityResources())
                    .AddInMemoryApiResources(Configurations.Resources.GetApiResources())
                    .AddTestUsers(Users.Get());

            services.AddMvc();

            services.AddAuthentication("Bearer")
                    .AddIdentityServerAuthentication(options => 
                    {
                        options.Authority = "https://localhost:5001";
                        options.RequireHttpsMetadata = false;
                        options.ApiName = "customAPI";
                    });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseIdentityServer();
            app.UseStatusCodePages();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
