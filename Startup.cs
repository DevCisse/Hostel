using CurrieTechnologies.Razor.SweetAlert2;
using Hostel.Data;
using Hostel.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Hostel
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

            services.AddAntDesign();
            services.AddScoped<Hostel.Services.HostelAllocationServices>();

            services.AddServerSideBlazor();

            services.AddSweetAlert2();

            //services.AddDbContext<ApplicationDbContext>(options =>

            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));


            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
  .AddRoles<IdentityRole>() //Line that can help you
  .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging();
                // options.LogTo(Console.WriteLine(""),Microsoft.Extensions.Logging.LogLevel.Information)
            });

            services.AddDatabaseDeveloperPageExceptionFilter();

            //services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddDefaultIdentity<ApplicationUser>(options =>
            //{
            //    options.SignIn.RequireConfirmedAccount = true;

            //}).AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();



            RazorPagesOptions options = new RazorPagesOptions
            {
                RootDirectory = "/Dashboard"
            };
            //services.AddRazorPages(options =>{ options.RootDirectory = "/Dashboard"; });
            services.AddRazorPages();



            //   services.AddDefaultIdentity<ApplicationUser().AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();


            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");


            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

                endpoints.MapBlazorHub();

                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
