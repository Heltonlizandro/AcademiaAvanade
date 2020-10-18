using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VoosAPI.Models;
using VoosAPI.Services;

namespace VoosAPI
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
            services.Configure<VoosDatabaseSettings>(
                Configuration.GetSection(nameof(VoosDatabaseSettings)));

            services.AddSingleton<IVoosDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<VoosDatabaseSettings>>().Value);

            services.AddSingleton<VoosService>();

            services.Configure<CiasDatabaseSettings>(
                Configuration.GetSection(nameof(CiasDatabaseSettings)));

            services.AddSingleton<ICiasDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<CiasDatabaseSettings>>().Value);
            
            services.AddSingleton<CiasService>();
            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
