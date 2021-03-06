using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Inter.Web.Database.Repositories;
using System.Data;
using System.Data.SqlClient;

namespace Inter.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddTransient<IDbConnection>(p=>new SqlConnection(@"Integrated Security = SSPI; Persist Security Info = False; Initial Catalog = Internety; Data Source =.\SQLEXPRESS;"));
            services.AddScoped<TransactionsRepository>();
            // TransactionsRepository repo = new TransactionsRepository();
            // repo.GetTransactionsInfo(new Database.Models.TransactionFilter(){
            //     FinishDate = DateTime.Now.AddDays(2),
            //     //StartDate = DateTime.Now,
            //     InternetTypeIds = new List<long>(){
            //         1, 2, 3
            //     },
            //     OfficeId = 4,
            //     WorkerIds = new List<long>() {
            //         4, 65, 78
            //     }
            // });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
