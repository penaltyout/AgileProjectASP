using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BookingWebsite.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BookingWebsite
{
    public class Startup
    {
      
        public void ConfigureServices(IServiceCollection services)
        {
            var connString = @"Data Source=bookinz.database.windows.net;Initial Catalog=Bookinz;Persist Security Info=True;User ID=bookinz;Password=8zb-KqP-7Uz-ycA";
            //var connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TempDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" ;
            services.AddDbContext<HotelASPContext>(options =>
                options.UseSqlServer(connString));
            services.AddDbContext<IdentityDbContext>(o => o.UseSqlServer(connString));
            services.AddIdentity<IdentityUser, IdentityRole>().
            AddEntityFrameworkStores<IdentityDbContext>().

            AddDefaultTokenProviders();

            services.AddSession();
            services.AddMemoryCache();
            services.AddMvc();

        }

       
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            

            if (env.IsDevelopment())
            {
                app.UseStaticFiles();
                app.UseSession();
                app.UseDeveloperExceptionPage();
                app.UseIdentity();
                app.UseMvcWithDefaultRoute();
            }

       
        }
    }
}
