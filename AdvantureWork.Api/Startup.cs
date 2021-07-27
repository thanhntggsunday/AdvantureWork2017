using AdvantureWork.BusinessService.ADO.Interface;
using AdvantureWork.BusinessService.ADO.ServiceImp;
using AdvantureWork.BusinessService.Interface;
using AdvantureWork.BusinessService.ServiceImp;
using AdvantureWork.Common.Constant;
using AdvantureWork.Common.Provider;
using AdvantureWork.Model.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdvantureWork.Api
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
            services.AddControllersWithViews();

            services.AddDbContext<AdventureWorksDW2017Context>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AdventureWorksDW2017Context>()
                .AddDefaultTokenProviders();

            // Log4Net
            services.AddSingleton<ILoggerManager, LoggerManager>();

            //Declare DI

            services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
            services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();

            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserRoleService, UserRoleService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICountryRegionBusinessService, CountryRegionBusinessService>();

            // Swagger:
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger Advanture-work Solution", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });
            });

            services.AddAuthentication();

            string issuer = Configuration.GetValue<string>("Tokens:Issuer");
            string signingKey = Configuration.GetValue<string>("Tokens:Key");
            byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = issuer,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = System.TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
                };
            });

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();

            SystemConstants.ConnectionString = configuration.GetSection("DefaultConnection").Value;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Adventure-work V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            Initialize(services);
        }

        public static async void Initialize(IServiceProvider services)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();

                CreateMasterRoles(roleManager);

                var user = new AppUser();
                user.UserName = "admin@gmail.com";
                user.Email = "admin@gmail.com";

                string userPWD = "abcde.A1";

                AppUser objUser;

                if (!UserIsExist(userManager, user))
                {
                    var result = await userManager.CreateAsync(user, userPWD);

                    objUser = userManager.Users.Where(o => o.Email == user.Email).First();

                    //Add default User to Role Admin
                    if (result.Succeeded)
                    {
                        var result1 = await userManager.AddToRoleAsync(objUser, "ADMIN");
                    }
                }
                else
                {
                    objUser = userManager.Users.Where(o => o.Email == user.Email).First();
                }

                await userManager.AddToRoleAsync(objUser, "ADMIN");


            }
        }

        private static bool UserIsExist(UserManager<AppUser> userManager, AppUser user)
        {
            var result = userManager.FindByEmailAsync(user.Email).GetAwaiter().GetResult();

            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void CreateMasterRoles(RoleManager<AppRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("ADMIN").GetAwaiter().GetResult())
            {
                var role = new AppRole();
                role.Name = "ADMIN";
                var roleCreate = roleManager.CreateAsync(role).GetAwaiter().GetResult();
            }

            if (!roleManager.RoleExistsAsync("EMPLOYEE").GetAwaiter().GetResult())
            {
                var role = new AppRole();
                role.Name = "EMPLOYEE";
                var roleCreate = roleManager.CreateAsync(role).GetAwaiter().GetResult();
            }

            if (!roleManager.RoleExistsAsync("STAFF").GetAwaiter().GetResult())
            {
                var role = new AppRole();
                role.Name = "STAFF";
                var roleCreate = roleManager.CreateAsync(role).GetAwaiter().GetResult();
            }

            if (!roleManager.RoleExistsAsync("MANAGER").GetAwaiter().GetResult())
            {
                var role = new AppRole();
                role.Name = "MANAGER";
                var roleCreate = roleManager.CreateAsync(role).GetAwaiter().GetResult();
            }

            if (!roleManager.RoleExistsAsync("HR").GetAwaiter().GetResult())
            {
                var role = new AppRole();
                role.Name = "HR";
                var roleCreate = roleManager.CreateAsync(role).GetAwaiter().GetResult();
            }
        }
    }
}