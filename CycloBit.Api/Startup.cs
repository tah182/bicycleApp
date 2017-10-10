using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elmah.Io.Extensions.Logging;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using CycloBit.Api.Configuration;
using CycloBit.Api.Service;
using CycloBit.Model;
using CycloBit.Model.Entities;

namespace CycloBit.Api {
    public class Startup {
        private string corsPolicy => "corsPolicy";
        
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<CycloBitContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            ConfigureCommonServices(services);
        }

        public void ConfigureDevelopmentServices(IServiceCollection services) {
            services.AddTransient<IEmailService, SmtpService>();

            ConfigureCommonServices(services);
        }

        public void ConfigureProductionServices(IServiceCollection services) {
            services.AddTransient<IEmailService, SendGridService>();

            ConfigureCommonServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                loggerFactory.AddConsole();
            }
            
            app.UseCors(corsPolicy);
            app.UseAuthentication();
            app.UseMvc();

            loggerFactory.AddElmahIo("b3962ef3867743e49361f4672748fa8e", new Guid());
            var logger = loggerFactory.CreateLogger("elmah.io");
        }

        private void ConfigureCommonServices(IServiceCollection services) {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<CycloBitContext>()
                    .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options => {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            // if forever reason we want to allow cookies
            // services.ConfigureApplicationCookie(options => {
            //     options.Cookie.Expiration = TimeSpan.FromDays(30);
            //     // options.LoginPath = "/Account/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
            //     // options.LogoutPath = "/Account/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
            //     // options.AccessDeniedPath = "/Account/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
            //     options.SlidingExpiration = true;
            // });

            // Third Party Authentication
            services.AddAuthentication(options => {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;  
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 
                    })
                    .AddJwtBearer(options => {
                        options.RequireHttpsMetadata = false;
                        options.SaveToken = true;
                        
                        options.TokenValidationParameters = new TokenValidationParameters {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = Configuration["Auth:Token:Issuer"],
                            ValidAudience = Configuration["Auth:Token:Issuer"],
                            IssuerSigningKey = JwtSecurityKey.Create(Configuration["Auth:Token:Key"])
                        };
                    })
                    .AddFacebook(options => {
                        options.AppId = Configuration["Auth:Facebook:AppId"];
                        options.AppSecret = Configuration["Auth:Facebook:AppSecret"];
                        // options.Fields = ["birthday", "email", "first_name", "last_name", "gender", "name_format", "picture"];
                    })
                    .AddGoogle(options => {
                        options.ClientId = Configuration["Auth:Google:ClientId"];
                        options.ClientSecret = Configuration["Auth:Google:ClientSecret"];
                    })
                    .AddTwitter(options => {
                        options.ConsumerKey = Configuration["Auth:Twitter:ConsumerKey"];
                        options.ConsumerSecret = Configuration["Auth:Twitter:ConsumerSecret"];
                    });

            // CORS
            services.AddCors(s => s.AddPolicy(corsPolicy, builder => {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            // Config section
            services.Configure<SmtpSettings>(Configuration.GetSection("SmsSettings"));
            services.AddSingleton<IConfiguration>(Configuration);

            // AddMvc Must always be last in the pipeline
            services.AddMvc();
        }
    }
}
