using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            services.AddDbContext<DataContext>(optionsBuilder =>
            {
                optionsBuilder
                    .UseNpgsql(Configuration.GetConnectionString("PostgresDb"))
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
