using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BicycleApi.Service;

namespace BicycleApi {
    public static class ConfigurationExtensions {
        public static IServiceCollection AddEmailService(this IServiceCollection services, IHostingEnvironment env, IConfiguration config) {
            services.Configure<SmtpSettings>(config.GetSection("SmsSettings"));
            // services.AddSingleton<ISmsTemplateFactory, SmsTemplateFactory>();
            if(env.IsDevelopment())
                services.AddTransient<ISmsService, DummySmsService>();
            else
                services.AddTransient<IMessageService, SendGridService>();

            return services;
        }

        public static IServiceCollection AddSmsService(this IServiceCollection services, IHostingEnvironment env, IConfiguration config) {
            return services;
        }
    }
}