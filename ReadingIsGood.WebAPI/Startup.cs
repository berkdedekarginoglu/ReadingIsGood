using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ReadingIsGood.Core.DependencyResolver;
using ReadingIsGood.Core.Extensions;
using ReadingIsGood.Core.Utilities.IoC;
using ReadingIsGood.Core.Utilities.Security.Encyption;
using ReadingIsGood.Core.Utilities.Security.Jwt;
using ReadingIsGood.WebAPI.Extensions;

namespace ReadingIsGood.WebAPI
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
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));

            services.AddJwtAuthentication(tokenOptions);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ReadingIsGood.WebAPI", Version = "v1" });
            });

            services.AddFileLogger(Configuration);

            services.AddDependencyResolvers(new ICoreModule[]
           {
                new CoreModule(),
           });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReadingIsGood.WebAPI v1"));
            }

            app.UseExceptionHandler("/errors");
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
