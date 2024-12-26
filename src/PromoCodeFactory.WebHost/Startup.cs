using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Services.Abstractions;
using PromoCodeFactory.Core.Services.Implementations;
using PromoCodeFactory.DataAccess;
using PromoCodeFactory.DataAccess.Repositories;

namespace PromoCodeFactory.WebHost
{
	public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            //services.AddAutoMapper(cfg =>
            //{
            //	cfg.AddProfile<EmployeeProfile>();
            //	cfg.AddProfile<RoleProfile>();
            //	cfg.AddProfile<CustomerProfile>();
            //	cfg.AddProfile<PreferenceProfile>();
            //	cfg.AddProfile<PromoCodeProfile>();
            //}, AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            services.AddDbContext<DataContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlite("Filename=PromoCodeFactory.db")
                .UseSnakeCaseNamingConvention()
                .UseLazyLoadingProxies();
            });

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IPreferenceService, PreferenceService>();
            services.AddScoped<IPromoCodeService, PromoCodeService>();

            services.AddControllers().AddMvcOptions(x => x.SuppressAsyncSuffixInActionNames = false);

            services.AddOpenApiDocument(options =>
            {
                options.Title = "PromoCode Factory API Doc";
                options.Version = "1.0";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseOpenApi();
            app.UseSwaggerUi(x =>
            {
                x.DocExpansion = "list";
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
