﻿using BusinessManager.Interface;
using BusinessManager.Manager;
using FundooAPI.Controllers;
using FundooRepository.DBContext;
using FundooRepository.Interface;
using FundooRepository.Manager;
using jdk.nashorn.@internal.runtime;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Text;

namespace FundooAPI
{
    /// <summary>
    /// StartUp Classs
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// StartUp class constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// IConfiguration property
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            ////Register The DbContext
            services.AddDbContextPool<AppDBContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DBCS"),
                b => b.MigrationsAssembly("FundooAPI")));

            ////Register the Identity
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 10;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).
            AddEntityFrameworkStores<AppDBContext>()
            .AddDefaultTokenProviders();

            services.AddTransient<IAccount, IAccountImplementation>();
            services.AddTransient<INotes, INotesImplementation>();
            services.AddTransient<INoteRepositary, INotesRepositaryImplementation>();
            services.AddTransient<ILabel, ILabelImplementation>();
            services.AddTransient<ILabelRepositary, ILabelRepositaryImplementation>();

            ///Enable CORS
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                 {
                     builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().Build();
                 });
            });

            ////Register the MVC
            services.AddMvc(config =>
            {
                config.ReturnHttpNotAcceptable = true;
                config.InputFormatters.Add(new XmlSerializerInputFormatter()); //It can take xml request also
                config.OutputFormatters.Add(new XmlSerializerOutputFormatter()); //it can response in xml format also
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Register the SwaggerGen
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("V2", new Info
                {
                    Title = "Fundoo API",
                    Version = "V2"
                });

                //Provide api path
                var xmlpath = AppDomain.CurrentDomain.BaseDirectory + @"FundooAPI.xml";

                //Its includes comments in swagger UI
                options.IncludeXmlComments(xmlpath);
                options.AddSecurityDefinition("oauth2", new ApiKeyScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = "header",
                    Name = "Authorization",
                    Type = "apiKey"
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            ////Register the Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = Configuration["JWT:Issuer"],
                    ValidAudience = Configuration["JWT:Audiance"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:SigninKey"])),
                    RequireExpirationTime = true
                };
            }).AddGoogle(options =>
            {
                options.ClientId = "66608066577-l1jbv5rqpse8rke17cstafpi9uh7st3e.apps.googleusercontent.com";
                options.ClientSecret = "z1CXkE9pNKCsOA8gVJJdNx8i";
            });

            //// Register the Redis Cache
            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = "localhost:6379";
                options.InstanceName = "Fundoo";
            });

        }
        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
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

            app.UseCors("EnableCORS");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/V2/Swagger.json", "SwaggerEndpoint");
            });
        }
    }
}
