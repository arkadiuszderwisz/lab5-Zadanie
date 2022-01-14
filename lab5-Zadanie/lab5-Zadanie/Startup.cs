using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lab5_Zadanie.Models;

namespace lab5_Zadanie
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
            services.AddSwaggerGen(c =>
                {
                    c.EnableAnnotations();
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "zadanie lab5",
                        Version = "v1",
                        Description = "Moje API do obsługi zadań",
                        Contact = new OpenApiContact { Name = "AD", Email = "arekderwisz@jakismail.com" },
                        License = new OpenApiLicense { Name = "Github", Url = new System.Uri("http://github.com/arkadiuszderwisz/license") }
                    });
                });
            services.AddDbContext<MoviesContext>(opt => opt.UseInMemoryDatabase("MoviesList"));
            services.AddMvc();
            services.AddControllers();
            services.AddDbContext<MoviesContext>(options => options.UseInMemoryDatabase(databaseName: "Movies"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "lab5_Zadanie v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
