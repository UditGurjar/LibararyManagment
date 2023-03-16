using Library.DTO_Mapping;
using Library.Models;
using Library.Repository;
using Library.Repository.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
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
            //string cS = Configuration.GetConnectionString("con");
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(cS));

            services.AddEntityFrameworkSqlServer().
         AddDbContext<ApplicationDbContext>(options => options.UseSqlServer
        (Configuration.GetConnectionString("con"),
         b => b.MigrationsAssembly("Library")));

            services.AddAutoMapper(typeof(MappingProfile));
           
            // configure swagger options 
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Library", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: "Library",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            //jwt AuthenticTION
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSetting>(appSettingsSection);
            var appSetting = appSettingsSection.Get<AppSetting>();
            var key = Encoding.ASCII.GetBytes(appSetting.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = "206986272307-ansblv81ksjd6p43mmdh17lon8t64bdf.apps.googleusercontent.com";
                options.ClientSecret = "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";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library v1"));
            }
            app.UseCors("Library");
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
