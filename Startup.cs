using grad2021.Data;
using grad2021.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grad2021
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
            SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder();
            connectionString.DataSource = Environment.GetEnvironmentVariable("DB_HOST") ?? "";
            connectionString.UserID = Environment.GetEnvironmentVariable("DB_USER") ?? "";
            connectionString.Password = Environment.GetEnvironmentVariable("DB_PASS") ?? "";
            connectionString.InitialCatalog = Environment.GetEnvironmentVariable("DB_NAME") ?? "";
            connectionString.Pooling = true;

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")== "Development")
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("LocalDbConnection")));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionString.ConnectionString));
            }
            services.AddIdentity<IdentityUser, IdentityRole>(options => {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.AllowedUserNameCharacters = null;
            })
                .AddDefaultUI()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddDatabaseDeveloperPageExceptionFilter();

            //services.AddDefaultIdentity<IdentityUser>(options => {
            //    options.SignIn.RequireConfirmedAccount = false;
            //    options.User.AllowedUserNameCharacters = null;
            //}).AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddAuthorization(options => {
                options.AddPolicy("readpolicy",
                    builder => builder.RequireRole("Student", "Instructor", "ControlAdmin", "SystemAdmin", "StudentAffairs"));
                options.AddPolicy("writepolicy",
                    builder => builder.RequireRole("SystemAdmin"));
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
                app.UseExceptionHandler("/Home/Error");
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
