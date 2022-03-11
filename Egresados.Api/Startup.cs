using Egresados.Api.Utils;
using Egresados.Data;
using Egresados.Data.Repositorio;
using Egresados.Model.Entities;
using Egresados.Services;
using Egresados.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egresados.Api
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
            services.AddDbContext<ApplicationDbContext>(options =>
                     options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                    .EnableSensitiveDataLogging());
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<Usuario, Rol>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Register the Swagger services
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Egresado API";
                };
            });


            services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));
            // Identity Services
            services.AddTransient<UserManager<Usuario>>();
            services.AddTransient<RoleManager<Rol>>();

            //AddScoped Interface, Services

            services.AddScoped<IEmailServices, EmailServices>();




            services.AddControllers().AddNewtonsoftJson(options =>
                                       options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;

            });


            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("SecretKey"));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            services.AddAutoMapper(typeof(AutoMapping));

            services.AddCors(options => {
                options.AddPolicy(name: "_MyCors", builder =>
                {
                    builder.SetIsOriginAllowed(origen => new Uri(origen).Host == Configuration.GetSection("Seguridad")["Origins_cor"])
                           .AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Egresados.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                     IWebHostEnvironment env,
                     UserManager<Usuario> userManager,
                     RoleManager<Rol> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3();
            //app.UseSwagger();
            //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fasani.Api v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("_MyCors");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            Seed(userManager, roleManager);
        }


        private async void Seed(UserManager<Usuario> userManager, RoleManager<Rol> roleManager)
        {

            SeedRoles(userManager, roleManager);
            SeedUserAdmin(userManager, roleManager);
            SeedUserEgresado(userManager, roleManager);
        }

        private async void SeedRoles(UserManager<Usuario> userManager, RoleManager<Rol> roleManager)
        {
            #region Rol
            if (!roleManager.RoleExistsAsync("Administrador").Result)
            {
                Rol role = new Rol();
                role.Name = "Administrador";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Compras").Result)
            {
                Rol role = new Rol();
                role.Name = "Compras";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Proveedor").Result)
            {
                Rol role = new Rol();
                role.Name = "Proveedor";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            #endregion
        }

        private async void SeedUserAdmin(UserManager<Usuario> userManager, RoleManager<Rol> roleManager)
        {
            #region Usuario

            string email = "admin@admin.com";

            string contrasena = "Admin1234";

            if (userManager.FindByNameAsync(email).Result == null)
            {
                Usuario user = new Usuario();
                user.UserName = email;
                user.Email = email;
                user.Name = "Administrador";
                user.LastName = "del Sistema";

                IdentityResult userResult = userManager.CreateAsync(user, contrasena).Result;
                if (userResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrador").Wait();
                }
            }
            #endregion
        }

        private async void SeedUserEgresado(UserManager<Usuario> userManager, RoleManager<Rol> roleManager)
        {
            #region Usuario

            string email = "compras@compras.com";

            string contrasena = "Admin1234";

            if (userManager.FindByNameAsync(email).Result == null)
            {
                Usuario user = new Usuario();
                user.UserName = email;
                user.Email = email;
                user.Name = "Sector";
                user.LastName = "Compras";

                IdentityResult userResult = userManager.CreateAsync(user, contrasena).Result;
                if (userResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Compras").Wait();
                }
            }
            #endregion
        }

    }
}
