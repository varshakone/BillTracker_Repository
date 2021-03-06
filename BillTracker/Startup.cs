﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillTracker.BusinessLayer.Interface;
using BillTracker.BusinessLayer.Service;
using BillTracker.BusinessLayer.Service.Repository;
using BillTracker.DataLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BillTracker
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<MongoSettings>(Options =>
            {

                Options.Connection = Configuration.GetSection("MongoConnection:Connection").Value;
                Options.DatabaseName = Configuration.GetSection("MongoConnection:DatabaseName").Value;
                if (Options.Connection == null && Options.DatabaseName == null)
                {
                    Options.Connection =
                    "mongodb://user:password@127.0.0.1:27017/guestbook";
                    Options.DatabaseName = "guestbook";
                }

            });
            services.AddScoped<IMongoDBContext, MongoDBContext>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBillService, BillService>();
            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
