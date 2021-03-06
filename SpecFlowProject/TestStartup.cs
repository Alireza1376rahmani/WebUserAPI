using AutoMapper;
using Domain;
using InfraStructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUserAPI.Controllers;
using WebUserAPI.Model;
using WebUserAPI.Model.mappings;
using WebUserAPI.Services;

namespace SpecFlowProject
{
    public class TestStartup
    {
        public TestStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc();

            services.AddDbContext<MyContext>();
            var assembly = typeof(PrincipalController).Assembly;

            services.AddScoped<IRepository<Domain.Principal>, PrincipalDBRepository>();
            services.AddScoped<IRepository<Party>, PartyDBRepository>();

            services.AddScoped<IPrincipalService, PrincipalService>();
            services.AddScoped<IPartyService, PartyService>();

            services.AddControllers()
                .AddApplicationPart(assembly);
        }
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
