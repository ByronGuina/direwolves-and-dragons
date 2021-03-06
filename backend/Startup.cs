﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace backend
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
      //   services.AddCors(options =>
      //   {
      //     options.AddPolicy("MyCors",
      //           builder =>
      //           {
      //             // builder.WithOrigins(
      //             //     "http://localhost:3000",
      //             //     "https://localhost:3000",
      //             //     "https://direwolvesndragons.netlify.com"
      //             // );

      //             // Allow any origin for the sake of the project. Normally we'd restrict origin domains
      //             // to the domains we control.
      //             builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
      //           });
      //   });

      services.AddCors();
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


      // Set up the database context using the in memory database we created.
      services.AddDbContext<InMemoryDbContext>(options => options.UseInMemoryDatabase(databaseName: "Direwolves & Dragons"));
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
        // Normally this would be enabled. Disable it for the sake of more accessible demoing.
        // app.UseHsts();
      }

      // Allow any origin for the sake of the project. Normally we'd restrict origin domains
      // to the domains we control.
      app.UseCors(builder =>
      {
        builder
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader();
      });

      // Normally this would be enabled. Disable it for the sake of more accessible demoing.
      //   app.UseHttpsRedirection();
      app.UseMvc();
    }
  }
}
