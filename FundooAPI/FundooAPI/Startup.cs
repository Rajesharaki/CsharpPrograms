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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FundooRepository.DBContext;
using BusinessManager.Interface;
using BusinessManager.Manager;

namespace FundooAPI
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
            services.AddDbContextPool<AppDBContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DBCS"),
                b=>b.MigrationsAssembly("FundooAPI")));
            services.AddIdentity<IdentityUser, IdentityRole>(options=> 
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 10;
                options.Password.RequireLowercase=false;
                options.Password.RequireUppercase = false;
            }).
            AddEntityFrameworkStores<AppDBContext>()
            .AddDefaultTokenProviders();
            services.AddTransient<IAccount, IAccountImplementation>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
