using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using HollywoodBets.DAL;
using HollywoodBets.Models.Model;
using HollywoodBets.Repository.DAL;
using HollywoodBets.Repository.Repository.Implementation;
using HollywoodBets.Repository.Repository.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HolluwoodBets
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
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddDbContext<HollywoodBetsDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MyConnection"));
            });
            services.AddControllers();

            services.AddScoped<IDb, DatabaseService>();
            services.AddScoped<ISportTree, SportTreeRepository>();
            services.AddScoped<ICountry, CountryRepository>();
            services.AddScoped<ITournament, TournamentRepository>();
            services.AddScoped<IBetType, BetTypeRepository>();
            services.AddScoped<IEvent,EventRepository>();
            services.AddScoped<IMarket, MarketRepository>();
            services.AddScoped<IBetSlip, BetSlipRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWorkRepository>();
            services.AddScoped<IOdds, IOddsRepository>();
          
    
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("MyPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            loggerFactory.AddLog4Net();
        }
    }
}
